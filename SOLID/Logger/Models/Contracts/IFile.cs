using System;
namespace ExLogger.Models.Contracts
{
    public interface IFile
    {
        // This path is to use IO C# sys.
        // Create, Read, Write, Delete.

        string Path { get; }

        // Size will show the size of the file.

        long Size { get; }

        string Write(ILayout layout, IError error);
    }
}
