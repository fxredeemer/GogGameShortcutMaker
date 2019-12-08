using Caliburn.Micro;
using GogGameShortcutMaker.Models;
using GogGameShortcutMaker.Tools;
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
        private readonly IEventAggregator eventAggregator;

        public GameListViewModel(
            IRepository repository,
            IScanner scanner,
            IEventAggregator eventAggregator)
        {
            this.repository = repository;
            this.scanner = scanner;
            this.eventAggregator = eventAggregator;
        }

        public async void Scan()
        {
            eventAggregator.BeginPublishOnUIThread(NotificationConstants.ScanningStarted);
            
            await scanner.ScanForGames();

            eventAggregator.BeginPublishOnUIThread(NotificationConstants.ScanningDone);

            foreach (var game in repository.Games)
            {
                Games.Add(new GameViewModel(game));
            }
        }

        public ObservableCollection<IGameViewModel> Games { get; } = new ObservableCollection<IGameViewModel>();
    }
}
