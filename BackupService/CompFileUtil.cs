using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    /// <summary>
    /// Class for dealing with ".zip.comp.txt" file
    /// It is a text file which tells how much the backup has completed
    /// </summary>
    class CompFileUtil
    {
        internal static void CreateOrThrow(string filePath)
        {
            if (File.Exists(filePath))
            {
                throw new DirectoryUtil.EntityExistsException();
            }
            File.Create(filePath);
        }

        internal static string GetComFileFromFolder(string folder, string date)
        {
            return Path.Combine(folder, date + ".zip.comp.txt");
        }
    }
}
