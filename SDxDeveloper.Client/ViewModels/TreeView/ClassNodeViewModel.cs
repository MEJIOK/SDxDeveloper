using SDxDeveloper.Client.ViewModels.TreeView.Base;
using System.Collections.ObjectModel;

namespace SDxDeveloper.Client.ViewModels.TreeView
{
    public sealed class ClassNodeViewModel : NodeViewModel
    {
        public ClassNodeViewModel(string header)
        {
            IsRequiredInView = true;
            Header = header;
        }

        public ObservableCollection<ItemNodeViewModel> Items { get; } = new ObservableCollection<ItemNodeViewModel>();
    }
}
