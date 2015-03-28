namespace AlbumSorter.FileSystemHandler
{
    using System;
    using System.Collections.Generic;

    public interface IFileSystemHandler
    {
        void CreateFolder(string folderNameToCreate);
        IEnumerable<string> GetAllImagePaths();
        void Initialize(string photoDirectoryPath);
        void MoveToDestination(string sourceFileInfo, string folderNameToCreate);
    }
}

