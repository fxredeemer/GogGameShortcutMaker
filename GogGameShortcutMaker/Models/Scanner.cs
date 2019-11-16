using System.IO;
using System.Linq;

namespace GogGameShortcutMaker.Models
{
    internal interface IScanner
    {
        void ScanForGames();
    }

    class Scanner : IScanner
    {
        private readonly IRepository repository;

        public Scanner(IRepository repository)
        {
            this.repository = repository;
        }


        public void ScanForGames()
        {
            var path = @"D:\";

            var directory = new DirectoryInfo(path);
            var readableFolders = directory.GetDirectories()
                .Where(d =>
                    !d.Attributes.HasFlag(FileAttributes.Hidden)
                    && !d.Attributes.HasFlag(FileAttributes.System)
                    && !d.Attributes.HasFlag(FileAttributes.ReadOnly));

            var infoFiles = readableFolders.SelectMany(d => d.GetFiles("gog*.info", SearchOption.AllDirectories));

            foreach (var infoFile in infoFiles)
            {
                repository.Games.Add(new Game(infoFile.Name, infoFile.FullName));
            }
        }
    }
}
