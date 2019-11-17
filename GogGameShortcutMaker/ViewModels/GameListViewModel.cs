using Caliburn.Micro;
using GogGameShortcutMaker.Models;
using System.Collections.ObjectModel;

namespace GogGameShortcutMaker.ViewModels
{
    internal interface IGameListViewModel
    {
        ObservableCollection<IGameViewModel> Games { get; }

        void Scan();
    }

    internal class GameListViewModel : Screen, IGameListViewModel
    {
        private readonly IRepository repository;
        private readonly IScanner scanner;

        public GameListViewModel(
            IRepository repository,
            IScanner scanner)
        {
            this.repository = repository;
            this.scanner = scanner;
        }

        public void Scan()
        {
            scanner.ScanForGames();

            foreach (var game in repository.Games)
            {
                Games.Add(new GameViewModel(game));
            }
        }

        public ObservableCollection<IGameViewModel> Games { get; } = new ObservableCollection<IGameViewModel>();
    }
}
