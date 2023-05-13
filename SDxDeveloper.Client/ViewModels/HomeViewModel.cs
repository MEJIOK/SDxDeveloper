using SDxDeveloper.Client.Commands;
using SDxDeveloper.Client.Models;
using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDxDeveloper.Client.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<SDxObjectInstanceViewModel> _LoadedObjects = new ObservableCollection<SDxObjectInstanceViewModel>();

        public ObservableCollection<SDxObjectInstanceViewModel> LoadedObjects { 
            get
            {
                return _LoadedObjects;
            } 
        }

        public ObservableCollection<string> LoadedTypes { get; } = new ObservableCollection<string>();

        public ICommand LoadFromFileCommand => new LoadObjectFromFileCommand(LoadedObjects);
    }
}
