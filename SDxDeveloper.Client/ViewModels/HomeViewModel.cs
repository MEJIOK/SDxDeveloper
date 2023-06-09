using SDxDeveloper.Client.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SDxDeveloper.Client.ViewModels
{
    public sealed class HomeViewModel : ViewModelBase
    {
        private SDxObjectInstanceViewModel? _SelectedObject = null;

        public IEnumerable<SDxObjectInstanceViewModel> LoadedObjects { get; } = new ObservableCollection<SDxObjectInstanceViewModel>();

        public IEnumerable<SDxInterfaceInstanceViewModel> SelectedObjectInterfaces { get; } = new ObservableCollection<SDxInterfaceInstanceViewModel>();

        public IEnumerable<SDxRelationshipInstanceViewModel> SelectedObjectRelations { get; } = new ObservableCollection<SDxRelationshipInstanceViewModel>();

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

        public ICommand LoadFromFileCommand => new LoadObjectFromFileCommand(LoadedObjects);

        public ICommand ExportToFileCommand => new ExportToFileCommand(LoadedObjects);
    }
}
