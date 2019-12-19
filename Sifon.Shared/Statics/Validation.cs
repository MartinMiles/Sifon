namespace Sifon.Shared.Statics
{
    public static class Validation
    {
        public static class General
        {
            public const string ErrorsList = "The following error(s) occur:\n\n";
            public const string MessageBoxCapture = "Validation error";
            public const string ShouldNotBeEmpty = "should not be empty";
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
