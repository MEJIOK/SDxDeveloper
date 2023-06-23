using Microsoft.Extensions.DependencyInjection;
using SDxDeveloper.Client.Properties;
using SDxDeveloper.Client.Services;
using SDxDeveloper.Client.State;
using SDxDeveloper.Client.State.Navigators;
using SDxDeveloper.Client.ViewModels;
using SDxDeveloper.Client.Views.Windows;
using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace SDxDeveloper.Client
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();

            services.AddSingleton(s => CreateHomeNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            services.AddTransient(s => new HomeViewModel());
            services.AddTransient(s => new SettingsViewModel());

            services.AddTransient(CreateNavigationBarViewModel);
            services.AddTransient<MainViewModel>();
            
            services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<MainViewModel>() });

            _serviceProvider = services.BuildServiceProvider();
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
            => new LayoutNaviationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());

        private INavigationService CreateSettingsNavigationService(IServiceProvider serviceProvider)
            => new LayoutNaviationService<SettingsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<SettingsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
            => new NavigationBarViewModel(CreateHomeNavigationService(serviceProvider),
                CreateSettingsNavigationService(serviceProvider));

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);

            try
            {
                using var fp = new FileStream("usersettings.xml", FileMode.Open, FileAccess.Read);
                UserSettings? settings = new XmlSerializer(typeof(UserSettings)).Deserialize(fp) as UserSettings;
                Settings.Default.DefaultFileExplorePath = settings?.DefaultFileExplorePath;
                Settings.Default.ExportPreserveWhitespace = settings != null && settings.ExportPreserveWhitespace;
                Settings.Default.SiteTargetPath1 = settings?.SiteTargetPath1;
                Settings.Default.SiteTargetPath2 = settings?.SiteTargetPath2;
                Settings.Default.OAuthToken = settings?.OAuthToken;
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException ioex)
                {
                    MessageBox.Show(ioex.Message, ioex.TargetSite?.Name.ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            using var fp = new FileStream("usersettings.xml", FileMode.Create, FileAccess.Write);
            new XmlSerializer(typeof(UserSettings)).Serialize(fp, new UserSettings
                { 
                    DefaultFileExplorePath = Settings.Default.DefaultFileExplorePath,
                    ExportPreserveWhitespace = Settings.Default.ExportPreserveWhitespace,
                    SiteTargetPath1 = Settings.Default.SiteTargetPath1,
                    SiteTargetPath2 = Settings.Default.SiteTargetPath2,
                    OAuthToken = Settings.Default.OAuthToken
                }
            );
            base.OnExit(e);
        }
    }
}
