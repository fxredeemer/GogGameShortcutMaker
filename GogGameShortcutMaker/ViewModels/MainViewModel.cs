using Caliburn.Micro;
using GogGameShortcutMaker.Properties;
using GogGameShortcutMaker.Tools;

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
        private bool scanning;

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
        public bool Scanning
        {
            get => scanning;
            private set
            {
                scanning = value;
                NotifyOfPropertyChange();
            }
        }
        public IGameListViewModel GameList { get; }
        public IConfigurationViewModel Configuration { get; }

        public void Handle(string message)
        {
            switch (message)
            {
                case NotificationConstants.ConfigurationDone:
                    settings.Reload();
                    NotifyOfPropertyChange(nameof(ConfigurationDone));
                    break;
                case NotificationConstants.ScanningStarted:
                    Scanning = true;
                    break;
                case NotificationConstants.ScanningDone:
                    Scanning = false;
                    break;
            }
        }

        public void Configure()
        {
            settings.ConfigurationFinished = false;
            settings.Save();

            NotifyOfPropertyChange(nameof(ConfigurationDone));
        }
    }
}
