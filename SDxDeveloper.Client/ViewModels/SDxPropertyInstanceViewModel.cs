using SDxDeveloper.Domain.Models;

namespace SDxDeveloper.Client.ViewModels
{
    public class SDxPropertyInstanceViewModel : ViewModelBase
    {
        protected readonly SDxPropertyInstance? _SDxProperty = null;

        public string? Name => _SDxProperty?.Name;

        public SDxPropertyInstanceViewModel(SDxPropertyInstance sdxProperty) => _SDxProperty = sdxProperty;
    }
}
