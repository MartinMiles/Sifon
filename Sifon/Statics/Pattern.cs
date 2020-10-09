using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace Sifon.Statics
{
    internal static class Pattern
    {
        public const string ColorPattern = @"#COLOR:(\w{2,12})# *";

        public static class DockerProfile
        {
            public const string Name = @"^[A-Za-z0-9-+()@ .,_]*$";
            public const string RepositoryUrl = @"^(([^:/?#]+):)?(//([^/?#]*))?([^?#]*)(\?([^#]*))?(#(.*))?";
            public const string Folder = @"^[A-Za-z0-9-._]*$";
            public const string Password = @"[^\ ]";
        }
        public static class Profile
        {
            public const string Name = @"^[A-Za-z0-9-+()@ .,_]*$";
            public const string Prefix = @"^[A-Za-z0-9-._]*$";
            public const string AdminUsername = @"^[A-Za-z0-9-._]*$";
            public const string AdminPassword = @"[^\ ]";
        }
        public static class SqlSettings
        {
            public const string Name = @"^[A-Za-z0-9-._]*$";
            public const string Instance = @"^[\\(\\)A-Za-z0-9-._]*$";
            public const string Username = @"^[A-Za-z0-9-._]*$";
            public const string Password = @"[^\ ]";
        }

        public static class PortalCredentials
        {
            public const string Username = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
            public const string Password = @"[^\ ]";
        }


        public static class PowerShell
        {
            public const string ParameterName = @"^[a-zA-Z$_][a-zA-Z0-9$_]*$";
        }

        public static class Filter
        {
            /// <summary>
            /// Works for passwords
            /// </summary>
            public const string Whitespaces = @"[\ ]";
            
            public static class SpecialCharacters
            {
                public const string All = @"[^\w\d]";

                public static class Except
                {
                    /// <summary>
                    /// Works for PowerShell parameter name.
                    /// </summary>
                    public const string ForbiddenInURL = @"[<>\{\}\\]";
                    
                    /// <summary>
                    /// Works for PowerShell parameter name.
                    /// </summary>
                    public const string Underscores = @"[^\w\d_]";
                    
                    /// <summary>
                    /// Works for profile prefix.
                    /// </summary>
                    public const string DotsDashes = @"[^\w\d.-]";
                                        
                    /// <summary>
                    /// Works for SQL Server record name.
                    /// </summary>
                    public const string DotsDashesSpaces = @"[^\w\d .-]";
                    
                    /// <summary>
                    /// Works for email name.
                    /// </summary>
                    public const string DotsDashesAmpersand = @"[^\w\d.-@]";

                    /// <summary>
                    /// Works for SQL Server instance.
                    /// </summary>
                    public const string DotsDashesParenthesesBackslash = @"[^\\(\\)\w\d\\\\.-]";

                    /// <summary>
                    /// Works for profile name.
                    /// </summary>
                    public const string ProfileNameDisallowed = @"[^\w\d. \\(\\)+@,-]";
                }
            }
        }
    }
}
