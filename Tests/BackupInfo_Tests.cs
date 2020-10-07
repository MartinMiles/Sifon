using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sifon.Code.BackupInfo;

namespace Tests
{
    [TestClass]
    public class BackupInfo_Tests : BaseTests
    {
        //[TestMethod]
        //public void BackupRestoreModel()
        //{
        //    const string filePath = @"c:\RssbPlatform.Installer\Cache\BackupInfo.xml";
        //    const string webRoot = @"C:\inetpub\wwwroot\RssbPlatform.dev.local";
        //    const string sitecoreInstance = "RssbPlatform.dev.local";

        //    BackupInfoExtensions.CreateBackupInfo(sitecoreInstance, profile);

        //    Assert.IsTrue(File.Exists(filePath));

        //    var loaded = new BackupInfo(filePath);
        //    Assert.AreEqual(sitecoreInstance, loaded.SitecoreInstance);
        //    Assert.AreEqual(webRoot, loaded.Webroot);
        //}

        //[TestMethod]
        //public void ReadFromZip()
        //{
        //    //const string infoFile = @"BackupInfo.xml";
        //    const string filePath = @"c:\Backups\!\RssbPlatform.dev.local.zip";
        //    const string extractToFilePath = @"c:\RssbPlatform.Installer\Cache\BackupInfo.xml";

        //    DeletIfExists(extractToFilePath);

        //    var backupInfoExtractor = new BackupInfoExtractorFactory(profile).Create();
        //    var backupInfo = await backupInfoExtractor.GetFromArchive(filePath);

        //    Assert.IsNotNull(backupInfo);
        //    Assert.IsFalse(string.IsNullOrWhiteSpace(backupInfo.SitecoreInstance));
        //    Assert.IsFalse(string.IsNullOrWhiteSpace(backupInfo.Webroot));
        //    DeletIfExists(extractToFilePath);
        //}

        private void DeletIfExists(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }
    }
}
