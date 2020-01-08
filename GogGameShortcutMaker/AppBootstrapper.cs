using Caliburn.Micro;
using GogGameShortcutMaker.Models;
using GogGameShortcutMaker.Tools;
using GogGameShortcutMaker.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GogGameShortcutMaker
{
    public class AppBootstrapper : BootstrapperBase
    {
        private IKernel kernel;

        public AppBootstrapper()
        {
            var parser = new GameInfoParser();
            var shortcutMaker = new DesktopShortcutMaker();

            var gameInfo = parser.ParseGameInfo(@"D:\Morrowind\goggame-1435828767.info");
            shortcutMaker.MakeShortcut(gameInfo);

            Initialize();
        }

        protected override void Configure()
        {
            kernel = new StandardKernel();

            kernel.Bind<IScanner>().To<Scanner>();
            kernel.Bind<IGameInfoParser>().To<GameInfoParser>();
            kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
            
            kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();

            kernel.Bind<IGameListViewModel>().To<GameListViewModel>();
            kernel.Bind<IConfigurationViewModel>().To<ConfigurationViewModel>();
            kernel.Bind<IMainViewModel>().To<MainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            return kernel.Get(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            kernel.Inject(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            kernel.Dispose();
            base.OnExit(sender, e);
        }
    }
}
