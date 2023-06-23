using SDxDeveloper.Client.Commands;
using SDxDeveloper.Client.ViewModels.TreeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SDxDeveloper.Client.ViewModels
{
    public sealed class HomeViewModel : ViewModelBase
    {
        private string _TreeFilter = string.Empty;

        /// <summary>
        /// The <b>filter string</b> that is binding to search bar to filter the treeview explorer using <b>Contains</b>
        /// in node header by hidding unnecessary nodes.
        /// </summary>
        public string TreeFilter
        {
            get { return _TreeFilter; }
            set
            {
                foreach (ClassNodeViewModel @class in ClassNodes)
                {
                    bool isAtLeastOneItemFiltred = false;

                    foreach (ItemNodeViewModel item in @class.Items)
                    {
                        bool isAtLeastOneRelFiltred = false;

                        foreach (RelationNodeViewModel rel in item.Relations)
                        {
                            rel.IsRequiredInView = rel.Header.Contains(value, StringComparison.OrdinalIgnoreCase) || value == string.Empty;
                            if (!isAtLeastOneRelFiltred && rel.IsRequiredInView) isAtLeastOneRelFiltred = true;
                        };

                        item.IsRequiredInView = isAtLeastOneRelFiltred || item.Header.Contains(value, StringComparison.OrdinalIgnoreCase) || value == string.Empty;
                        if (!isAtLeastOneItemFiltred && item.IsRequiredInView) isAtLeastOneItemFiltred = true;
                    };

                    @class.IsRequiredInView = isAtLeastOneItemFiltred || @class.Header.Contains(value, StringComparison.OrdinalIgnoreCase) || value == string.Empty;
                };

                _TreeFilter = value;

                // without re-set TreeView item do not update view
                ClassNodes = new(ClassNodes);
                OnPropertyChanged(nameof(ClassNodes));
            }
        }


        private SDxObjectInstanceViewModel? _SelectedObject = null;

        public SDxObjectInstanceViewModel? SelectedObject
        {
            get => _SelectedObject;
            set
            {
                _SelectedObject = value;

                if (SelectedObjectInterfaces is ObservableCollection<SDxInterfaceInstanceViewModel> selectedInterfaces)
                {
                    selectedInterfaces.Clear();
                    _SelectedObject?.Interfaces?.ToList().ForEach(selectedInterfaces.Add);
                }

                if (SelectedObjectRelations is ObservableCollection<SDxRelationshipInstanceViewModel> selectedRelations)
                {
                    selectedRelations.Clear();
                    _SelectedObject?.Instance?.Relations?.ToList().ForEach(x => selectedRelations.Add(new SDxRelationshipInstanceViewModel(x)));
                }
            }
        }


        public ObservableCollection<ClassNodeViewModel> ClassNodes { get; private set; }

        public HomeViewModel()
        {
            ClassNodes = new ObservableCollection<ClassNodeViewModel>()
            {
                new ClassNodeViewModel("Methods"),
                new ClassNodeViewModel("Forms"),
                new ClassNodeViewModel("Classifications"),
                new ClassNodeViewModel("Sections")
            };
            ClassNodes[0].Items.Add(new ItemNodeViewModel("Create"));
            ClassNodes[0].Items[0].Relations.Add(new RelationNodeViewModel("MethodAPI"));
            OnPropertyChanged(nameof(ClassNodes));
        }



        public IEnumerable<SDxObjectInstanceViewModel> LoadedObjects { get; } = new ObservableCollection<SDxObjectInstanceViewModel>();

        public IEnumerable<SDxInterfaceInstanceViewModel> SelectedObjectInterfaces { get; } = new ObservableCollection<SDxInterfaceInstanceViewModel>();

        public IEnumerable<SDxRelationshipInstanceViewModel> SelectedObjectRelations { get; } = new ObservableCollection<SDxRelationshipInstanceViewModel>();

        public ICommand LoadFromFileCommand => new LoadObjectFromFileCommand(LoadedObjects);

        public ICommand ExportToFileCommand => new ExportToFileCommand(LoadedObjects);

        public ICommand InspectObjectsCommand => new InspectObjectsCommand();
    }
}
