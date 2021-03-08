using System;
using System.IO;

namespace Sifon.Code.Statics
{
    public static class Folders
    {
        public static string Logs = Path.Combine(Environment.CurrentDirectory, DirectoryName.Logs);
        public static string Cache = Path.Combine(Environment.CurrentDirectory, DirectoryName.Cache);
        public static string Profiles => Path.Combine(Environment.CurrentDirectory, DirectoryName.Settings);
        public static string Plugins => Path.Combine(Environment.CurrentDirectory, DirectoryName.Plugins);
        public static string PowerShell => Path.Combine(Environment.CurrentDirectory, DirectoryName.PowerShell);
        public static string Module => Path.Combine(Environment.CurrentDirectory, DirectoryName.Module);

        public static class DirectoryName
        {
            internal const string Logs = "Logs";
            internal const string Cache = "Cache";
            internal const string Settings = "Settings";
            internal const string PowerShell = "PowerShell";
            internal const string Module = "PowerShell\\Module";
            public const string Plugins = "Sifon.Plugins";
        }

        internal static class SettingsFolder
        {
            internal static string ProfilesPath = Path.Combine(Profiles, "Profiles.xml");
            internal static string ContainersPath = Path.Combine(Profiles, "Containers.xml");
            internal static string SqlProfilesPath = Path.Combine(Profiles, "SQL.xml");
            internal static string SettingsPath = Path.Combine(Profiles, "Settings.xml");
        }

        public static class LogsFolder
        {
            public const string LogFilenamePrefix = "SifonLog_";
        }

        //TODO: move to other file consts?
        public static class Scripts
        {
            public static string InitializeRemote => Path.Combine(PowerShell, "Initialize-Remote.ps1");
        }
    }
}
