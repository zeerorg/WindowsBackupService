using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupLib
{
    /// <summary>
    /// Class for dealing with all the entities realted to the backup
    /// This class is only created for backups that exist, i.e. the backup folder must exist
    /// </summary>
    public class BackupClass
    {
        string absPath;
        ZipUtil zip;
        CompFileUtil completedFile;

        /// <summary>
        /// The date when backup was created
        /// </summary>
        public DateTime CreatedOn
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of folder in "dd_MM_yyyy" frmat
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        public BackupClass(string absPath)
        {
            this.absPath = absPath;
            this.Name = DirectoryUtil.GetFolderName(this.absPath);
            this.zip = new ZipUtil(ZipUtil.GetZipFilePathFromFolder(this.absPath, this.Name));
            this.completedFile = new CompFileUtil(CompFileUtil.GetCompFilePathFromFolder(this.absPath, this.Name));
            this.CreatedOn = MiscHelper.StringToDate(this.Name);
        }

        internal void AddFileToZip(string filePath, string relativePath)
        {
            this.zip.AddFileToZip(filePath, relativePath);
        }

        internal void AddDoneFileEntry(string filePath)
        {
            this.completedFile.AddFile(filePath);
        }

        internal HashSet<string> GetCompletedEntries()
        {
            return this.completedFile.entries;
        }

        internal void UpdateFileEntries(HashSet<string> newEntries)
        {
            this.completedFile.UpdateFileEntries(newEntries);
        }

        internal void AddDirectoryEntry(string dirPath)
        {
            this.completedFile.AddDirectory(dirPath);
        }
    }
}
