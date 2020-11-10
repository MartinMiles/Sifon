using System.Threading.Tasks;

namespace Sifon.Abstractions.PowerShell
{
    public interface IRemoteScriptCopier
    {
        Task<string> CopyIfRemote(string scriptPath);
    }
}
