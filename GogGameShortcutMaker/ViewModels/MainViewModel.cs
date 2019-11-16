using Caliburn.Micro;
using GogGameShortcutMaker.Models;
using System.Collections.ObjectModel;

namespace GogGameShortcutMaker.ViewModels
{
    internal interface IMainViewModel
    {
        ObservableCollection<IGameViewModel> Games { get; }
    }

    internal class MainViewModel : Screen, IMainViewModel
    {
        private readonly IRepository repository;
        private readonly IScanner scanner;

        public MainViewModel(IRepository repository, IScanner scanner)
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
