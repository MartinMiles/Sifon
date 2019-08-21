using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Security;
using Microsoft.PowerShell;
using Sifon.Abstractions.Profiles;

namespace Sifon.Shared.PowerShell
{
    internal class ProfileRunspaceFactory
    {
        private readonly IProfile _profile;

        internal ProfileRunspaceFactory(IProfile profile)
        {
            _profile = profile;
        }

        public Runspace Create()
        {
            var connectionInfo = new WSManConnectionInfo();

            if (_profile != null && _profile.RemotingEnabled)
            {
                // The OperationTimeout property is used to tell Windows PowerShell how long to wait (in milliseconds) before timing out for an operation.
                // The OpenTimeout property is used to tell Windows PowerShell how long to wait (in milliseconds) before timing out while establishing a remote connection.

                connectionInfo.OperationTimeout = _profile.OperationTimeout * 1000;
                connectionInfo.OpenTimeout = _profile.ConnectionTimeout * 1000; 
                connectionInfo.Credential = new PSCredential(_profile.RemoteUsername, GetSecureString(_profile.RemotePassword));
                connectionInfo.ComputerName = _profile.RemoteExecutionHost;
                return RunspaceFactory.CreateRunspace(connectionInfo);
            }

            return CreateLocal();
        }

        public Runspace CreateLocal()
        {
            InitialSessionState initial = InitialSessionState.CreateDefault();
            initial.ExecutionPolicy = ExecutionPolicy.Unrestricted;
            initial.ImportPSModule(new[] { "SQLPS" });
            return RunspaceFactory.CreateRunspace(initial);
        }

        private SecureString GetSecureString(string password)
        {
            return new NetworkCredential("", password).SecurePassword;
        }
    }
}
