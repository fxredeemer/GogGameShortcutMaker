using GogGameShortcutMaker.Models;
using GogGameShortcutMaker.Tools;

namespace GogGameShortcutMaker.ViewModels
{
    internal interface IGameViewModelFactory
    {
        IGameViewModel CreateGameViewModel(IGamePathInfo gamePathInfo);
    }

    internal class GameViewModelFactory : IGameViewModelFactory
    {
        private readonly IGameInfoParser gameInfoParser;
        private readonly IDesktopShortcutMaker desktopShortcutMaker;

        public GameViewModelFactory(
            IGameInfoParser gameInfoParser,
            IDesktopShortcutMaker desktopShortcutMaker)
        {
            this.gameInfoParser = gameInfoParser;
            this.desktopShortcutMaker = desktopShortcutMaker;
        }

        public IGameViewModel CreateGameViewModel(IGamePathInfo gamePathInfo)
        {
            return new GameViewModel(gamePathInfo, gameInfoParser, desktopShortcutMaker);
        }
    }
}
