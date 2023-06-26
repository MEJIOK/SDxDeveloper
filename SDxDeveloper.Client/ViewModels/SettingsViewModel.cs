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

        public string Site1_TargetPath
        {
            get => Properties.Settings.Default.Site1_TargetPath;
            set => Properties.Settings.Default.Site1_TargetPath = value;
        }

        public string Site2_TargetPath
        {
            get => Properties.Settings.Default.Site2_TargetPath;
            set => Properties.Settings.Default.Site2_TargetPath = value;
        }

        public string Site1_OAuthToken
        {
            get => Properties.Settings.Default.Site1_OAuthToken;
            set => Properties.Settings.Default.Site1_OAuthToken = value;
        }

        public string Site2_OAuthToken
        {
            get => Properties.Settings.Default.Site2_OAuthToken;
            set => Properties.Settings.Default.Site2_OAuthToken = value;
        }

        public string Site1_HomeDirectory
        {
            get => Properties.Settings.Default.Site1_HomeDirectory;
            set => Properties.Settings.Default.Site1_HomeDirectory = value;
        }

        public string Site2_HomeDirectory
        {
            get => Properties.Settings.Default.Site2_HomeDirectory;
            set => Properties.Settings.Default.Site2_HomeDirectory = value;
        }
    }
}
