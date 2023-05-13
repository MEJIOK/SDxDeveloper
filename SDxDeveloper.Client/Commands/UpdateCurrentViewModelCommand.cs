using SDxDeveloper.Client.State.Navigators;
using SDxDeveloper.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDxDeveloper.Client.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private INavigator _Navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _Navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                var viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _Navigator.CurrentViewModel = new HomeViewModel();
                        break;

                    case ViewType.Settings:
                        _Navigator.CurrentViewModel = new SettingsViewModel();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
