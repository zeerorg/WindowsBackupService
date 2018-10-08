using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    class FileToBackup
    {
        string filePath;
        BackupClass backup;
        string relativePath;

        internal FileToBackup(string filePath, string relativePath, BackupClass backup)
        {
            this.filePath = filePath;
            this.relativePath = relativePath;
            this.backup = backup;
        }

        internal void StartBackup()
        {
            this.backup.AddFileToZip(this.filePath, this.relativePath);
        }

        internal void DoneBackup()
        {
            this.backup.AddDoneFileEntry(this.filePath);
        }
    }
}
