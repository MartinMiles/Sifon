using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        SecureString Password
        {
            get
            {
                var password = new SecureString();
                password.AppendChar('3');
                password.AppendChar('2');
                password.AppendChar('1');

                return password;
            }
        }



        [TestMethod]
        public void Test_RemotePowerShell()
        {
            string shellUri = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";
            PSCredential remoteCredential = new PSCredential("Martin", Password);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(false, "192.168.173.11", 5985, "/wsman", shellUri, remoteCredential, 1 * 60 * 1000);

            string scriptPath = $@"
                $Session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri http://servername/poweshell -Credential {remoteCredential} | Out-String
                Import-PSSession $Session";

            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
            runspace.Open();
            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
            Pipeline pipeline = runspace.CreatePipeline();
            string scriptfile = scriptPath;
            Command myCommand = new Command(scriptfile, false);
            pipeline.Commands.Add(myCommand);
            pipeline.Invoke();
            runspace.Close();
        }
    }
}
