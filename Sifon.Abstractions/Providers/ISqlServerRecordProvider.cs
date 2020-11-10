using System.Collections.Generic;
using Sifon.Abstractions.Profiles;

namespace Sifon.Abstractions.Providers
{
    public interface ISqlServerRecordProvider
    {
        void Add(ISqlServerRecord record);
        void Save();
        void Delete(string name);
        void UpdateSelected(string str, ISqlServerRecord iServerRecord);
        IEnumerable<ISqlServerRecord> Read();

        ISqlServerRecord GetByName(string selectedServerName);
    }
}
