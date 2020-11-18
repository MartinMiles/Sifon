using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Management.Automation;
using Sifon.Abstractions.Helpers;
using Sifon.Abstractions.Metacode;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Abstractions.ScriptGenerators;
using Sifon.Code.Helpers;
using Sifon.Code.Metacode;
using Sifon.Code.PowerShell;
using Sifon.Code.Providers;
using Sifon.Code.Providers.Profile;
using Sifon.Code.ScriptGenerators;

namespace Sifon.Code.Factories
{
    // This class is to be replaced with a decent DI container and resolver, when matured
    public static partial class Create
    {
        public static T New<T>() where T : class
        {
            var concreteTypes = new Dictionary<Type, Func<T>> {
                { typeof(IProfilesProvider), () => new ProfilesProvider() as T },
                { typeof(ISettingsProvider), () => new SettingsProvider() as T },
                { typeof(IContainersProvider), () => new ContainersProvider() as T },

                { typeof(ISqlServerRecordProvider), () => new SqlServerRecordProvider() as T },
            };

            return concreteTypes[typeof(T)]();
        }

        public static T WithCurrentProfile<T>(ISynchronizeInvoke invoker = null) where T : class
        {
            var profile = New<IProfilesProvider>().SelectedProfile;
            return WithProfile<T>(profile, invoker);
        }

        public static T WithProfile<T>(IProfile profile, ISynchronizeInvoke invoker = null) where T : class
        {
            var concreteTypes = new Dictionary<Type, Func<T>>
            {
                {typeof(ISiteProvider), () => new PowerShellSiteProvider(profile, invoker) as T},
                {typeof(IRemoteScriptCopier), () => new RemoteScriptCopier(profile, invoker) as T},
                {typeof(IParametersSampleScriptGenerator), () => new ParametersSampleScriptGenerator(profile) as T},
                {typeof(IServiceScriptGenerator), () => new ServiceScriptGenerator(profile) as T},
                {typeof(IIndexFinder), () => new IndexFinder(profile, invoker) as T},
                {typeof(ISolrIdentifier), () => new SolrIdentifier(invoker) as T}
            };

            return concreteTypes[typeof(T)]();
        }

        public static IScriptWrapper<T> WithParam<T>(ISynchronizeInvoke invoker, Func<PSObject, T> convert, IProfile profile = null) 
            //where T : class
        {
            var currentProfile = profile ?? New<IProfilesProvider>().SelectedProfile;
            return new ScriptWrapper<T>(currentProfile, invoker, convert);
        }

        public static T WithParam<T,U>(U parameter) where T : class
        {
            var concreteTypes = new Dictionary<Type, Func<U, T>>
            {
                {typeof(IMetacodeHelper), p => new MetacodeHelper(p as string) as T}
            };

            return concreteTypes[typeof(T)](parameter);
        }

        public static T WithParam<T>(IBackupRemoverViewModel model) where T : class
        {
            var profile = New<IProfilesProvider>().SelectedProfile;

            switch (model.EmbeddedActivity)
            {
                case EmbeddedActivity.Backup: return new BackupScriptGenerator(model, profile) as T;
                case EmbeddedActivity.Remove: return new RemoverScriptGenerator(model, profile) as T;
                case EmbeddedActivity.Restore: return new RestoreScriptGenerator(model, profile) as T;
            }

            throw new NotImplementedException();
        }

        public static T FromType<T>(Type type) where T : class
        {
            var profile = New<IProfilesProvider>().SelectedProfile;
            return Activator.CreateInstance(type, profile) as T;
        }
    }
}
