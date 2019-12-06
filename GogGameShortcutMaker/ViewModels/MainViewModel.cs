using Caliburn.Micro;
using GogGameShortcutMaker.Properties;

namespace GogGameShortcutMaker.ViewModels
{
    internal interface IMainViewModel
    {
        IGameListViewModel GameList { get; }
        IConfigurationViewModel Configuration { get; }
        bool ConfigurationDone { get; }
    }

    internal class MainViewModel : Screen, IHandle<string>, IMainViewModel
    {
        private readonly Settings settings;

        public MainViewModel(
            IGameListViewModel gameList,
            IConfigurationViewModel configuration,
            IEventAggregator eventAggregator,
            Settings settings)
        {
            GameList = gameList;
            Configuration = configuration;
            this.settings = settings;

            eventAggregator.Subscribe(this);
        }

        public bool ConfigurationDone => settings.ConfigurationFinished;
        public IGameListViewModel GameList { get; }
        public IConfigurationViewModel Configuration { get; }

        public void Handle(string message)
        {
            settings.Reload();

            NotifyOfPropertyChange(nameof(ConfigurationDone));
        }
    }
}
