using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    class ConfigUtil
    {
        private ConfigUtil() { }

        internal static string GetBackupDirectory()
        {
            return ConfigurationManager.AppSettings["BackupFolder"];
        }

        internal static List<string> GetDirectoriesToBackup()
        {
            return new List<string>(ConfigurationManager.AppSettings["DirectoriesToBackup"].Split(';'));
        }
    }
}
