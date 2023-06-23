using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SDxDeveloper.Client.ViewModels
{
    public sealed class QuerySelectorViewModel : ViewModelBase
    {
        public string ObjectUID { get; set; } = "*";

        public ObservableCollection<string> ObjectClasses { get; set; } = new ObservableCollection<string>() { "Workflow", "Method" };

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }
    }
}
