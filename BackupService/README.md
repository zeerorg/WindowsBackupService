# Windows Backup Service
## How to install:
1. Clone the project and Build it using Visual Studio 2017
2. Open "Developer Command Prompt for VS 2017" in Administrator mode.
3. Go to the project directory and then to "bin\Debug" there will be the build project.
4. Paste this folder path in Command Prompt from Step 2.
5. Install using `installutil.exe BackupService.exe`
6. Uninstall using `installutil.exe /u BackupService.exe`