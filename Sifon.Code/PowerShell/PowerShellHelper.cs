using System.Management.Automation;
using Sifon.Code.Statics;

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
            ps.AddCommand($"{Folders.Module}\\{Modules.Files.Installer}");
            ps.Invoke();
        }
    }
}
