using System;
using System.Collections.Generic;
using System.IO;
using Sifon.Shared.Helpers;

namespace Sifon.Shared.Statics
{
    public static class Settings
    {
        public const string ProductVersion = "Sifon v0.9.6 (BETA)";
        public const string BackupInfoFile = "BackupInfo.xml";
        public const string RemoteDirectory = "Sifon";

        public static class Services
        {
            public const string MarketingAutomation = "MarketingAutomationService";
            public const string IndexWorker = "IndexWorker";
            public const string ProcessingEngineService = "ProcessingEngineService";
        }

        public static class Process
        {
            public const string MarketingAutomationEngine = "Sitecore.MAEngine";
            public const string Indexer = "Sitecore.XConnectSearchIndexer";
            public const string ProcessingEngine = "Sitecore.ProcessingEngine";
        }

        public static class Folders
        {
            public static string Cache = Path.Combine(Environment.CurrentDirectory, "Cache");
            public static string Profiles => Path.Combine(Environment.CurrentDirectory, "Settings");
            public static string Plugins => Path.Combine(Environment.CurrentDirectory, "Sifon.Plugins");
            public static string Core => Path.Combine(Environment.CurrentDirectory, "PowerShell\\Core");
            public static string Module => Path.Combine(Environment.CurrentDirectory, "PowerShell\\Module");
            public static string CoreFilesystem => Path.Combine(Core, "Filesystem");
        }

        public static class CacheFolder
        {
            public static string BackupInfo => Path.Combine(Folders.Cache, "BackupInfoFile.xml");
        }

        public static class ProfilesFolder
        {
            public static string ProfilesPath = Path.Combine(Folders.Profiles, "Profiles.xml");
            public static string SqlProfilesPath = Path.Combine(Folders.Profiles, "SQL.xml");
            public static string SettingsPath = Path.Combine(Folders.Profiles, "Settings.xml");
        }

        public static class Scripts
        {
            public static string InitializeRemote => Path.Combine(Folders.Core, "Initialize-Remote.ps1");
            public static string CopyToRemote => Path.Combine(Folders.Core, "Copy-ScriptToRemote.ps1");

            public static string RetrieveDatabases => Path.Combine(Folders.Core, "Get-Databases.ps1");
            public static string TestSolr => Path.Combine(Folders.Core, "Test-Solr.ps1");
            public static string RetrieveSolr => Path.Combine(Folders.Core, "Get-Solr.ps1");
            public static string RestoreInstance => Path.Combine(Folders.Core, "Restore-Instance.ps1");
            public static string TestSqlServerConnection => Path.Combine(Folders.Core, "Test-SqlServerConnection.ps1");
            public static string TestPortalCredentials => Path.Combine(Folders.Core, "Test-PortalCredentials.ps1");
            public static string GetSitecoreSites => Path.Combine(Folders.Core, "Get-SitecoreSites.ps1");
            public static string GetSiteBindings => Path.Combine(Folders.Core, "Get-SiteBindings.ps1");
            public static string GetSiteBindingsByPath => Path.Combine(Folders.Core, "Get-SiteBindingsByPath.ps1");
            public static string GetBackupInfo => Path.Combine(Folders.Core, "Get-BackupInfo.ps1");
            public static string SaveBackupInfo => Path.Combine(Folders.Core, "Save-BackupInfo.ps1");
            public static string GetSitePath => Path.Combine(Folders.Core, "Get-SitePath.ps1");
            public static string GetXconnectFolder => Path.Combine(Folders.Core, "Get-XconnectFolder.ps1");
            public static string GetCommerceSites => Path.Combine(Folders.Core, "Get-CommerceSites.ps1");
            public static string GetCommerceDatabases => Path.Combine(Folders.Core, "Get-CommerceDatabases.ps1");

            // When adding new script to here, consider adding them to Sifon.Forms.Initialize.InitRemotePresenter.FilesToBeCopiedToRemote if needed

            public static class Filesystem
            {
                public static string GetFiles => Path.Combine(Folders.CoreFilesystem, "Get-Files.ps1");
                public static string CreateDirectory => Path.Combine(Folders.CoreFilesystem, "Create-Directory.ps1");   
                public static string VerifyDirectory => Path.Combine(Folders.CoreFilesystem, "Verify-Directory.ps1");   
                public static string RenameDirectory => Path.Combine(Folders.CoreFilesystem, "Rename-Directory.ps1");   
                public static string DeleteDirectory => Path.Combine(Folders.CoreFilesystem, "Delete-Directory.ps1");
                public static string DeleteFile => Path.Combine(Folders.CoreFilesystem, "Delete-File.ps1");
                public static string GetDrives => Path.Combine(Folders.CoreFilesystem, "Get-Drives.ps1");
                public static string GetDirectory => Path.Combine(Folders.CoreFilesystem, "Get-Directory.ps1");
            }

            public static class Module
            {
                public static string ModuleManifest => Path.Combine(Folders.Module, "Sifon.psd1");
                public static string ModuleDefinition => Path.Combine(Folders.Module, "Sifon.psm1");
                public static string GetInstanceUrl => Path.Combine(Folders.Module, "Get-InstanceUrl.ps1");
                public static string DummyFunction => Path.Combine(Folders.Module, "Dummy-Function.ps1");
            }

        }
        public static class Files
        {
            public static string DefaultProfileName = "Habitat sample website";
            public static string DefaultProfilePrefix = "Habitat";
        }

        public const string ManualEntry = "== enter manually ==";

        public static class Labels
        {
            public const string Reveal = "reveal";
            public const string Hide = "hide";
        }

        public static class Profiles
        {
            public static class Parameters
            {
                public const string KeyPrefix = "key";
                public const string ValPrefix = "val";
            }
        }

        public static class Buttons
        {
            public const string Add = "Add";
            public const string Rename = "Rename";
            public const string SaveAndClose = "Save and close";

            public const string Backup = "Backup";
            public const string Restore = "Restore";
            public const string Loading = "Loading ...";
        }

        public static class Dropdowns
        {
            public const string NotSet = "== not set ==";
            public const string AddNewProfile = "== add new profile ==";
            public const string AddNewServer = "== add new server ==";
        }

        public static class Databases
        {
            public static string[] ForbiddenDatabases = {"master", "tempdb", "model", "msdb"};
        }

        public static class XConnect
        {
            public const string ConfigRelativePath = @"App_Config\ConnectionStrings.config";
            public const string NodePath = "/connectionStrings/add[@name='xconnect.collection']";
            public const string AttributeName = "connectionString";
        }

        public static class IDS
        {
            public const string ConfigRelativePath = @"App_Config\Sitecore\Owin.Authentication.IdentityServer\Sitecore.Owin.Authentication.IdentityServer.config";
            public static string NodePath = "/configuration/sitecore/sc.variable[@name='identityServerAuthority']";
            public const string AttributeName = "value";
        }

        public static class Parameters
        {
            // from profile
            public const string Name = "Name";
            public const string Prefix = "Prefix";
            public const string Website = "Website";
            public const string Webroot = "Webroot";
            public const string Solr = "Solr";
            public const string ServerInstance = "ServerInstance";
            public const string InstancePrefix = "InstancePrefix";
            public const string Username = "Username";
            public const string Password = "Password";
            public const string PortalCredentials = "PortalCredentials";

            //public const string InstanceFolder = "instanceFolder";

            // from the forms: backup-remove-restore
            //public const string InstanceName = "instanceName";
            public const string TargetFolder = "targetFolder";
            public const string Databases = "databases";
            public const string Activity = "activity";

            public const string XConnect = "XConnect";
            public const string IdentityServer = "IdentityServer";
            public const string XConnectFolder = "XConnectFolder";
            public const string IdentityServerFolder = "IdentityServerFolder";

            public const string Hostname = "Hostname";
            public const string ConfigRelativePath = "ConfigRelativePath";
            public const string XPath = "XPath";
            public const string AttributeName = "AttributeName";
            public const string By = "By";
            
            public static Dictionary<string, string> AsDictionary()
            {
                return StaticsHelper.AsDictionary(typeof(Parameters));
            }
        }

        public static class Xml
        {
            public static class Attributes
            {
                public const string Name = "name";
                public const string Value = "value";
                public const string Empty = "empty";
                public const string RemotingEnabled = "remoting";
                public const string Selected = "selected";
            }

            public static class Profile
            {
                public const string NodeListName = "profiles";
                public const string NodeName = "profile";

                public const string RemoteExecutionHost = "RemoteExecutionHost";
                public const string RemoteUsername = "RemoteUsername";
                public const string RemotePassword = "RemotePassword";
                public const string RemoteFolder = "RemoteFolder";
                public const string Name = "Name";
                public const string Prefix = "Prefix";
                public const string Webroot = "Webroot";
                public const string Website = "Website";
                public const string Solr = "Solr";
                public const string SqlServer = "SqlServer";
                public const string Parameters = "AdditionalParameters";
                public const string Parameter = "Parameter";
            }

            public static class SettingRecord
            {
                public const string NodeListName = "settings";

                public const string PortalUsername = "PortalUsername";
                public const string PortalPassword = "PortalPassword";
            }

            public static class SqlServerRecord
            {
                public const string NodeListName = "servers";

                public const string NodeName = "server";

                public const string RecordName = "Name";
                public const string SqlServer = "SqlServer";
                public const string SqlAdminUsername = "SqlAdminUsername";
                public const string SqlAdminPassword = "SqlAdminPassword";
            }

            public static class Backup_Info
            {
                public const string NodeName = "backup";
                public const string Webroot = "Webroot";
                public const string SitecoreInstance = "SitecoreInstance";
            }
        }

        public static class Initialize
        {
            public const string ProgressActivityName = "Initializing remote";
        }
    }
}
