using System.IO.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sifon.Abstractions.Profiles;
using Sifon.Plugins.Tests.Models;

namespace Sifon.Plugins.Tests
{
    [TestClass]
    public class Basic_Tests
    {
        [TestMethod]
        public void ZipSomeFile()
        {

            using (ZipArchive zip = ZipFile.Open(@"p:\Sitecore\Patched\9.0.2\Sitecore.Kernel.Patched.zip", ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(@"p:\Sitecore\Patched\9.0.2\Sitecore.Kernel.Patched.dll", "Sitecore.Kernel.dll");
            }
        }

        private string SaveTo => @"c:\!!\";

        private IProfile Profile => new Profile
        {
            Name = "",
            Website = "",
            Webroot = "",
            Solr = "",
        };
    }
}
