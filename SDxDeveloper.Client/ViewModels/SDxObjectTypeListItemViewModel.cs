using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.ViewModels
{
    public class SDxObjectTypeListItemViewModel : ViewModelBase
    {
        public string? ObjectTypeDisplay { get; }

        public SDxObjectTypeListItemViewModel(string? sdxObjectType, int objectCount)
        {
            ObjectTypeDisplay = $"{sdxObjectType} ({objectCount})";
        }
    }
}
