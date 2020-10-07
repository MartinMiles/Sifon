using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sifon.Code.PowerShell;

namespace Tests
{
    [TestClass]
    public class RemoteHelper_tests : BaseTests
    {
        //[TestMethod]
        //public void TestRemoteSave()
        //{
        //    string script = @"c:\RssbPlatform.Installer\Plugins\PowerShell\Progress\Test Progress.ps1";

        //    var profile = new Profile
        //    {
        //        RemoteExecutionHost = "192.168.173.14",
        //        RemoteUsername = "Martin",
        //        RemotePassword = "321"
        //    };

        //    // cache into remote
        //    var remoter = new RemoteHelper(profile);
        //    var results = remoter.SaveScript(script);

        //    Assert.IsNotNull(results);
        //    Assert.IsTrue(results.Any());

        //    // ensure it all saves the script remotely into a folder
        //}



        //[TestMethod]
        //public void DirectoryInfo_test()
        //{
        //    string directoryPath = @"C:\Backups";
        //    string script = $@"Get-Item '{directoryPath}'";

        //    var runner = new SimpleRunner();
        //    var infos = runner.Execute<DirectoryInfo>(script);

        //    Assert.IsNotNull(infos);
        //    Assert.AreEqual(1, infos.Count());
        //}
    }
}
