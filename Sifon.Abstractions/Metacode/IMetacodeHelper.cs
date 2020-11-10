using System.Collections.Generic;

namespace Sifon.Abstractions.Metacode
{
    public interface IMetacodeHelper
    {
        bool IsCompatibleVersion { get; }
        bool LocalEnforcementValid { get; }
        string Name { get; }
        string Description { get; }

        IDictionary<string, object> ExecuteMetacode(IDictionary<string, dynamic> parameters, string winformsAssemblyLocation);
        IEnumerable<string> IdentifyDependencies();
    }
}
