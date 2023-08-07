namespace Sifon.Code.Statics
{
    public static class Validation
    {   
        public static class InstallDatabase
        {
            public const string Instance = "Please provide valid SQL Express instance name";
            public const string Password = "Please provide valid password";
        }

        public static class InstallSolr
        {
            public const string Folder = "Please provide valid folder path to install into";
            public const string Port = "Please provide valid ports number";
        }

        public static class General
        {
            public const string ErrorsList = "The following error(s) occur:\n\n";
            public const string MessageBoxCapture = "Validation error";
            public const string ShouldNotBeEmpty = "should not be empty";
        }

        public static class Feedback
        {
            public const string Fullname = "Name is not in correct format";
            public const string Email = "Invalid email";
            public const string FeedbackMessage = "Feedback not in correct format";
        }

        public static class SettingsForm
        {
            public const string PluginsRepository = "Plugins repository shoud be located at GitHub\n";
        }
        public static class Profiles
        {
            public static class Profile
            {
                public const string Name = "Profile Name may contain only characters, numbers and limited number of other special symbols\n";
                public const string Prefix = "Profile Prefix may contain only characters, numbers, dots, dashes and underscores\n";
            }

            public static class Remote
            {
                public const string HostnameNotEmpty = "Remote host should not be empty\n";
                public const string UsernameNotEmpty = "Username should not be empty\n";
                public const string PasswordNotEmpty = "Password should not be empty\n";
                public const string FolderNotEmpty = "Remote folder should not be empty - intiazlize remote first\n";
            }

            public static class Parameters
            {
                public const string IncorrectParameterName = "is not correct parameter name\n";
                public const string NameAlreadyDefined = "isn't valid name as it's already defined by a profile specification\n";
                public const string DuplicatesNotAllowed = "Duplicate parameter names are not allowed\n";
            }
        }

        public static class SqlSettings
        {
            public const string Name = "Name should contain characters, numbers, dots, dashes and underscores\n";
            public const string Instance = "Instance can contain only letters, numbers, dots, dashes, parenthesis  and backslash\n";
            public const string Username = "Username should contain characters, numbers, dots, dashes and underscores\n";
            public const string Password = "Password should not contain whitespaces\n";
        }
        public static class PortalCredentials
        {
            public const string Username = "Username should be your email address registed with Sitecore\n";
            public const string Password = "Password should not contain whitespaces\n";
        }
        public static class DockerProfiles
        {
            public const string Name = "Profile name contains invalid characters\n";
            public const string RepositoryUrl = "Repository URl name contains invalid characters\n";
            public const string Folder= "Folder name contains invalid characters\n";
            public const string Password = "Password should not contain whitespaces\n";
        }

        public static class Backup
        {
            public const string DestinationFolderDoesNotExist = "Destination folder to put backup into does not exist\n";

        }

        public static class Restore
        {
            public const string SourceFolderDoesNotExist = "Source folder with backup does not exist\n";
        }
    }
}
