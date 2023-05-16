using SDxDeveloper.Domain.Models;

namespace SDxDeveloper.Client.ViewModels.PropertyTyped
{
    public class SDxStringInstanceViewModel : SDxPropertyInstanceViewModel, ISDxValuable<string>
    {
        private string? _Value = null;

        public string? Value
        {
            get => _Value;
            set
            {
                _Value = value;
                if (_SDxProperty != null) { _SDxProperty.Value = value; }
                OnPropertyChanged();
            }
        }

        public SDxStringInstanceViewModel(SDxPropertyInstance sdxProperty) : base(sdxProperty) => _Value = sdxProperty.Value;
    }
}
