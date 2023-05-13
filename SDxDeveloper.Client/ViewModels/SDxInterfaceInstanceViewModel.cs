using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.ViewModels
{
    public class SDxInterfaceInstanceViewModel : ViewModelBase
    {
        private readonly SDxInterfaceInstance? _SdxInterface = null;

        public string? Name => _SdxInterface?.Name;

        public ObservableCollection<SDxPropertyInstanceViewModel> Properties { get; }

        public SDxInterfaceInstanceViewModel(SDxInterfaceInstance sdxInterface)
        {
            _SdxInterface = sdxInterface;
            Properties = new ObservableCollection<SDxPropertyInstanceViewModel>(sdxInterface.Properties.Select(x => new SDxPropertyInstanceViewModel(x)));
        }
    }
}
