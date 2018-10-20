using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BackupLib;

namespace BackupService
{
    public partial class MainService : ServiceBase
    {
        public MainService()
        {
            InitializeComponent();
        }

        private static void Main(CompressUtil dir)
        {
            BackupClass backup = dir.GetLatestBackup();
            if ((DateTime.Now - backup.CreatedOn).TotalDays > 7)
            {
                backup = dir.CreateBackup();
            }

            List<string> dirsToBackup = new List<string>(ConfigurationManager.AppSettings["DirectoriesToBackup"].Split(';'));
            foreach (var dirPath in dirsToBackup)
            {
                DirToBackup dirToBackup = new DirToBackup(dirPath, DirectoryUtil.GetFolderName(dirPath), backup);
                dirToBackup.StartBackup();
                dirToBackup.DoneBackup();
            }
        }

        protected override void OnStart(string[] args)
        {
#if DEBUG
            Thread.Sleep(30000);
#endif
            string backupFolder = ConfigurationManager.AppSettings["BackupFolder"];
            CompressUtil dir = new CompressUtil(backupFolder);

            var mainThread = new Thread(new ThreadStart(() => Main(dir)));
            mainThread.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
