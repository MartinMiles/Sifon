using System.Collections.Generic;
using Sifon.Code.Helpers;

namespace Sifon.Code.Statics
{
    public static class Settings
    {
        public const string VersionNumber = "1.2.5";
        public static readonly string ProductVersion = $"Sifon v{VersionNumber}";
        public const string BackupInfoFile = "BackupInfo.xml";
        public const string RemoteDirectory = "Sifon";
        public const string PluginRepository = "https://github.com/MartinMiles/Sifon.Plugins.git";
        
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

        internal static class Regex
        {
            internal static class Metacode
            {
                public const string Name = @"^###\s*(?i)Name(?-i):\s*(.*)$";
                public const string Description = @"^###\s*(?i)Description(?-i):\s*(.*)$";
                public const string Compatibility = "###\\s*Compatibility:\\s*Sifon\\s(\\d\\.\\d\\.\\d)";
                public const string DisplayLocalOnly = "###\\s?Display:\\s?Local";
                public const string ExecuteLocalOnly = "###\\s?Execution:\\s?Local";
                public const string RequiresProfile = "###\\s?Requires\\sProfile:\\s?(\\w+)";
                
                public const string ExecutableFunction = "###\\s*(\\$\\w*)\\s*=\\s*new\\s*(.*)::(.*)\\(((\"?[^\"]*\"?)*)\\)";
                public const string Parameter = @"\""[^[\]]*\""";
                //public const string Dependencies = "###\\s*Dependencies:\\s*(.*)";
                public const string DependenciesToExtract = "\\\"([^\"]*)\\\"";
                public const string FunctionParametersToExtract = "(?:^|,\\s*)(\\\"(?:[^\\\"])*\\\"|[^,]*)";
            }
        }

        public const string ManualEntry = "== enter manually ==";
        public const string ProfileNotCreated = "Profile not created";

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

        public static class ContainerParameters
        {
            public const string SaPassword = "SaPassword";
            public const string InitParams = "InitParams";
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
            public const string PluginsRepository = "PluginsRepository";
            public const string VersionBranch = "VersionBranch";
            public const string IsRemote = "IsRemote";
            public const string UseDownloadCDN = "UseDownloadCDN";

            //Solr installer
            public const string SolrVersion = "Version";
            public const string SolrHostname = "Hostname";
            public const string SolrPort = "Port";
            public const string SolrFolder = "Folder"; 
            public const string SolrUninstall = "Uninstall"; 

            //from containers
            public const string ContainerProfileName = "ContainerProfileName";
            public const string Repository = "Repository";
            public const string SitecoreAdminPassword = "SitecoreAdminPassword";

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

        public static class Api
        {
#if DEBUG
            public const string HostBase = "http://beta.Sifon.UK";
#else
            public const string HostBase = "https://Sifon.UK";
#endif
            public const string Feedback = "api/Feedback";
            public const string SendException = "api/Exception";
            public const string UpdateVersion = "/download/version.json";
        }
    }
}