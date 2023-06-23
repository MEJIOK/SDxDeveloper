using SDxDeveloper.Client.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore? _Navigator = null;

        private readonly ModalNavigationStore? _ModalNavigator = null;


        /// <summary>
        /// Current view model getting from navigator instance.
        /// </summary>
        public ViewModelBase? CurrentViewModel => _Navigator?.CurrentViewModel;

        /// <summary>
        /// Current view model getting from modal navigator instance.
        /// </summary>
        public ViewModelBase? CurrentModalViewModel => _ModalNavigator?.CurrentViewModel;

        public bool IsModalOpen => _ModalNavigator != null && _ModalNavigator.IsOpen;

        public MainViewModel(NavigationStore navigator, ModalNavigationStore modalNavigator)
        {
            _Navigator = navigator;
            _ModalNavigator = modalNavigator;
            _Navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _ModalNavigator.CurrentViewModelChanged += OnCorrentModalViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


        private void OnCorrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
