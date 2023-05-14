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
    }
}
