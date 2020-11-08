using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sifon.Abstractions.Providers;
using Sifon.Code.Factories;

[TestClass]
public class ProfileTest
{
    [TestMethod]
    public void LoadProfiles()
    {
        var provider = Create.New<IProfilesProvider>();
        var read = provider.Read();
        Assert.AreEqual(2, read.Count());
    }
}