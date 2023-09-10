using Sifon.Abstractions.Profiles;
using System.Collections.Generic;
using System.IO;

namespace Sifon.Code.Statics
{
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
            public const string AdminUsername = "AdminUsername";
            public const string AdminPassword = "AdminPassword";
            public const string Webroot = "Webroot";
            public const string Website = "Website";
            public const string Solr = "Solr";
            public const string SqlServer = "SqlServer";
            public const string Parameters = "AdditionalParameters";
            public const string Parameter = "Parameter";

            public const string IsXM = "IsXM";
            public const string XConnectSiteName = "XConnectSiteName";
            public const string XConnectSiteRoot = "XConnectSiteRoot";
            public const string CDSiteName = "CDSiteName";
            public const string CDSiteRoot = "CDSiteRoot";
        }

        public static class ContainerProfile
        {
            public const string NodeListName = "containers";
            public const string NodeName = "profile";

            public const string ProfileName = "ProfileName";
            public const string Repository = "Repository";
            public const string Folder = "Folder";
            public const string SitecoreAdminPassword = "SitecoreAdminPassword";
            public const string SaPassword = "SaPassword";
            public const string InitializeScript = "InitializeScript";
            public const string Notes = "Notes";
        }

        public static class SettingRecord
        {
            public const string NodeListName = "settings";

            public const string PortalUsername = "PortalUsername";
            public const string PortalPassword = "PortalPassword";
            public const string UseDownloadCDN = "UseDownloadCDN";
            public const string SendCrashDetails = "SendCrashDetails";
            public const string PluginsRepository = "PluginsRepository";
            public const string CustomPluginsFolder = "CustomPluginsFolder";
            public const string AlignVersions = "AlignVersions";
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
            public static string FilePath => Path.Combine(Folders.Cache, "BackupInfoFile.xml");

            public const string NodeName = "backup";
            public const string Webroot = "Webroot";
            public const string SitecoreInstance = "SitecoreInstance";
        }
    }
}
