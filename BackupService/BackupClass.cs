using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    /// <summary>
    /// Class for dealing with all the entities realted to the backup
    /// This class is only created for backups that exist, i.e. the backup folder must exist
    /// </summary>
    internal class BackupClass
    {
        string AbsPath;
        string ZipFilePath;
        string ZipCompletedFilePath;

        /// <summary>
        /// The date when backup was created
        /// </summary>
        internal DateTime CreatedOn
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of folder in "dd_MM_yyyy" frmat
        /// </summary>
        internal string Name
        {
            get;
            private set;
        }

        internal BackupClass(string absPath)
        {
            this.AbsPath = absPath;
            this.Name = DirectoryUtil.GetFolderName(this.AbsPath);
            this.ZipFilePath = ZipUtil.GetZipFilePathFromFolder(this.AbsPath, this.Name);
            this.ZipCompletedFilePath = CompFileUtil.GetComFileFromFolder(this.AbsPath, this.Name);
            this.CreatedOn = MiscHelper.StringToDate(this.Name);
        }
    }
}
