using Caliburn.Micro;
using GogGameShortcutMaker.Properties;
using System.Collections.ObjectModel;

namespace GogGameShortcutMaker.ViewModels
{
    internal interface IConfigurationViewModel
    {
        ObservableCollection<string> GamePaths { get; }
        string InstallationPath { get; set; }

        void AddPath();
        void SelectGogInstallationPath();
    }

    internal class ConfigurationViewModel : Screen, IConfigurationViewModel
    {
        private readonly Settings settings;

        public ConfigurationViewModel(Settings settings)
        {
            this.settings = settings;
        }

        public ObservableCollection<string> GamePaths
        {
            get
            {
                var paths = new ObservableCollection<string>();
                foreach (string gamePath in settings.GamePaths)
                {
                    paths.Add(gamePath);
                }
                return paths;
            }
        }

        public void SelectGogInstallationPath()
        {

        }

        public void AddPath()
        {

        }

        public void RemovePath()
        {

        }

        public string InstallationPath
        {
            get => settings.InstallationPath;
            set => settings.InstallationPath = value;
        }

    }
}
