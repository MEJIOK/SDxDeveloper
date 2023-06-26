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
                Settings.Default.Site1_TargetPath = settings?.Site1_TargetPath;
                Settings.Default.Site2_TargetPath = settings?.Site2_TargetPath;
                Settings.Default.Site1_OAuthToken = settings?.Site1_OAuthToken;
                Settings.Default.Site2_OAuthToken = settings?.Site2_OAuthToken;
                Settings.Default.Site2_OAuthToken = settings?.Site1_HomeDirectory;
                Settings.Default.Site2_OAuthToken = settings?.Site2_HomeDirectory;
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
                    Site1_TargetPath = Settings.Default.Site1_TargetPath,
                    Site2_TargetPath = Settings.Default.Site2_TargetPath,
                    Site1_OAuthToken = Settings.Default.Site1_OAuthToken,
                    Site2_OAuthToken = Settings.Default.Site2_OAuthToken,
                    Site1_HomeDirectory = Settings.Default.Site1_HomeDirectory,
                    Site2_HomeDirectory = Settings.Default.Site2_HomeDirectory
                }
            );
            base.OnExit(e);
        }
    }
}
