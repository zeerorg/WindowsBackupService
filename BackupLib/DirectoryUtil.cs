using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupLib
{
    public class DirectoryUtil
    {
        private DirectoryUtil() { }

        public static void CreateIfNotExist(string dir)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        public static void CreateOrThrow(string dir)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            if (directory.Exists)
            {
                throw new MiscHelper.EntityExistsException();
            }
            directory.Create();
        }

        public static string GetFolderName(string directory)
        {
            return new DirectoryInfo(directory).Name;
        }
    }
}
