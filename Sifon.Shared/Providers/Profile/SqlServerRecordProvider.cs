using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions.Models;
using Sifon.Shared.Model.Profiles;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Providers.Profile
{
    public class SqlServerRecordProvider
    {
        private IEnumerable<ISqlServerRecord> _entities;

        public SqlServerRecordProvider()
        {
            _entities = Read();
        }

        #region CRUD

        public void Add(ISqlServerRecord record)
        {
            _entities = _entities.Append(record);
        }

        public IEnumerable<ISqlServerRecord> Read()
        {
            var items = new List<ISqlServerRecord>();

            if (File.Exists(Settings.ProfilesFolder.SqlProfilesPath))
            {
                var doc = new XmlDocument();
                doc.Load(Settings.ProfilesFolder.SqlProfilesPath);

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    items.Add(new SqlServerRecord(node));
                }
            }

            return items;
        }

        public void Save()
        {
            var doc = new XDocument();
            var root = new XElement(Settings.Xml.SqlServerRecord.NodeListName);
            doc.Add(root);

            foreach (var record in _entities)
            {
                root.Add(record.Save());
            }

            doc.Save(Settings.ProfilesFolder.SqlProfilesPath);
        }

        public void Delete(string name)
        {
            var list = _entities.ToList();
            list.Remove(_entities.First(p => p.RecordName == name));
            _entities = list;
        }

        #endregion

        public ISqlServerRecord GetByName(string selectedServerName)
        {
            return _entities.FirstOrDefault(e => e.RecordName == selectedServerName);
        }

        public void UpdateSelected(string oldName, ISqlServerRecord record)
        {
            if (_entities.FirstOrDefault(p => p.RecordName == oldName) is SqlServerRecord selected)
            {
                selected.RecordName = record.RecordName;
                selected.SqlServer = record.SqlServer;
                selected.SqlAdminUsername = record.SqlAdminUsername;
                selected.SqlAdminPassword = record.SqlAdminPassword;
            }
        }
    }
}
