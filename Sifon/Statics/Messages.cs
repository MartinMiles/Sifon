namespace Sifon.Statics
{
    public static class Messages
    {
        public static class Activities
        {
            public const string Backup = "Performing instance backup";
            public static string Remove = "Cleaning up instance. Removing website files and databases";
            public static string Restore = "Performing instance restore";
        }

        public static class General
        {
            public const string YesNoCaption = "Do you want to continue?";
            public const string Success = "Completed successfully";
        }

        public static class Startup
        {
            public static class PermissionRequest
            {
                public const string Caption = "Permission request";
                public const string Message = "You must run this application as administrator. \nDo you want to restart the application in administrator mode.";
            }
        }

        public static class Backup
        {
            public const string Failed = "Backup failed";
            public static class ConfirmDatabases
            {
                public const string Caption = "Databases not selected";
                public const string Message = "Selected instance contains databases, but none is selected for backup \nAre you sure you want like to progress without backing up databases?";
            }
        }

        public static class Remove
        {
            public const string Failed = "Remove failed";

            public static class ConfirmDatabases
            {
                public const string Caption = "Databases not selected";
                public const string Message = "Selected instance contains databases, but none is selected for removal \nDo you want to progress without removing databases?";
            }
        }

        public static class Restore
        {
            public const string Failed = "Restore failed";

            public const string RestoreTargetFound = "Found following website archives:";
            public const string RestoreTargetNotFound = "No website archives found";

            public const string DatabaseBackupsFound = "Found database backups:";
            public const string DatabaseBackupsNotFound = "Database backups to restore - NOT FOUND";

            public static class ConfirmDatabases
            {
                public const string Caption = "Databases not selected";
                public const string Message = "Selected instance contains databases, but none is selected for restore \nAre you sure you want to progress without restoring databases?";
            }
        }

        public static class Profiles
        {
            public const string ConfirmDeletingProfile = "Clicking Yes will delete selected profile";

            public static class Connectivity
            {
                public const string SolrDetectionInProgress = "PLEASE WAIT! Identifying Solr instance in progress:";
                public const string InitializationRequired = "Solr auto-identifier for remote is not available \nuntil you initialize remote endpoint";
                public const string InstancesFound = "The following Solr instance have been found:";
                public const string TestSolrCaption = "Test Solr Connection";
                public const string TestSolrSuccessful = "Successfully connected";

                public static class Errors
                {
                    public const string InstancesNotFound = "No Solr instance found";

                    public const string TestSolrFailed = "Failed to connect to provided URL";
                    public const string ProfileDamaged = "Remote profile damaged";
                    public const string RemoteFoldermissing = "Remote script or folder missing. \n\nPlease re-initialize remote profile \nfrom within Remote tab";
                }
            }
        }
        //public static class Errors
        //{
        //    public static class Main
        //    {
        //        public const string BackupInfoMissing = "BackupInfo.xml not found in archive";
        //    }
        //}

        public static class ProfileCredentials
        {
            public const string Caption = "Sitecore Portal Credentials Check";
            public const string Success = "The credential are valid and work well";

            public static class Errors
            {
                public const string NoResults = "The request did not return results";
                public const string IncorrectCredentials = "The credentials are not valid";
            }
        }

        public static class SqlSettings
        {
            public const string Caption = "SQL Server Connection";

            public static class Errors
            {
                public const string NoResults = "Query did not return results";
            }
        }
    }
}
