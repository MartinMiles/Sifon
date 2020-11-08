using System;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.ScriptGenerators;

namespace Sifon.Code.ScriptGenerators
{
    public class ScriptGeneratorFactory
    {
        public static IScript Create(IBackupRemoverViewModel model, IProfile profile)
        {
            switch (model.EmbeddedActivity)
            {
                case EmbeddedActivity.Backup: return new BackupScriptGenerator(model, profile);
                case EmbeddedActivity.Remove: return new RemoverScriptGenerator(model, profile);
                case EmbeddedActivity.Restore: return new RestoreScriptGenerator(model, profile);
            }

            throw new NotImplementedException();
        }
    }
}
