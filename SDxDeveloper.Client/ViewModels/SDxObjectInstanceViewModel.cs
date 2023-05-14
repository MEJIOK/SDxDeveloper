using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.ViewModels
{
    public class SDxObjectInstanceViewModel : ViewModelBase
    {
        public SDxObjectInstance Instance { get; }

        public string? ClassName => Instance?.ClassName;

        public string? Name => Instance?.GetProperty("Name");

        public string? UID => Instance?.GetProperty("UID");

        public ObservableCollection<SDxInterfaceInstanceViewModel>? Interfaces { get; }

        public SDxObjectInstanceViewModel(SDxObjectInstance sdxObject)
        {
            Instance = sdxObject;
            Interfaces = new ObservableCollection<SDxInterfaceInstanceViewModel>(Instance?.Interfaces.Select(x => new SDxInterfaceInstanceViewModel(x)));
        }
    }
}
