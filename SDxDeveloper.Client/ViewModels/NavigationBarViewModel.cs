using SDxDeveloper.Client.Commands.Base;
using SDxDeveloper.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDxDeveloper.Client.ViewModels
{
    public sealed class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        public ICommand NavigateSettingsCommand { get; }

        public NavigationBarViewModel(INavigationService homeNavigationService,
            INavigationService settingsNavigationService)
        {
            NavigateHomeCommand = new RelayCommand(p => homeNavigationService.Navigate());
            NavigateSettingsCommand = new RelayCommand(p => settingsNavigationService.Navigate());
        }
    }
}
