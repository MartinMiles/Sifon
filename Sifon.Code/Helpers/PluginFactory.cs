using System;
using Sifon.Abstractions.Plugins;
using Sifon.Abstractions.Providers;
using Sifon.Code.Factories;

namespace Sifon.Code.Helpers
{
    //TODO: Delete this class

    internal class PluginFactory
    {
        private readonly IProfilesProvider _profilesService;

        internal PluginFactory()
        {
            _profilesService = Create.New<IProfilesProvider>();
        }

        //internal IPlugin Create(Type type)
        //{
        //    //var selectedProfile = _profilesService.SelectedProfile;
        //    //return selectedProfile != null ? (IPlugin) Activator.CreateInstance(type, selectedProfile) : null;
        //}
    }
}
