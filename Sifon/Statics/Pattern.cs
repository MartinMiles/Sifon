namespace Sifon.Statics
{
    public static class Pattern
    {
        public const string ColorPattern = @"#COLOR:(\w{2,12})# *";

        public static class Profile
        {
            public const string Name = @"^^[A-Za-z0-9-+()@ .,_]*$";
            public const string Prefix = @"^[A-Za-z0-9-._]*$";
        }
        public static class SqlSettings
        {
            public const string Name = @"^[A-Za-z0-9-._]*$";
            public const string Instance = @"^[\\(\\)A-Za-z0-9-._]*$";
            public const string Username = @"^[A-Za-z0-9-._]*$";
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
                    public const string Underscores = @"[^\w\d_]";
                    
                    /// <summary>
                    /// Works for SQL Server record name.
                    /// </summary>
                    public const string DotsDashes = @"[^\w\d.-]";

                    /// <summary>
                    /// Works for SQL Server instance.
                    /// </summary>
                    public const string DotsDashesParenthesesBackslash = @"[^\\(\\)\w\d\\\\.-]";
                }
            }
        }
    }
}
