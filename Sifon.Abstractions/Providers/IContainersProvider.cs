using System.Collections.Generic;
using Sifon.Abstractions.Profiles;

namespace Sifon.Abstractions.Providers
{
    public interface IContainersProvider
    {
        void AddContainersParameters(Dictionary<string, object> parameters);
        IContainerProfile SelectedProfile { get; }
        IEnumerable<string> Profiles { get; }
        void Save();
        void DeleteSelected();
        void SelectProfile(string profileName);
        void Add(IContainerProfile containerProfile);
    }
}
