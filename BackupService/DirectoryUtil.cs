using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    class DirectoryUtil
    {
        private DirectoryUtil() { }

        internal static void CreateIfNotExist(string dir)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        internal static void CreateOrThrow(string dir)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            if (directory.Exists)
            {
                throw new MiscHelper.EntityExistsException();
            }
            directory.Create();
        }

        internal static string GetFolderName(string directory)
        {
            return new DirectoryInfo(directory).Name;
        }
    }
}
