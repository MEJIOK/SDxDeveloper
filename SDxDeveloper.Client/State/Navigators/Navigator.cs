using SDxDeveloper.Client.Commands;
using SDxDeveloper.Client.Models;
using SDxDeveloper.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;

namespace SDxDeveloper.Client.State.Navigators
{
    public enum ViewType
    {
        Home,
        Settings
    }


    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _CurrentViewModel;

        private ViewModelBase _PrevViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                _PrevViewModel = _CurrentViewModel;
                _CurrentViewModel = value;
                OnPropertyChanged();

                // saving user settings
                if (_PrevViewModel is SettingsViewModel settingsGet)
                {
                    var settings = new XmlDocument();
                    settings.Load("usersettings.xml");

                    if (settings.DocumentElement != null)
                    {
                        foreach (XmlNode node in settings.DocumentElement)
                        {
                            if (node.Name == "DefaultFileExplorePath")
                            {
                                node.InnerText = settingsGet.DefaultFileExplorePath;
                            }
                        }
                    }

                    settings.Save("usersettings.xml");
                }

                // expose user settings
                if (_CurrentViewModel is SettingsViewModel settingsSet)
                {
                    var settings = new XmlDocument();
                    settings.Load("usersettings.xml");

                    if (settings.DocumentElement != null)
                    {
                        foreach (XmlNode node in settings.DocumentElement)
                        {
                            if (node.Name == "DefaultFileExplorePath")
                            {
                                settingsSet.DefaultFileExplorePath = node.InnerText; 
                            }
                        }
                    }
                }
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
} 
