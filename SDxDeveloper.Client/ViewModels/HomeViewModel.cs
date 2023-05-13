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
        public ObservableCollection<SDxObjectInstance> LoadedObjects { get; } = new ObservableCollection<SDxObjectInstance>();

        public ICommand LoadFromFileCommand => new LoadObjectFromFileCommand(LoadedObjects);
    }
}
