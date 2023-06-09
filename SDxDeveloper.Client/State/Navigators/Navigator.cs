using SDxDeveloper.Client.Commands;
using SDxDeveloper.Client.Models;
using SDxDeveloper.Client.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace SDxDeveloper.Client.State.Navigators
{
    public enum ViewType
    {
        Home,
        Settings
    }


    public class Navigator : ObservableObject, INavigator
    {
        private readonly Dictionary<ViewType, ViewModelBase> _ViewModels = new();

        #region Current View Model

        private ViewModelBase? _CurrentViewModel = null;

        /// <summary>
        /// Binded in navigator bar view.
        /// </summary>
        public ViewModelBase? CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                _CurrentViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);


        public void SetView(ViewType viewType)
        {
            if (_ViewModels.ContainsKey(viewType)) {
                CurrentViewModel = _ViewModels[viewType];
            }
            else
            {
                switch (viewType)
                {
                    case ViewType.Home:
                        var vmh = new HomeViewModel();
                        _ViewModels.Add(ViewType.Home, vmh);
                        CurrentViewModel = vmh;
                        return;

                    case ViewType.Settings:
                        var vms = new SettingsViewModel();
                        _ViewModels.Add(ViewType.Settings, vms);
                        CurrentViewModel = vms;
                        return;

                    default:
                        return;
                }
            }
        }
    }
} 
