using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupLib
{
    /// <summary>
    /// A utility to compress files and manipulate backup folder
    /// A backup = a folder by name dd_mm_yyyy which contains ".zip" and ".zip.comp"
    /// </summary>
    public class CompressUtil
    {
        private string BackupFolder;

        /// <summary>
        /// Constructor for CompressUtil class
        /// </summary>
        /// <param name="folder">The backup folder</param>
        public CompressUtil(string folder)
        {
            this.BackupFolder = folder;
            DirectoryUtil.CreateIfNotExist(folder);
        }

        /// <summary>
        /// Create a .zip and .zip.comp file inside the backup directory to be used for current backup
        /// </summary>
        /// <returns>Path of the zip file</returns>
        public BackupClass CreateBackup()
        {
            string date = MiscHelper.GetDateString();
            string absolutePath = Path.Combine(this.BackupFolder, date);

            // Create a directory if it does not exist
            DirectoryUtil.CreateOrThrow(absolutePath);

            // Create zip file
            ZipUtil.CreateOrThrow(ZipUtil.GetZipFilePathFromFolder(absolutePath, date));

            // Create comp file
            CompFileUtil.CreateOrThrow(Path.Combine(absolutePath, date + ".zip.comp.txt"));
            return new BackupClass(absolutePath);
        }

        /// <summary>
        /// Gets the latest backup
        /// </summary>
        /// <returns>Getting the latest backup</returns>
        public BackupClass GetLatestBackup()
        {
            IEnumerable<DirectoryInfo> backups = new DirectoryInfo(this.BackupFolder).EnumerateDirectories();

            if (backups.Count() == 0)
            {
                return this.CreateBackup();
            }

            return new BackupClass(backups
                    .Where(dir => MiscHelper.StringIsDate(dir.Name))
                    .OrderBy(dir => MiscHelper.StringToDate(dir.Name))
                    .Reverse()
                    .First()
                    .FullName);
        }
    }
}
