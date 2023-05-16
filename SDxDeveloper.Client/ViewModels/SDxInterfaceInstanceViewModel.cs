using SDxDeveloper.Client.ViewModels.PropertyTyped;
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

        public ObservableCollection<SDxPropertyInstanceViewModel> Properties { get; } = new();

        public SDxInterfaceInstanceViewModel(SDxInterfaceInstance sdxInterface)
        {
            _SdxInterface = sdxInterface;
            sdxInterface.Properties.ForEach(x =>
            {
                if (x != null)
                {
                    if (new List<string> { "True", "False" }.Contains(x?.Value))
                    {
                        Properties.Add(new SDxBooleanInstanceViewModel(x));
                    }
                    else
                    {
                        Properties.Add(new SDxStringInstanceViewModel(x));
                    }
                }
            });
        }
    }
}
