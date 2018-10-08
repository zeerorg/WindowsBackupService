using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    public partial class MainService : ServiceBase
    {
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string backupFolder = ConfigUtil.GetBackupDirectory();
            CompressUtil dir = new CompressUtil(backupFolder);

            BackupClass backup = dir.GetLatestBackup();
            if ((DateTime.Now - backup.CreatedOn).TotalDays > 7)
            {
                backup = dir.CreateBackup();
            }

            List<string> dirsToBackup = ConfigUtil.GetDirectoriesToBackup();
        }

        protected override void OnStop()
        {
        }
    }
}
