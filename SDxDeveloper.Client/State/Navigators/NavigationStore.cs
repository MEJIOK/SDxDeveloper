using SDxDeveloper.Client.ViewModels;
using System;

namespace SDxDeveloper.Client.State.Navigators
{
    /// <summary>
    /// Class used to store and manage all view models in app.
    /// </summary>
    public sealed class NavigationStore
    {
        private ViewModelBase? _currentViewModel = null;

        /// <summary>
        /// Actual current main view model for user.
        /// </summary>
        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }


        /// <summary>
        /// Action that will be invoked when current model will change.
        /// </summary>
        public event Action CurrentViewModelChanged;
    }
} 
