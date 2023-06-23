using SDxDeveloper.Client.State.Navigators;
using SDxDeveloper.Client.ViewModels;
using System;

namespace SDxDeveloper.Client.Services
{
    public class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
         private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigator, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigator;
            _createViewModel = createViewModel;
        }

        public void Navigate() => _navigationStore.CurrentViewModel = _createViewModel();
    }
}
