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

        public GameViewModel(IGamePathInfo game)
        {
            this.game = game;
        }

        public string Name => game.Name;

        public string Path => game.Path;

        public void MakeShortcut()
        {
            var parser = new GameInfoParser();
            var gameInfo = parser.ParseGameInfo(Path);



            System.Console.WriteLine("Whazzup");
        }
    }
}
