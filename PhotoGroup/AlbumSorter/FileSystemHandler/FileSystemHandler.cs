namespace AlbumSorter.FileSystemHandler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileSystemHandler : IFileSystemHandler
    {
        private DirectoryInfo _dirInfo;
        private string _photoDir;

        public void CreateFolder(string folderNameToCreate)
        {
            this._dirInfo.CreateSubdirectory(folderNameToCreate);
        }

        public IEnumerable<string> GetAllImagePaths()
        {
            return GetFilesByExtensions(this._dirInfo, new string[] { ".jpg", ".jepg" });
        }

        public static IEnumerable<string> GetFilesByExtensions(DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
            {
                throw new ArgumentNullException("extensions");
            }
            return (from x in dir.EnumerateFiles()
                where extensions.Contains<string>(x.Extension.ToLower())
                select x.FullName);
        }

        public void Initialize(string photoDirectoryPath)
        {
            this._photoDir = photoDirectoryPath;
            this._dirInfo = new DirectoryInfo(photoDirectoryPath);
        }

        public void MoveToDestination(string sourceFileInfo, string folderNameToCreate)
        {
            File.Move(sourceFileInfo, new DirectoryInfo(new FileInfo(sourceFileInfo).DirectoryName + @"\" + folderNameToCreate) + @"\" + new FileInfo(sourceFileInfo).Name);
        }
    }
}

