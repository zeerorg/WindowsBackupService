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
                throw new EntityExistsException();
            }
            directory.Create();
        }

        internal static string GetFolderName(string directory)
        {
            return new DirectoryInfo(directory).Name;
        }

        internal class EntityExistsException : Exception
        {
            internal EntityExistsException() { }
            internal EntityExistsException(string message) : base(message) { }
            internal EntityExistsException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
