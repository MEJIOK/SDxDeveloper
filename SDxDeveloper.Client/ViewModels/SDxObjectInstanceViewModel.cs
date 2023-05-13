using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.ViewModels
{
    public class SDxObjectInstanceViewModel : ViewModelBase
    {
        private readonly SDxObjectInstance? _SDxObject = null;

        public string? ClassName => _SDxObject?.ClassName;

        public string? Name => _SDxObject?.GetProperty("Name");

        public string? UID => _SDxObject?.GetProperty("UID");

        public SDxObjectInstanceViewModel(SDxObjectInstance sdxObject)
        {
            _SDxObject = sdxObject;
        }
    }
}
