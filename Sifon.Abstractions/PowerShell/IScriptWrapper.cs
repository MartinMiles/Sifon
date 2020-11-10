using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Sifon.Abstractions.PowerShell
{
    public delegate void CompleteDelegate(IScriptRunner sender);
    public delegate void ProgressReadyDelegate(ProgressRecord data);
    public delegate void ErrorReadyDelegate(Exception exception);
    public delegate void ObjectReadyDelegate<T>(T data);
    public delegate void InformationReadyDelegate(string message);
    public delegate void WarningReadyDelegate(string message);

    public interface IScriptWrapper<T>
    {
        event CompleteDelegate Complete;
        event ErrorReadyDelegate ErrorReady;
        event ProgressReadyDelegate ProgressReady;
        event ObjectReadyDelegate<T> ObjectReady;
        event InformationReadyDelegate InformationReady;
        event WarningReadyDelegate WarningReady;

        List<T> Results { get; }
        List<Exception> Errors { get; }

        Task<PSDataCollection<PSObject>> Run(string script, IDictionary<string, dynamic> parameters = null);
        void Finish();
    }
}
