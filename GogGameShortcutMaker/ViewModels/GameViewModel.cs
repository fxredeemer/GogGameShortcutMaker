using GogGameShortcutMaker.Models;
using GogGameShortcutMaker.Tools;

namespace GogGameShortcutMaker.ViewModels
{
    internal interface IGameViewModel
    {
        string Name { get; }
        string Path { get; }

        void MakeShortcut();
    }

    internal class GameViewModel : IGameViewModel
    {
        private readonly IGamePathInfo game;
        private readonly IGameInfoParser gameInfoParser;
        private readonly IDesktopShortcutMaker desktopShortcutMaker;

        public GameViewModel(
            IGamePathInfo game,
            IGameInfoParser gameInfoParser,
            IDesktopShortcutMaker desktopShortcutMaker)
        {
            this.game = game;
            this.gameInfoParser = gameInfoParser;
            this.desktopShortcutMaker = desktopShortcutMaker;
        }

        public string Name => game.Name;

        public string Path => game.Path;

        public void MakeShortcut()
        {
            var gameInfo = gameInfoParser.ParseGameInfo(Path);
            desktopShortcutMaker.MakeShortcut(gameInfo);
        }
    }
}
