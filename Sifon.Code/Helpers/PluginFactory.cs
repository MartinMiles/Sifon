using System;
using Sifon.Abstractions.Plugins;
using Sifon.Code.Providers.Profile;

namespace Sifon.Code.Helpers
{
    internal class PluginFactory
    {
        private readonly ProfilesProvider _profilesService;

        internal PluginFactory()
        {
            _profilesService = new ProfilesProvider();
        }

        internal IPlugin Create(Type type)
        {
            var selectedProfile = _profilesService.SelectedProfile;
            return selectedProfile != null ? (IPlugin) Activator.CreateInstance(type, selectedProfile) : null;
        }
    }
}
