using System;
using System.IO;

using ExLogger.Models.Contracts;

namespace ExLogger.Models.PathManagment
{
    public class PathManager : IPathManager
    {
        //private const string PATH_DELIMITER = "/";
        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        // Tells were the app is running.
        private PathManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        // Folder name and file name should be entered.

        public PathManager(string folderName, string fileName) : this()
        {
            this.fileName = fileName;
            this.folderName = folderName;
        }

        public string CurrentDirectoryPath => Path.Combine(this.currentPath, this.folderName);

        public string CurrentFilePath => Path.Combine(this.CurrentDirectoryPath, this.fileName);

        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.AppendAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
