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
        private readonly IGameViewModelFactory gameViewModelFactory;

        public GameListViewModel(
            IRepository repository,
            IScanner scanner,
            IEventAggregator eventAggregator,
            IGameViewModelFactory gameViewModelFactory)
        {
            this.repository = repository;
            this.scanner = scanner;
            this.eventAggregator = eventAggregator;
            this.gameViewModelFactory = gameViewModelFactory;
        }

        public async void Scan()
        {
            eventAggregator.BeginPublishOnUIThread(NotificationConstants.ScanningStarted);

            await scanner.ScanForGames().ConfigureAwait(true);

            eventAggregator.BeginPublishOnUIThread(NotificationConstants.ScanningDone);

            foreach (var game in repository.Games)
            {
                Games.Add(gameViewModelFactory.CreateGameViewModel(game));
            }
        }

        public ObservableCollection<IGameViewModel> Games { get; } = new ObservableCollection<IGameViewModel>();
    }
}
