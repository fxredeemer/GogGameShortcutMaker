using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GogGameShortcutMaker.Models;
using GogGameShortcutMaker.Properties;
using IWshRuntimeLibrary;

namespace GogGameShortcutMaker.Tools
{
    class DesktopShortcutMaker
    {
        public void MakeShortcut(GameInfo gameInfo)
        {
            var galaxyPath = Settings.Default.InstallationPath;


            var startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var shell = new WshShell();
            //var shortCutLinkFilePath = $@"{startupFolderPath}\{ gameInfo.Name}.lnk";
            var shortCutLinkFilePath = $@"{startupFolderPath}\AAAAAAAAAAAAAAAa.lnk";

            var windowsApplicationShortcut = (IWshShortcut)shell.CreateShortcut(shortCutLinkFilePath);
            windowsApplicationShortcut.Description = $"{gameInfo.Name}";
            windowsApplicationShortcut.WorkingDirectory = galaxyPath;
            windowsApplicationShortcut.TargetPath = gameInfo.Path;
            windowsApplicationShortcut.RelativePath = gameInfo.Name;
            windowsApplicationShortcut.Save();
        }
    }
}
