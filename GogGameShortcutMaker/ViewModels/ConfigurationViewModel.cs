using Caliburn.Micro;
using GogGameShortcutMaker.Properties;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Linq;
using Ookii.Dialogs.Wpf;

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
        private List<string> gamePaths = new List<string>();

        public ConfigurationViewModel(Settings settings)
        {
            this.settings = settings;

            LoadSettings();
        }


        private void LoadSettings()
        {
            if (settings.GamePaths == null)
            {
                settings.GamePaths = new StringCollection();
            }

            gamePaths = settings.GamePaths.Cast<string>().ToList();
        }

        public void SelectGogInstallationPath()
        {
            var fileSelector = new VistaOpenFileDialog
            {
                Filter = "*.exe|*.exe"
            };

            if (fileSelector.ShowDialog() == true)
            {
                InstallationPath = fileSelector.FileName;
                NotifyOfPropertyChange(nameof(InstallationPath));
            }
        }

        public void AddPath()
        {
            var folderSelector = new VistaFolderBrowserDialog();
            
            if (folderSelector.ShowDialog() == true)
            {
                gamePaths.Add(folderSelector.SelectedPath);
                NotifyOfPropertyChange(nameof(GamePaths));
            }
        }

        public void RemovePath(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && sender is string path)
            {
                gamePaths.Remove(path);
                NotifyOfPropertyChange(nameof(GamePaths));
            }
        }

        public ObservableCollection<string> GamePaths => new ObservableCollection<string>(gamePaths);

        public string InstallationPath
        {
            get => settings.InstallationPath;
            set => settings.InstallationPath = value;
        }
    }
}
