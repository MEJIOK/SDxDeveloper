using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.ViewModels
{
    public class SDxPropertyInstanceViewModel : ViewModelBase
    {
        private readonly SDxPropertyInstance? _SDxProperty = null;

        private string? _Value = null;

        public string? Name => _SDxProperty?.Name;

        public string? Value
        {
            get => _Value;
            set {
                _Value = value;
                OnPropertyChanged();
            }
        }

        public SDxPropertyInstanceViewModel(SDxPropertyInstance sdxProperty)
        {
            _SDxProperty = sdxProperty;
            _Value = sdxProperty?.Value;
        }
    }
}
