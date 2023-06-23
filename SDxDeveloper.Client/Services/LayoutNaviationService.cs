using SDxDeveloper.Client.State.Navigators;
using SDxDeveloper.Client.ViewModels;
using System;

namespace SDxDeveloper.Client.Services
{
    public class LayoutNaviationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        private readonly Func<TViewModel> _createViewModel;

        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;

        public LayoutNaviationService(NavigationStore navigationStore, Func<TViewModel> createViewModel, Func<NavigationBarViewModel> createNavigationBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate() => _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel());
    }
}
