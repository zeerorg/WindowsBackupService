using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    /// <summary>
    /// A utility class for dealing with Zip files
    /// </summary>
    internal class ZipUtil
    {
        private string FilePath;
        internal ZipUtil(string filePath)
        {
            this.FilePath = filePath;
        }

        static internal void CreateOrThrow(string filePath)
        {
            if (File.Exists(filePath))
            {
                throw new DirectoryUtil.EntityExistsException();
            }
            File.Create(filePath);
        }

        static internal string GetZipFilePathFromFolder(string folder, string date)
        {
            return Path.Combine(folder, date + ".zip");
        }
    }
}
