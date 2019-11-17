using Caliburn.Micro;
using GogGameShortcutMaker.Models;
using GogGameShortcutMaker.Properties;
using System.Collections.ObjectModel;

namespace GogGameShortcutMaker.ViewModels
{
    internal interface IMainViewModel
    {
        IGameListViewModel GameList { get; }
        IConfigurationViewModel Configuration { get; }
    }

    internal class MainViewModel : Screen, IMainViewModel
    {
        private readonly Settings settings;

        public MainViewModel(
            IGameListViewModel gameList, 
            IConfigurationViewModel configuration,
            Settings settings)
        {
            GameList = gameList;
            Configuration = configuration;
            this.settings = settings;
        }

        public bool ConfigurationDone => settings.ConfigurationFinished;
        public IGameListViewModel GameList { get; }
        public IConfigurationViewModel Configuration { get; }
    }
}
