using System;
namespace ExLogger.Models.Contracts
{
    public interface IPathManager
    {
        // bin/debug
        string CurrentDirectoryPath { get; }

        // bin/debug/logfile.txt
        string CurrentFilePath { get; }

        // tells were app is running on the pc 
        string GetCurrentPath();

        // Ensure directory is valid.
        void EnsureDirectoryAndFileExists();


    }
}
