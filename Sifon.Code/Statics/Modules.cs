using System.IO;

namespace Sifon.Code.Statics
{
    public static class Modules
    {
        public static class Functions
        {
            internal const string GetInstanceUrl = "Get-InstanceUrl";
            internal const string DownloadResource = "Download-Resource";
            internal const string InstallSitecorePackage = "Install-SitecorePackage";
            internal const string CopyFileToRemote = "Copy-FileToRemote";
            internal const string VerifyPortalCredentials = "Verify-PortalCredentials";
            internal const string GetConnectionString = "Get-ConnectionString";
            internal const string InstallSitecorePackageUsingRemoting = "Install-SitecorePackageUsingRemoting";

            internal const string GetSiteFolder = "Get-SiteFolder";
            internal const string GetBindings = "Get-SiteBindings";
            internal const string GetSitecoreSites = "Get-SitecoreSites";
            public const string GetDatabases = "Get-Databases";
            internal const string GetCommerceDatabases = "Get-CommerceDatabases";
            public const string TestPortalCredentials = "Test-PortalCredentials";
            public const string TestSqlServerConnection = "Test-SqlServerConnection";
            internal const string ExtractBackupInfo = "Extract-BackupInfo";
            internal const string SaveBackupInfo = "Save-BackupInfo";
            internal const string FindSolrInstances = "Find-SolrInstances";
            public const string TestSolrEndpoint = "Test-SolrEndpoint";
            internal const string GetDrives = "Get-Drives";
            internal const string GetFiles = "Get-Files";
            internal const string GetHashMD5 = "Get-HashMD5";
        }

        public static class Files
        {
            public static string ModuleManifest => Path.Combine(Settings.Folders.Module, "Sifon.psd1");
            public static string ModuleDefinition => Path.Combine(Settings.Folders.Module, "Sifon.psm1");
            public static string GetInstanceUrl => Combine(Functions.GetInstanceUrl);
            public static string DownloadResourceScript => Combine(Functions.DownloadResource);
            public static string DownloadResourceJson => Combine(Functions.DownloadResource, "json");
            public static string InstallSitecorePackage => Combine(Functions.InstallSitecorePackage);
            public static string InstallSitecorePackageAspx => Combine(Functions.InstallSitecorePackage, "aspx");
            public static string CopyFileToRemote => Combine(Functions.CopyFileToRemote);
            public static string VerifyPortalCredentials => Combine(Functions.VerifyPortalCredentials);
            public static string GetConnectionString => Combine(Functions.GetConnectionString);
            public static string InstallSitecorePackageUsingRemoting => Combine(Functions.InstallSitecorePackageUsingRemoting);

            //TODO: Finish with others
            public static string GetSiteFolder => Combine(Functions.GetSiteFolder);
            public static string GetBindings => Combine(Functions.GetBindings);
            public static string GetSitecoreSites => Combine(Functions.GetSitecoreSites);
            public static string GetDatabases => Combine(Functions.GetDatabases);
            public static string GetCommerceDatabases => Combine(Functions.GetCommerceDatabases);
            public static string TestPortalCredentials => Combine(Functions.TestPortalCredentials);
            public static string TestSqlServerConnection => Combine(Functions.TestSqlServerConnection);
            public static string ExtractBackupInfo => Combine(Functions.ExtractBackupInfo);
            public static string SaveBackupInfo => Combine(Functions.SaveBackupInfo);
            public static string FindSolrInstances => Combine(Functions.FindSolrInstances);
            public static string TestSolrEndpoint => Combine(Functions.TestSolrEndpoint);
            public static string GetDrives => Combine(Functions.GetDrives);
            public static string GetFiles => Combine(Functions.GetFiles);
            public static string GetHashMD5 => Combine(Functions.GetHashMD5);

            private static string Combine(string moduleParam, string ext = null)
            {
                return Path.Combine(Settings.Folders.Module, $"{moduleParam}.{ext?? "ps1"}");
            }
        }

        public static string[] ToBeCopiedToRemote => new[]{

            Files.ModuleManifest,
            Files.ModuleDefinition,
            Files.GetInstanceUrl,
            Files.DownloadResourceScript,
            Files.DownloadResourceJson,
            Files.InstallSitecorePackage,
            Files.InstallSitecorePackageAspx,
            Files.CopyFileToRemote,
            Files.VerifyPortalCredentials,
            Files.GetConnectionString,
            Files.InstallSitecorePackageUsingRemoting,

            Files.GetSiteFolder,
            Files.GetBindings,
            Files.GetSitecoreSites,
            Files.GetDatabases,
            Files.GetCommerceDatabases,
            Files.TestPortalCredentials,
            Files.TestSqlServerConnection,
            Files.ExtractBackupInfo,
            Files.SaveBackupInfo,
            Files.FindSolrInstances,
            Files.TestSolrEndpoint,
            Files.GetDrives,
            Files.GetFiles,
            Files.GetHashMD5
        };
    }
}
