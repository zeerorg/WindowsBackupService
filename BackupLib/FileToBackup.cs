using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupLib
{
    class FileToBackup
    {
        string filePath;
        FileInfo file;
        BackupClass backup;
        string relativePath;

        internal FileToBackup(string filePath, string relativePath, BackupClass backup)
        {
            this.filePath = filePath;
            this.file = new FileInfo(filePath);
            this.relativePath = Path.Combine(relativePath, this.file.Name);
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
