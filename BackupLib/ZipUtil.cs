using System.IO;
using System.IO.Compression;

namespace BackupLib
{
    /// <summary>
    /// A utility class for dealing with Zip files
    /// </summary>
    internal class ZipUtil
    {
        private string filePath;

        internal ZipUtil(string filePath)
        {
            this.filePath = filePath;
        }

        internal void AddFileToZip(string _filePath, string relativePath)
        {
            using (var fileStream = new FileStream(this.filePath, FileMode.Open))
            {
                using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    zipArchive.CreateEntryFromFile(_filePath, relativePath, CompressionLevel.NoCompression);
                }
            }
        }

        static internal void CreateOrThrow(string filePath)
        {
            if (File.Exists(filePath))
            {
                throw new MiscHelper.EntityExistsException();
            }
            File.Create(filePath);
        }

        static internal string GetZipFilePathFromFolder(string folder, string date)
        {
            return Path.Combine(folder, date + ".zip");
        }
    }
}
