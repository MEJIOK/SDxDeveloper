using SDxDeveloper.Domain.Models;
using System.Collections.ObjectModel;

namespace SDxDeveloper.Client.ViewModels
{
    public sealed class LogViewModel : ViewModelBase
    {
        public ObservableCollection<LogEntry> LogEntries { get; } = new ObservableCollection<LogEntry>();
    }
}
