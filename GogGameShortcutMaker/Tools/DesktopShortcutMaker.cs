using GogGameShortcutMaker.Models;
using GogGameShortcutMaker.Properties;
using IWshRuntimeLibrary;
using System;
using System.IO;

namespace GogGameShortcutMaker.Tools
{
    interface IDesktopShortcutMaker
    {
        void MakeShortcut(GameInfo gameInfo);
    }

    class DesktopShortcutMaker : IDesktopShortcutMaker
    {
        public void MakeShortcut(GameInfo gameInfo)
        {
            var galaxyPath = Settings.Default.InstallationPath;

            var startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var shell = new WshShell();
            var sanitizedName = SanitizePath(gameInfo.Name);
            var shortCutLinkFilePath = $@"{startupFolderPath}\{sanitizedName}.lnk";

            var windowsApplicationShortcut = (IWshShortcut)shell.CreateShortcut(shortCutLinkFilePath);
            windowsApplicationShortcut.WorkingDirectory = Path.GetDirectoryName(galaxyPath);
            windowsApplicationShortcut.Arguments = $@"/command=runGame /gameId={gameInfo.GameId} /path=""{gameInfo.Path}""";
            windowsApplicationShortcut.TargetPath = galaxyPath;
            windowsApplicationShortcut.IconLocation = gameInfo.Icon ?? windowsApplicationShortcut.IconLocation;
            windowsApplicationShortcut.Save();
        }

        private static string SanitizePath(string path)
        {
            var invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (var c in invalidChars)
            {
                path = path.Replace(c.ToString(), "");
            }

            return path;
        }
    }
}
