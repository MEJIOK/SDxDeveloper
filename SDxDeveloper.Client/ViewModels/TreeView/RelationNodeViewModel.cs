using SDxDeveloper.Client.ViewModels.TreeView.Base;

namespace SDxDeveloper.Client.ViewModels.TreeView
{
    public sealed class RelationNodeViewModel : NodeViewModel
    {
        public RelationNodeViewModel(string defUID)
        {
            IsRequiredInView = true;
            Header = defUID;
        }
    }
}
