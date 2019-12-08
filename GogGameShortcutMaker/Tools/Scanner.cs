using GogGameShortcutMaker.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GogGameShortcutMaker.Models
{
    internal interface IScanner
    {
        void ScanForGames();
    }

    internal class Scanner : IScanner
    {
        private readonly IRepository repository;
        private readonly IGameInfoParser gameInfoParser;

        public Scanner(
            IRepository repository,
            IGameInfoParser gameInfoParser)
        {
            this.repository = repository;
            this.gameInfoParser = gameInfoParser;
        }

        public void ScanForGames()
        {
            foreach (string path in Settings.Default.GamePaths)
            {
                var directory = new DirectoryInfo(path);
                var readableFolders = GetDirectoriesRecursive(directory);

                var infoFiles = readableFolders.SelectMany(d => d.GetFiles("gog*.info")).ToList();

                foreach (var infoFile in infoFiles)
                {
                    string filePath = infoFile.FullName;
                    repository.Games.Add(new GamePathInfo(gameInfoParser.ParseGameInfo(filePath), filePath));
                }
            }
        }

        public IEnumerable<DirectoryInfo> GetDirectoriesRecursive(DirectoryInfo directory)
        {
            var subDirectories = new List<DirectoryInfo>();

            foreach (var subDir in directory.GetDirectories())
            {
                if (!subDir.Attributes.HasFlag(FileAttributes.Hidden)
                    && !subDir.Attributes.HasFlag(FileAttributes.System)
                    && !subDir.Attributes.HasFlag(FileAttributes.ReadOnly))
                {
                    try
                    {
                        subDirectories.AddRange(GetDirectoriesRecursive(subDir));
                        subDirectories.Add(subDir);
                    }
                    catch (UnauthorizedAccessException) { }
                }
            }

            return subDirectories;
        }
    }
}
