using System;
using System.Collections.Generic;
using Sifon.Abstractions.Plugins;
using Sifon.Abstractions.Providers;
using Sifon.Code.Providers.Profile;

namespace Sifon.Code.Factories
{
    // This class is to be replaced with a decent DI container and resolver, when matured
    public static class Create
    {
        public static T New<T>() where T : class
        {
            var concreteTypes = new Dictionary<Type, Func<T>> {
                { typeof(IProfilesProvider), () => new ProfilesProvider() as T },
                { typeof(ISettingsProvider), () => new SettingsProvider() as T },
                { typeof(IContainersProvider), () => new ContainersProvider() as T },
            };

            return concreteTypes[typeof(T)]();
        }

        public static T WithProfile<T>() where T : class
        {
            var profile = New<IProfilesProvider>().SelectedProfile;
            return (IPlugin) Activator.CreateInstance(typeof(T), profile) as T;
        }
    }
}
