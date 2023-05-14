using SDxDeveloper.Client.Commands;
using SDxDeveloper.Client.Models;
using SDxDeveloper.Client.ViewModels;
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
        private ViewModelBase? _CurrentViewModel = null;

        public ViewModelBase? CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                _CurrentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
} 
