using System;
using System.IO;

namespace Sifon.UK.Website.Services
{
    public class FeedbackService
    {
        private const string FolderToSave = @"Data\Feedback";
        private readonly string _rootDirectory;

        public FeedbackService(string rootDirectory)
        {
            _rootDirectory = rootDirectory;
        }

        public void SaveToFile(string[] linesToSave)
        {
            var feedbackFilePath = GetFullPath();
            File.WriteAllLines(feedbackFilePath, linesToSave);
        }

        private string GetFullPath()
        {
            var directory = new DirectoryInfo(_rootDirectory + FolderToSave);
            if (!directory.Exists)
            {
                directory = Directory.CreateDirectory(directory.FullName);
            }

            string file = DateTime.Now.ToString("yyyy-MM-dd H.mm.ss");
            return Path.Combine(directory.FullName, file);
        }
    }
}