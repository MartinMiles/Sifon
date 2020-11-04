using System.Management.Automation;

namespace Sifon.Code.PowerShell
{
    public class PowerShellHelper
    {
        public void InstallModuleOnFirstRun()
        {
            var ps = System.Management.Automation.PowerShell.Create();

            try
            {
                ps.AddCommand("Set-ExecutionPolicy")
                    .AddArgument("Unrestricted")
                    .AddParameter("Scope", "CurrentUser");

                ps.Invoke();
            }
            catch (CmdletInvocationException)
            {
            }

            ps = System.Management.Automation.PowerShell.Create();
            ps.AddCommand($".\\{Statics.Modules.Directory}\\{Statics.Modules.Files.Installer}");
            ps.Invoke();
        }
    }
}
