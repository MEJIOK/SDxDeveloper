using SDxDeveloper.Domain.Models;
using System;

namespace SDxDeveloper.Client.ViewModels.PropertyTyped
{
    class SDxBooleanInstanceViewModel : SDxPropertyInstanceViewModel, ISDxValuable<bool>
    {
        private bool _Value = false;

        public bool Value
        {
            get => _Value;
            set
            {
                _Value = value;
                if (_SDxProperty != null) { _SDxProperty.Value = value.ToString(); }
                OnPropertyChanged();
            }
        }

        public SDxBooleanInstanceViewModel(SDxPropertyInstance sdxProperty) : base(sdxProperty) => _Value = Convert.ToBoolean(sdxProperty.Value);
    }
}
