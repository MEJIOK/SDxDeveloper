using SDxDeveloper.Client.Commands;
using SDxDeveloper.Client.Models;
using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SDxDeveloper.Client.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ObservableCollection<SDxObjectInstanceViewModel> _LoadedObjects = new();

        private SDxObjectInstanceViewModel? _SelectedObject = null;

        public IEnumerable<SDxObjectInstanceViewModel> LoadedObjects => _LoadedObjects;

        public SDxObjectInstanceViewModel? SelectedObject
        {
            get
            {
                return _SelectedObject;
            }
            set
            {
                _SelectedObject = value;
                OnPropertyChanged(nameof(SelectedObjectInterfaces));
            }
        }

        public ObservableCollection<SDxInterfaceInstanceViewModel>? SelectedObjectInterfaces => _SelectedObject?.Interfaces;

        public ICommand LoadFromFileCommand => new LoadObjectFromFileCommand(LoadedObjects);

        public ICommand ExportToFileCommand => new ExportToFileCommand(LoadedObjects);
    }
}
