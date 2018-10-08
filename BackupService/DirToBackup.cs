using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    /// <summary>
    /// A class that represents a directory that needs to be backed up
    /// </summary>
    class DirToBackup
    {
        DirectoryInfo dir;
        BackupClass backup;
        string relativePath;

        internal DirToBackup(string dirPath, string prevDirPath, BackupClass backup)
        {
            this.dir = new DirectoryInfo(dirPath);
            this.relativePath = Path.Combine(prevDirPath, this.dir.Name);
            this.backup = backup;
            if(!dir.Exists)
            {
                throw new MiscHelper.EntityNotFoundException();
            }
        }

        internal void StartBackup()
        {
            foreach (string subDirPath in dir.EnumerateDirectories().OrderBy(dir => dir.Name).Select(dir => dir.FullName))
            {
                DirToBackup subDir = new DirToBackup(subDirPath, this.relativePath, this.backup);
                subDir.StartBackup();
                subDir.DoneBackup();
            }

            foreach (string filePath in dir.EnumerateFiles().OrderBy(file => file.Name).Select(file => file.FullName))
            {
                FileToBackup fileBackup = new FileToBackup(filePath, this.relativePath, this.backup);
                fileBackup.StartBackup();
                fileBackup.DoneBackup();
            }
        }

        internal void DoneBackup()
        {
            HashSet<string> completed = this.backup.GetCompletedEntries();
            HashSet<string> newEntries = new HashSet<string>(completed.Where(entry => !File.GetAttributes(entry).HasFlag(FileAttributes.Directory)));
            this.backup.UpdateFileEntries(newEntries);
            this.backup.AddDirectoryEntry(this.dir.FullName);
        }
    }
}
