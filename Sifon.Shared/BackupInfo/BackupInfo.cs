using System.IO;
using System.Xml;

namespace Sifon.Shared.BackupInfo
{
    public class BackupInfo
    {
        #region Properties

        public string Webroot { get; set; }
        public string SitecoreInstance { get; set; }

        #endregion

        #region Constructors

        public BackupInfo()
        {
        }

        public BackupInfo(string filePath)
        {
            if (File.Exists(filePath))
            {
                var doc = new XmlDocument();
                doc.Load(filePath);
                this.Parse(doc.DocumentElement);
            }
        }

        #endregion
    }
}
