using Sifon.Abstractions.Profiles;

namespace Sifon.Abstractions.Base
{
    public interface ISuperClass
    {
        string ShowFolderSelector(IProfile profile, string caption, bool allowNewFolders);
        string ShowFolderBrowser(IProfile profile, bool allowNewFolders);
        string AppendEnvironmentToCaption(IProfile profile);
    }
}
