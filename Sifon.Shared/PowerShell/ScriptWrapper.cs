using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Exceptions;

namespace Sifon.Shared.PowerShell
{
    public class ScriptWrapper<T>
    {
        private readonly IProfile _profile;
        private readonly ISynchronizeInvoke _invoker;
        private readonly Func<PSObject, T> _convert;

        protected Runspace runSpace;
        private ScriptRunner scriptRunner;

        public List<T> Results { get; private set; }
        public List<Exception> Errors { get; private set; }
        
        public ScriptWrapper(IProfile profile, ISynchronizeInvoke invoker, Func<PSObject, T> convert)
        {
            _profile = profile;
            _invoker = invoker;
            _convert = convert;
        }
        
        private void CreateRunspace()
        {
            runSpace = new ProfileRunspaceFactory(_profile).Create();
        }

        private void OpenRunspace()
        {
            try
            {
                if (runSpace.RunspaceStateInfo.State != RunspaceState.Opened)
                {
                    runSpace.Open();
                }
            }
            catch (PSRemotingTransportException e)
            {
                int k = 0;
                //ShowError("Profile with remoting errors out", e.Message);
            }
        }
        
        public Task<PSDataCollection<PSObject>> Run(string script, Dictionary<string, dynamic> parameters = null)
        {
            CreateRunspace();
            StopScript();

            Results = new List<T>();
            Errors = new List<Exception>();

            try
            {
                scriptRunner = new ScriptRunner(runSpace, _invoker, script, parameters);
                return StartScript();
            }
            //catch (RemoteNotInitializedException e)
            //{
            //    Errors.Add(e);
            //    Finish();
            //}
            catch (RemoteTimeoutException e)
            {
                Errors.Add(e);
                Finish();
            }

            return Task.FromResult<PSDataCollection<PSObject>>(null);
        }

        public IEnumerable<T> RunSync(string script, Dictionary<string, dynamic> parameters = null)
        {
            Results = new List<T>();

            CreateRunspace();
            OpenRunspace();
            
            try
            {
                using (System.Management.Automation.PowerShell powerShell = System.Management.Automation.PowerShell.Create())
                {
                    powerShell.Runspace = runSpace;

                    var command = new Command(script);
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, dynamic> parameter in parameters)
                        {
                            command.Parameters.Add(new CommandParameter(parameter.Key, parameter.Value));
                        }
                    }
                    powerShell.Commands.AddCommand(command);

                    var output = powerShell.Invoke();

                    foreach (PSObject outputItem in output)
                    {
                        if (outputItem != null)
                        {
                            T converted = _convert(outputItem);
                            if (converted != null)
                            {
                                Results.Add(converted);
                                ObjectReady(converted);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }

            runSpace.Close();

            return Results;
        }

        private Task<PSDataCollection<PSObject>> StartScript()
        {
            OpenRunspace();

            scriptRunner.OnComplete += OnComplete;
            scriptRunner.OnObjectReady += OnObjectDataReady;
            scriptRunner.OnProgressReady += OnProgressReady;
            scriptRunner.OnInformationReady += OnInformationReady;
            scriptRunner.OnWarningReady += OnWarningReady;
            scriptRunner.OnErrorReady += OnErrorReady;

            return scriptRunner.Start();
        }

        private void StopScript()
        {
            if (scriptRunner != null)
            {
                scriptRunner.OnComplete -= OnComplete;
                scriptRunner.OnObjectReady -= OnObjectDataReady;
                scriptRunner.OnProgressReady -= OnProgressReady;
                scriptRunner.OnInformationReady -= OnInformationReady;
                scriptRunner.OnWarningReady -= OnWarningReady;
                scriptRunner.OnErrorReady -= OnErrorReady;

                scriptRunner.Stop();
                scriptRunner = null;
            }
        }

        public void Finish()
        {
            StopScript();
            runSpace?.Close();
        }

        #region Plumbing for events

        public event CompleteDelegate Complete = delegate { };
        public event ObjectReadyDelegate ObjectReady = delegate { };
        public event ProgressReadyDelegate ProgressReady = delegate { };
        public event InformationReadyDelegate InformationReady = delegate { };
        public event WarningReadyDelegate WarningReady = delegate { };
        public event ErrorReadyDelegate ErrorReady = delegate { };

        public delegate void CompleteDelegate(IScriptRunner sender);
        public delegate void ObjectReadyDelegate(T data);
        public delegate void ProgressReadyDelegate(ProgressRecord data);
        public delegate void ErrorReadyDelegate(Exception exception);
        public delegate void InformationReadyDelegate(string message);
        public delegate void WarningReadyDelegate(string message);

        private void OnObjectDataReady(ScriptRunner sender, PSObject data)
        {
            var converted = _convert(data);

            if (converted != null)
            {
                Results.Add(converted);
                ObjectReady(converted);
            }
        }

        private void OnComplete(ScriptRunner sender)
        {
            Finish();
            Complete(sender);
        }

        private void OnErrorReady(ScriptRunner sender, ErrorRecord data)
        {
            if (data != null)
            {
                Errors.Add(data.Exception);
                ErrorReady(data.Exception);
            }
        }

        private void OnWarningReady(ScriptRunner sender, WarningRecord data)
        {
            if (data != null)
            {
                WarningReady(data.Message);
            }
        }

        private void OnInformationReady(ScriptRunner sender, InformationRecord data)
        {
            if (data != null)
            {
                InformationReady(data.MessageData.ToString());
            }
        }

        private void OnProgressReady(ScriptRunner sender, ProgressRecord data)
        {
            if (data != null)
            {
                if (sender?.Parameters == null || !sender.Parameters.Any() || !sender.Parameters.ContainsKey("activity") || sender.Parameters["activity"] == data.Activity)
                {
                    ProgressReady(data);
                }
            }
        }

        #endregion
    }
}
