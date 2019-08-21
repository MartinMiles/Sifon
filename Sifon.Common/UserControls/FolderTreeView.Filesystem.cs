using System;
using System.Collections.Generic;
using System.IO;

namespace Ex_TreeView
{
    public partial class FolderTreeView
    {
        public string GetDirectoryInfo(string folderPath)
        {
            DirectoryInfo rootDir;

            Char[] arr = { '\\' };
            string[] nameList = folderPath.Split(arr);
            string path = "";

            if (nameList.GetValue(0).ToString() == "Desktop")
            {
                path = SpecialDirectories.Desktop + "\\";

                for (int i = 1; i < nameList.Length; i++)
                {
                    path = path + nameList[i] + "\\";
                }

                rootDir = new DirectoryInfo(path);
            }
            else
            {
                rootDir = new DirectoryInfo(folderPath + "\\");
            }

            return rootDir.FullName;
        }

        public IEnumerable<string> GetDirectories(string directoryPath)
        {
            return GetFilesystemObjects(directoryPath, "Directory");
        }

        public IEnumerable<string> GetFiles(string directoryPath)
        {
            return GetFilesystemObjects(directoryPath, "File");
        }

        private IEnumerable<string> GetFilesystemObjects(string directoryPath, string parameter)
        {
            string script = $@"ls -{parameter} {directoryPath} |  ForEach-Object {{ $_.Name }}";
            return _simpleRunner.Execute<string>(script);
        }
    }
}
