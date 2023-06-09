using SDxDeveloper.Client.Properties;
using SDxDeveloper.Client.State;
using SDxDeveloper.Client.ViewModels;
using SDxDeveloper.Services.API;
using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace SDxDeveloper.Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                new MainWindow { DataContext = new MainViewModel() }.Show();
                using var fp = new FileStream("usersettings.xml", FileMode.Open, FileAccess.Read);
                UserSettings? settings = new XmlSerializer(typeof(UserSettings)).Deserialize(fp) as UserSettings;
                Settings.Default.DefaultFileExplorePath = settings?.DefaultFileExplorePath;
                Settings.Default.ExportPreserveWhitespace = settings != null && settings.ExportPreserveWhitespace;
                Settings.Default.SiteTargetPath1 = settings?.SiteTargetPath1;
                Settings.Default.SiteTargetPath2 = settings?.SiteTargetPath2;
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
                    SiteTargetPath2 = Settings.Default.SiteTargetPath2
                }
            );
            base.OnExit(e);
        }
    }
}
