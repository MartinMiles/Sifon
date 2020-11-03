namespace Sifon.Code.Model.Profiles
{
    internal static class DefaultContainers
    {
        internal static ContainerProfile Sitecore10XP = new ContainerProfile
        {
            ContainerProfileName = "Sitecore 10 XP0 - Getting Started",
            Repository = "https://github.com/Sitecore/docker-examples",
            Folder = "getting-started",
            SitecoreAdminPassword = "Password12345",
            SaPassword = "Password12345",
            InitializeScript = "Init.ps1",
            Notes = "A basic example of Sitecore 10 XP0 working in containers"
        };

        internal static ContainerProfile LighthouseDemo = new ContainerProfile
        {
            ContainerProfileName = "Lighthouse",
            Repository = "https://github.com/Sitecore/Sitecore.Demo.Platform",
            Folder = "",
            SitecoreAdminPassword = "Password12345",
            SaPassword = "Password12345",
            InitializeScript = "Init.ps1",
            Notes = "The latest Lighthouse demo is built to support Sitecore Experience Platform 10.0 using Sitecore Experience Accelerator (SXA) 10.0."
        };
    }
}
