using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading;
using System.Threading.Tasks;
using Sifon.Abstractions.PowerShell;
using Sifon.Code.Exceptions;

namespace Sifon.Code.PowerShell
{
    internal class ScriptRunner : IScriptRunner
    {
        private readonly System.Management.Automation.PowerShell _powerShell;
        readonly PSDataCollection<PSObject> _outputCollection;
        private readonly ISynchronizeInvoke _invoker;
        private IAsyncResult _invokeResult;
        private readonly ManualResetEvent _stopEvent;
        private readonly WaitHandle[] _waitHandles;

        #region Delegates, events, syncronizers

        public delegate void CompleteDelegate(ScriptRunner sender);
        public delegate void ObjectReadyDelegate(ScriptRunner sender, PSObject data);
        public delegate void ProgressReadyDelegate(ScriptRunner sender, ProgressRecord data);
        public delegate void ErrorReadyDelegate(ScriptRunner sender, ErrorRecord data);
        public delegate void InformationReadyDelegate(ScriptRunner sender, InformationRecord data);
        public delegate void VerboseReadyDelegate(ScriptRunner sender, VerboseRecord data);
        public delegate void WarningReadyDelegate(ScriptRunner sender, WarningRecord data);
        public delegate void DebugReadyDelegate(ScriptRunner sender, DebugRecord data);

        public event CompleteDelegate OnComplete = delegate { };
        public event ObjectReadyDelegate OnObjectReady = delegate { };
        public event ProgressReadyDelegate OnProgressReady = delegate { };
        public event InformationReadyDelegate OnInformationReady = delegate { };
        public event WarningReadyDelegate OnWarningReady = delegate { };
        public event VerboseReadyDelegate OnVerboseReady = delegate { };
        public event DebugReadyDelegate OnDebugReady = delegate { };
        public event ErrorReadyDelegate OnErrorReady = delegate { };

        private readonly CompleteDelegate synchComplete;
        private readonly ObjectReadyDelegate synchObjectReady;
        private readonly ProgressReadyDelegate synchProgressReady;
        private readonly InformationReadyDelegate synchInformationReady;
        private readonly WarningReadyDelegate synchWarningReady;
        private readonly ErrorReadyDelegate synchErrorReady;
        private readonly VerboseReadyDelegate synchVerboseReady;
        private readonly DebugReadyDelegate synchDebugReady;

        #endregion

        public string ScriptFile { get; private set; }

        public IDictionary<string, dynamic> Parameters { get; private set; }

        internal ScriptRunner(Runspace runSpace, ISynchronizeInvoke invoker, string script, IDictionary<string, dynamic> parameters = null)
        {
            _invoker = invoker;
            _stopEvent = new ManualResetEvent(false);
            _waitHandles = new WaitHandle[] { null, _stopEvent };

            ScriptFile = script;
            Parameters = parameters;

            _powerShell = System.Management.Automation.PowerShell.Create();
            _powerShell.Runspace = runSpace;
            
            var command = new Command(script);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, dynamic> parameter in parameters)
                {
                    command.Parameters.Add(new CommandParameter(parameter.Key, parameter.Value));
                }
            }
            _powerShell.Commands.AddCommand(command);

            _outputCollection = new PSDataCollection<PSObject>();
            _outputCollection.DataAdded += OnObjectOutput;

            synchComplete = SyncComplete;
            synchObjectReady = SyncObjectReady;
            synchProgressReady = SyncProgressReady;
            synchInformationReady = SyncInformationReady;
            synchWarningReady = SyncWarningReady;
            synchErrorReady = SyncErrorReady;
            synchVerboseReady = SyncVerboseReady;
            synchDebugReady = SyncDebugReady;

            _powerShell.InvocationStateChanged += StateChanged;
            _powerShell.Streams.Progress.DataAdded += OnProgress;
            _powerShell.Streams.Error.DataAdded += OnError;
            _powerShell.Streams.Information.DataAdded += OnInformation;
            _powerShell.Streams.Verbose.DataAdded += OnVerbose;
            _powerShell.Streams.Debug.DataAdded += OnDebug;
            _powerShell.Streams.Warning.DataAdded += OnWarning;
        }

        #region Start / Stop

        public Task<PSDataCollection<PSObject>> Start()
        {
            if (_powerShell.InvocationStateInfo.State == PSInvocationState.NotStarted)
            {
                if (_powerShell == null)
                {
                    throw new ArgumentNullException();
                }

                try
                {
                    return Task.Factory.FromAsync(_powerShell.BeginInvoke<PSObject, PSObject>(null, _outputCollection), EndInvoke);
                }
                catch (InvalidRunspaceStateException e)
                {
                    if (e.CurrentState == RunspaceState.Broken)
                    {
                        throw new RemoteTimeoutException("Remote operation timed out. Please check remote host availability");
                    }
                }
            }

            return null;
        }

        private PSDataCollection<PSObject> EndInvoke(IAsyncResult result)
        {
            try
            {
                return _powerShell.EndInvoke(result);
            }
            catch (PipelineStoppedException e)
            {
                return null;
            }
            catch (RemoteException e)
            {
                // "is not recognized as the name of a cmdlet" - occurs when remote folder deleted but still presents in profile
                // also happened whn tried to use existing remote profile with another VM that has not been initialized
                throw new RemoteNotInitializedException(e.Message, e);
            }
        }

        public void Stop()
        {
            _stopEvent.Set();

            if (_invokeResult != null)
            {
                _invoker.EndInvoke(_invokeResult);
            }
        }

        #endregion

        #region Handlers

        private void StateChanged(object sender, PSInvocationStateChangedEventArgs e)
        {
            if (e.InvocationStateInfo.State == PSInvocationState.Completed)
            {
                StoppableInvoke(synchComplete, new object[] { this });
            }
        }

        private void OnObjectOutput(object sender, DataAddedEventArgs e)
        {
            var psDataCollection = sender as PSDataCollection<PSObject>;
            if (psDataCollection != null && psDataCollection.Any())
            {
                var currentObject = psDataCollection[e.Index];
                StoppableInvoke(synchObjectReady, new object[] { this, currentObject });
            }
        }

        private void OnProgress(object sender, DataAddedEventArgs e)
        {
            var psDataCollection = sender as PSDataCollection<ProgressRecord>;
            if (psDataCollection != null)
            {
                var currentProgress = psDataCollection[e.Index];
                StoppableInvoke(synchProgressReady, new object[] { this, currentProgress });
            }
        }

        private void OnError(object sender, DataAddedEventArgs e)
        {
            var psDataCollection = sender as PSDataCollection<ErrorRecord>;
            if (psDataCollection != null)
            {
                var currentError = psDataCollection[e.Index];
                StoppableInvoke(synchErrorReady, new object[] { this, currentError });
            }
        }

        private void OnInformation(object sender, DataAddedEventArgs e)
        {
            var psDataCollection = sender as PSDataCollection<InformationRecord>;
            if (psDataCollection != null)
            {
                var currentInformation = psDataCollection[e.Index];
                StoppableInvoke(synchInformationReady, new object[] { this, currentInformation });
            }
        }

        private void OnWarning(object sender, DataAddedEventArgs e)
        {
            var psDataCollection = sender as PSDataCollection<WarningRecord>;
            if (psDataCollection != null)
            {
                var currentWarning = psDataCollection[e.Index];
                StoppableInvoke(synchWarningReady, new object[] { this, currentWarning });
            }
        }

        private void OnVerbose(object sender, DataAddedEventArgs e)
        {
            var psDataCollection = sender as PSDataCollection<VerboseRecord>;
            if (psDataCollection != null)
            {
                var currentVerbose = psDataCollection[e.Index];
                StoppableInvoke(synchVerboseReady, new object[] { this, currentVerbose });
            }
        }

        private void OnDebug(object sender, DataAddedEventArgs e)
        {
            var psDataCollection = sender as PSDataCollection<DebugRecord>;
            if (psDataCollection != null)
            {
                var currentDebug = psDataCollection[e.Index];
                StoppableInvoke(synchDebugReady, new object[] { this, currentDebug });
            }
        }

        #endregion 

        #region Sync plumbing

        private object StoppableInvoke(Delegate method, object[] args)
        {
            try
            {
                //IAsyncResult asyncResult = _invoker.BeginInvoke(method, args);
                _invokeResult = _invoker.BeginInvoke(method, args);
                _waitHandles[0] = _invokeResult.AsyncWaitHandle;
                return WaitHandle.WaitAny(_waitHandles) == 0 ? _invoker.EndInvoke(_invokeResult) : null;
            }
            catch
            {
                return null;
            }
        }

        private void SyncComplete(ScriptRunner sender)
        {
            OnComplete(sender);
        }

        private void SyncObjectReady(ScriptRunner sender, PSObject data)
        {
            OnObjectReady(this, data);
        }

        private void SyncProgressReady(ScriptRunner sender, ProgressRecord data)
        {
            OnProgressReady(this, data);
        }

        private void SyncInformationReady(ScriptRunner sender, InformationRecord data)
        {
            OnInformationReady(this, data);
        }

        private void SyncWarningReady(ScriptRunner sender, WarningRecord data)
        {
            OnWarningReady(this, data);
        }

        private void SyncErrorReady(ScriptRunner sender, ErrorRecord data)
        {
            OnErrorReady(this, data);
        }

        private void SyncVerboseReady(ScriptRunner sender, VerboseRecord data)
        {
            OnVerboseReady(this, data);
        }

        private void SyncDebugReady(ScriptRunner sender, DebugRecord data)
        {
            OnDebugReady(this, data);
        }

        #endregion
    }
}
