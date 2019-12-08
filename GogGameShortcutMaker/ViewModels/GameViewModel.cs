using GogGameShortcutMaker.Models;

namespace GogGameShortcutMaker.ViewModels
{
    internal interface IGameViewModel
    {
        string Name { get; }
        string Path { get; }

        void MakeShortcut();
    }

    class GameViewModel : IGameViewModel
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
            System.Console.WriteLine("Whazzup");
        }
    }
}
