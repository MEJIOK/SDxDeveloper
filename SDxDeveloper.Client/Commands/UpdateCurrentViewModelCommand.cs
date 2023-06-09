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

        private readonly INavigator _Navigator;

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
            if (parameter is ViewType viewType) _Navigator.SetView(viewType);
        }
    }
}
