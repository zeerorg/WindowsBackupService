using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackupLib
{
    /// <summary>
    /// Class for dealing with ".zip.comp.txt" file
    /// It is a text file which tells how much the backup has completed
    /// </summary>
    class CompFileUtil
    {
        string filePath;

        internal HashSet<string> entries
        {
            get;
            private set;
        }

        internal CompFileUtil(string _filePath)
        {
            this.filePath = _filePath;
            entries = new HashSet<string>();
            bool done = false;
            while (!done)
            {
                Thread.Sleep(10);
                try
                {
                    foreach (var line in File.ReadAllLines(_filePath))
                    {
                        entries.Add(line);
                    }
                    done = true;
                }
                catch (IOException)
                {
                    done = false;
                }   
            }
        }

        internal void AddFile(string _filePath)
        {
            File.AppendAllText(this.filePath, _filePath + Environment.NewLine);
            entries.Add(_filePath);
        }

        internal void UpdateFileEntries(HashSet<string> newEntries)
        {
            string tempFile = Path.GetTempFileName();

            foreach (var line in File.ReadLines(this.filePath))
            {
                if(newEntries.Contains(line))
                    File.AppendAllText(tempFile, line + Environment.NewLine);
            }

            File.Delete(this.filePath);
            File.Move(tempFile, this.filePath);
            entries = newEntries;
        }

        internal void AddDirectory(string dirPath)
        {
            File.AppendAllText(this.filePath, dirPath + Environment.NewLine);
            entries.Add(dirPath);
        }

        internal static void CreateOrThrow(string _filePath)
        {
            if (File.Exists(_filePath))
            {
                throw new MiscHelper.EntityExistsException();
            }
            File.Create(_filePath);
        }

        internal static string GetCompFilePathFromFolder(string folder, string date)
        {
            return Path.Combine(folder, date + ".zip.comp.txt");
        }
    }
}
