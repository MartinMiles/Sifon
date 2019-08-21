using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sifon.Shared.Providers.Profile;

[TestClass]
public class ProfileTest
{
    [TestMethod]
    public void LoadProfiles()
    {
        var _profiles = new ProfilesProvider();
        var read = _profiles.Read();
        Assert.AreEqual(2, read.Count());
    }
}