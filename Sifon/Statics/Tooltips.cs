namespace Sifon.Statics
{
    internal static class Tooltips
    {
        public static class Main
        {
            public const string ProfilesDropdown = "Switches current profile. Navigate to Profiles from the upper menu in order to manage them";
            public const string StopButton = "Clicking this button will stop currently executing script at next available step";
            public const string ProgressBar = "Shows up progress of a currently running operation";
            public const string Output = "Use right mouse click in order to show context menu for more optons (copy, save, clean)";
        }

        public static class Profiles
        {
            public const string ProfilesDropdown = "Selects current profile, or allows adding a new one";
            public const string ProfileName = "User-friendly name of a profile, as it will be shown across the system";
            public const string Prefix = "This is Sitecore instance prefix for a selected profile";
            public const string RenameButton = "Adds new profile or renames already existing with provided name and prefix";
            public const string DeleteButton = "Deletes selected profile";
            public const string SqlServersDropdown = "Selects which SQL Server instance to use with a selected profile";
            public const string SqlConnectionButton = "Use this button for adding a new SQL Server instance or modifying existing one";
            public const string SolrDropdown = "Selects which Solr instance to use with a selected profile";
            public const string WebsitesDropdown = "Selects which IIS Website to use with a selected profile";
            public const string TextWebroot = "Webroot folder for a website selected above";
            public const string ListBindings = "These are all bindings assigned to a selected website (both HTTP and HTTPS)";

            public static class Remote
            {
                public const string EnableCheckbox = "Enabling this checkbox makes this profile executing in a context of remote machine, as provided by the below settings";
                public const string Hostname = "IP or hostname of remote machine that has WinRM enabled";
                public const string Username = "Username for remote machine that has WinRM enabled";
                public const string Password = "Password for remote machine that has WinRM enabled";
            }
            public static class Parameters
            {
                public const string DownloadLink = "This link prepares a ready-to-run script for you implementing all the mandatory and custon parameters\nJust write your business logic below!";
                public const string AddPair = "Clicking this button adds an new key-value pair line below, for you to add custom parameter name and its value";
            }
        }

        public static class SqlSettings
        {
            public const string ServersDropdown = "Select existing SQL Server or add a new one";
            public const string DeleteButton = "Deletes existing selected SQL Server";
            public const string TextName = "Our internal name of this SQL Server record";
            public const string TextInstance = "SQL Server instance name";
            public const string TextUsername = "SQL Server username";
            public const string TextPassword = "SQL Server password";
            public const string TestButton = "Tests SQL Server connection with given parameters";
            public const string SaveButton = "Once successfully tested, click this button to add / save the provided details";
        }
        public static class PortalCredentials
        {
            public const string TextUsername = "Your Sitecore Developer Portal username. It is an email you use for Sitecore certification";
            public const string TextPassword = "Your Sitecore Developer Portal password";
            public const string RevealLink = "Shows and hides your password";
            public const string TestButton = "Try your credentials to access Sitecore Developer Portal and see if that works";
            public const string SaveButton = "Once successfully tested, click this button to add / save the provided credentials";
        }

        public static class Backup
        {
            public const string DestinationFolder = "Backup will be stored into this folder";
            public const string SitecoreInstancesDropdown = "Select which Sitecore instance to backup";
            public const string Bindings = "All the bindings available for selected instance";
            public const string ListDatabases = "All the databases for selected instance\nSelect which you'd like to backup";
            public const string ButtonBackup = "Runs backup process \n Aconfirmation dialog will show backup plan and ask for a confirmation";
        }

        public static class Restore
        {
            public const string SourceFolder = "Folder that contains backup to be restored";
            public const string Webfolder = "Identifies webfrolder from a webroot backup, if available";
            public const string ListDatabases = "List of databases identified at selected backup folder, if available";
            public const string RestoreButton = "This button closes this dialog and runs restore process";
            public const string DestinationFolder = "A folder that was used for creating a backup of filesystem \nWebsite files will be restored into this deirectory";
        }

        public static class Remove
        {
            public const string InstancesDropdown = "Selects an instance of Sitecore to remove";
            public const string Webfolder = "Webfolder to be cleaned-up, if checkbox selected";
            public const string DatabasePrefixFilter = "Use this filter box to filter out only those databases prefixed by the provided value";
            public const string ListDatabases = "Databases to be deleted, if checkbox selected";
            public const string RemoveButton = "This button runs removal process after a confirmation dialog, stating what exactly will be removed";
        }
    }
}
