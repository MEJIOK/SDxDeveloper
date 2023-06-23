using SDxDeveloper.Client.ViewModels.TreeView.Base;
using System.Collections.ObjectModel;

namespace SDxDeveloper.Client.ViewModels.TreeView
{
    public sealed class ItemNodeViewModel : NodeViewModel
    {
        public ItemNodeViewModel(string name)
        {
            IsRequiredInView = true;
            Header = name;
        }

        public ObservableCollection<RelationNodeViewModel> Relations { get; } = new ObservableCollection<RelationNodeViewModel>();
    }
}
