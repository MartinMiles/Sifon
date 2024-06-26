﻿using System.IO;

namespace Sifon.Code.Statics
{
    public static class Modules
    {
        public static class Functions
        {
            internal const string GetInstanceUrl = "Get-InstanceUrl";
            internal const string DownloadResource = "Download-Resource";
            public const string InstallDownloadSitecore = "Install-DownloadSitecore";
            public const string InstallPrerequisitesForSitecore = "Install-PrerequisitesForSitecore";
            public const string InstallSitecore = "Install-Sitecore";
            internal const string InstallSitecorePackage = "Install-SitecorePackage";
            internal const string CopyFileToRemote = "Copy-FileToRemote";
            internal const string VerifyPortalCredentials = "Verify-PortalCredentials";
            internal const string GetConnectionString = "Get-ConnectionString";
            internal const string InstallSitecorePackageUsingRemoting = "Install-SitecorePackageUsingRemoting";
            internal const string GetSiteFolder = "Get-SiteFolder";
            internal const string GetBindings = "Get-Bindings";
            internal const string GetSitecoreSites = "Get-SitecoreSites";
            public const string GetDatabases = "Get-Databases";
            internal const string GetCommerceDatabases = "Get-CommerceDatabases";
            public const string TestPortalCredentials = "Test-PortalCredentials";
            public const string TestSqlServerConnection = "Test-SqlServerConnection";
            internal const string ExtractBackupInfo = "Extract-BackupInfo";
            internal const string SaveBackupInfo = "Save-BackupInfo";
            internal const string FindSolrInstances = "Find-SolrInstances";
            internal const string FindIndexes = "Find-Indexes";
            public const string TestSolrEndpoint = "Test-SolrEndpoint";
            internal const string GetDrives = "Get-Drives";
            internal const string GetFiles = "Get-Files";
            internal const string GetHashMD5 = "Get-HashMD5";
            public const string CheckPrerequisites = "Check-Prerequisites";
            public const string InstallPrerequisites = "Install-Prerequisites";
            public const string ShowMessage = "Show-Message";
            public const string ShowProgress = "Show-Progress";
            public const string VerifyGit = "Verify-Git";
            public const string VerifyNetCore = "Verify-NetCore";
            public const string InstallModuleFromGithub = "Install-ModuleFromGithub";
            public const string InstallSolr = "Install-Solr";
            public const string InstallDatabaseServer = "Install-SQLServer";
            public const string ReadUrlContent = "Read-UrlContent";
            public const string GetIdentityToken = "Get-IdentityToken";
        }
        
        public static class Files
        {
            public const string Installer = "_deploy_to_modules.ps1";

            public static string ModuleManifest => Path.Combine(Folders.Module, "Sifon.psd1");
            public static string ModuleDefinition => Path.Combine(Folders.Module, "Sifon.psm1");
            public static string GetInstanceUrl => Combine(Functions.GetInstanceUrl);
            public static string DownloadResourceScript => Combine(Functions.DownloadResource);
            public static string DownloadResourceJson => Combine(Functions.DownloadResource, "json");
            public static string InstallDownloadSitecore => Combine(Functions.InstallDownloadSitecore);
            public static string InstallPrerequisitesForSitecore => Combine(Functions.InstallPrerequisitesForSitecore);
            public static string InstallSitecore => Combine(Functions.InstallSitecore);
            public static string InstallSitecorePackage => Combine(Functions.InstallSitecorePackage);
            public static string InstallSitecorePackageAspx => Combine(Functions.InstallSitecorePackage, "aspx");
            public static string CopyFileToRemote => Combine(Functions.CopyFileToRemote);
            public static string VerifyPortalCredentials => Combine(Functions.VerifyPortalCredentials);
            public static string GetConnectionString => Combine(Functions.GetConnectionString);
            public static string InstallSitecorePackageUsingRemoting => Combine(Functions.InstallSitecorePackageUsingRemoting);
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
            public static string FindIndexes => Combine(Functions.FindIndexes);
            public static string TestSolrEndpoint => Combine(Functions.TestSolrEndpoint);
            public static string GetDrives => Combine(Functions.GetDrives);
            public static string GetFiles => Combine(Functions.GetFiles);
            public static string GetHashMD5 => Combine(Functions.GetHashMD5);
            public static string CheckPrerequisites => Combine(Functions.CheckPrerequisites);
            public static string InstallPrerequisites => Combine(Functions.InstallPrerequisites);
            public static string ShowMessage => Combine(Functions.ShowMessage);
            public static string ShowProgress => Combine(Functions.ShowProgress);
            public static string VerifyGit => Combine(Functions.VerifyGit);
            public static string VerifyNetCore => Combine(Functions.VerifyNetCore);
            public static string InstallModuleFromGithub => Combine(Functions.InstallModuleFromGithub);
            public static string InstallSolr => Combine(Functions.InstallSolr);
            public static string ReadUrlContent => Combine(Functions.ReadUrlContent);
            public static string GetIdentityToken => Combine(Functions.GetIdentityToken);
            public static string InstallSqlServer => Combine(Functions.InstallDatabaseServer);

            private static string Combine(string moduleParam, string ext = null)
            {
                return Path.Combine(Folders.Module, $"{moduleParam}.{ext?? "ps1"}");
            }
        }

        public static string[] ToBeCopiedToRemote => new[]{

            Files.ModuleManifest,
            Files.ModuleDefinition,
            Files.GetInstanceUrl,
            Files.DownloadResourceScript,
            Files.DownloadResourceJson,
            Files.InstallSitecore,
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
            Files.FindIndexes,
            Files.TestSolrEndpoint,
            Files.GetDrives,
            Files.GetFiles,
            Files.GetHashMD5,
            Files.CheckPrerequisites,
            Files.InstallPrerequisites,
            Files.ShowMessage,
            Files.ShowProgress,
            Files.VerifyGit,
            Files.VerifyNetCore,
            Files.InstallModuleFromGithub,
            Files.InstallSolr,
            Files.ReadUrlContent,
            Files.GetIdentityToken,
            Files.InstallSqlServer
        };
    }
}
