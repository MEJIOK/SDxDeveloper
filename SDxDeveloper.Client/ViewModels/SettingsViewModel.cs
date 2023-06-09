namespace SDxDeveloper.Client.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public string? DefaultFileExplorePath
        {
            get => Properties.Settings.Default.DefaultFileExplorePath;
            set => Properties.Settings.Default.DefaultFileExplorePath = value;
        }

        public bool ExportPreserveWhitespace
        {
            get => Properties.Settings.Default.ExportPreserveWhitespace;
            set => Properties.Settings.Default.ExportPreserveWhitespace = value;
        }

        public string SiteTargetPath1
        {
            get => Properties.Settings.Default.SiteTargetPath1;
            set => Properties.Settings.Default.SiteTargetPath1 = value;
        }

        public string SiteTargetPath2
        {
            get => Properties.Settings.Default.SiteTargetPath2;
            set => Properties.Settings.Default.SiteTargetPath2 = value;
        }
    }
}
