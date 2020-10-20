using System;
using System.Collections.Generic;
using System.IO;
using Sifon.Code.Helpers;

namespace Sifon.Code.Statics
{
    public static class Settings
    {
        public const string VersionNumber = "0.99";
        public static readonly string ProductVersion = $"Sifon v{VersionNumber} (BETA)";
        public const string BackupInfoFile = "BackupInfo.xml";
        public const string RemoteDirectory = "Sifon";

        internal static class Services
        {
            internal const string MarketingAutomation = "MarketingAutomationService";
            internal const string IndexWorker = "IndexWorker";
            internal const string ProcessingEngineService = "ProcessingEngineService";
        }

        internal static class Process
        {
            internal const string MarketingAutomationEngine = "Sitecore.MAEngine";
            internal const string Indexer = "Sitecore.XConnectSearchIndexer";
            internal const string ProcessingEngine = "Sitecore.ProcessingEngine";
            internal const string PublishingHost = "Sitecore.Framework.Publishing.Host";
        }

        public static class Folders
        {
            public static string Cache = Path.Combine(Environment.CurrentDirectory, "Cache");
            public static string Profiles => Path.Combine(Environment.CurrentDirectory, "Settings");
            public static string Plugins => Path.Combine(Environment.CurrentDirectory, Settings.Plugins.Directory);
            public static string Core => Path.Combine(Environment.CurrentDirectory, "PowerShell\\Core");
            public static string Module => Path.Combine(Environment.CurrentDirectory, Modules.Directory);
        }

        public static class Plugins
        {
            public const string Directory = "Sifon.Plugins";
        }

        internal static class SettingsFolder
        {
            internal static string ProfilesPath = Path.Combine(Folders.Profiles, "Profiles.xml");
            internal static string ContainersPath = Path.Combine(Folders.Profiles, "Containers.xml");
            internal static string SqlProfilesPath = Path.Combine(Folders.Profiles, "SQL.xml");
            internal static string SettingsPath = Path.Combine(Folders.Profiles, "Settings.xml");
        }

        internal static class Regex
        {
            internal static class Metacode
            {
                public const string Name = @"^###\s*(?i)Name(?-i):\s*(.*)$";
                public const string Description = @"^###\s*(?i)Description(?-i):\s*(.*)$";
                public const string Compatibility = "###\\s*Compatibility:\\s*Sifon\\s(\\d\\.\\d{2})";
                public const string ExecutableFunction = "###\\s*(\\$\\w*)\\s*=\\s*new\\s*(.*)::(.*)\\(((\"?[^\"]*\"?)*)\\)";
                public const string Parameter = @"\""[^[\]]*\""";
                //public const string Dependencies = "###\\s*Dependencies:\\s*(.*)";
                public const string DependenciesToExtract = "\\\"([^\"]*)\\\"";
            }
        }

        public static class Scripts
        {
            public static class Remote
            {
                public static string Initialize => Path.Combine(Folders.Core, "Initialize-Remote.ps1");
            }
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
            public const string Change = "Change";
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

        public static class Sites
        {
            public static string[] Commerce = {"Authoring", "Ops", "Shops", "Minions", "BizFx"};
        }

        public static class CotainerParameters
        {
            public const string SaPassword = "SaPassword";
        }

        public static class Parameters
        {
            // from profile
            public const string Name = "Name";
            public const string Prefix = "Prefix";
            public const string AdminUsername = "AdminUsername";
            public const string AdminPassword = "AdminPassword";
            public const string Website = "Website";
            public const string Webroot = "Webroot";
            public const string Solr = "Solr";
            public const string ServerInstance = "ServerInstance";
            public const string InstancePrefix = "InstancePrefix";
            public const string SqlCredentials = "SqlCredentials";
            public const string PortalCredentials = "PortalCredentials";

            //from containers
            public const string ProfileName = "ProfileName";
            public const string Repository = "Repository";

            public const string Folder = "Folder";

            //public const string AdminPassword = "AdminPassword";

            //public const string InstanceFolder = "instanceFolder";

            // from the forms: backup-remove-restore
            //public const string InstanceName = "instanceName";
            public const string TargetFolder = "targetFolder";
            public const string Databases = "databases";
            public const string Activity = "activity";

            public const string XConnect = "XConnect";
            public const string IdentityServer = "IdentityServer";
            public const string Horizon = "Horizon";
            public const string HorizonFolder = "HorizonFolder";
            public const string PublishingService = "PublishingService";
            public const string PublishingServiceFolder = "PublishingServiceFolder";
            public const string XConnectFolder = "XConnectFolder";
            public const string IdentityServerFolder = "IdentityServerFolder";

            public const string Hostname = "Hostname";
            public const string Type = "type";

            //todo: check if the below correct - and move out unwanted
            public static Dictionary<string, string> AsDictionary()
            {
                return StaticsHelper.AsDictionary(typeof(Parameters));
            }
        }
        
        public static class Initialize
        {
            public const string ProgressActivityName = "Initializing remote";
        }
    }
}