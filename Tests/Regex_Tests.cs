using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sifon.Code.Helpers;
using Sifon.Statics;

namespace Tests
{
    [TestClass]
    public class Regex_Tests
    {
        [TestMethod]
        public void Match_Test()
        {
            string line1 = "#COLOR:Yellow#Line 4";
            string line2 = "#COLOR:YellowLine 4";

            var helper = new RegexHelper(Pattern.ColorPattern);
            Assert.IsTrue(helper.Match(line1));
            Assert.IsFalse(helper.Match(line2));
        }

        [TestMethod]
        public void Remove_Test()
        {
            string line = "#COLOR:Yellow#Line 4";

            var helper = new RegexHelper(Pattern.ColorPattern);
            line = helper.Replace(line);

            Assert.AreEqual("Line 4", line);
        }

        [TestMethod]
        public void ReadScriptHeader_Test()
        {
            const string FilePath = @"C:\RssbPlatform.Installer\Plugins\PowerShell\Remoting\Remote-Test.ps1";

            var tuple = ReadScriptNameAndDescription(FilePath);

            Assert.IsNotNull(tuple);
            Assert.IsNotNull(tuple.Item1);
            Assert.IsNotNull(tuple.Item2);
            Assert.IsTrue(tuple.Item1.Length > 0);
            Assert.IsTrue(tuple.Item2.Length > 0);
        }

        private Tuple<string, string> ReadScriptNameAndDescription(string FilePath)
        {
            const string namePattern = @"^###\s*(?i)Name(?-i):\s*(.*)$";
            const string descPattern = @"^###\s*(?i)Description(?-i):\s*(.*)$";

            var tuple = new Tuple<string, string>(null, null);

            if (File.Exists(FilePath))
            {
                var lines = File.ReadLines(FilePath);
                if (lines.Any())
                {
                    var firstLine = lines.ElementAt(0);

                    var name = new RegexHelper(namePattern).Extract(firstLine);
                    tuple = new Tuple<string, string>(name, null);

                    if (lines.Count() > 1)
                    {
                        var secondLine = lines.ElementAt(1);
                        var description = new RegexHelper(descPattern).Extract(secondLine);
                        tuple = new Tuple<string, string>(name, description);
                    }
                }
            }

            return tuple;
        }
    }
}
