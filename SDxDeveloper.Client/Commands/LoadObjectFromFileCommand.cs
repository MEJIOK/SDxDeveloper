using Microsoft.Win32;
using SDxDeveloper.Client.State;
using SDxDeveloper.Client.ViewModels;
using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace SDxDeveloper.Client.Commands
{
    public class LoadObjectFromFileCommand : ICommand
    {
        private readonly ObservableCollection<SDxObjectInstance> _Collection;

        public event EventHandler? CanExecuteChanged;

        public LoadObjectFromFileCommand(ObservableCollection<SDxObjectInstance> collection)
        {
            _Collection = collection;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog { Filter = "XML|*.xml", Multiselect = true };

            var settings = new XmlDocument();
            settings.Load("usersettings.xml");

            if (settings.DocumentElement != null)
            {
                foreach (XmlNode node in settings.DocumentElement)
                {
                    if (node.Name == "DefaultFileExplorePath")
                    {
                        dialog.InitialDirectory = node.InnerText;
                    }
                }
            }

            if (dialog.ShowDialog() == true)
            {
                foreach (var filename in dialog.FileNames)
                {
                    var doc = new XmlDocument();
                    doc.Load(filename);

                    foreach (XmlElement element in doc.DocumentElement)
                    {
                        _Collection.Add(new SDxObjectInstance(element));
                    }
                }
            }
        }
    }
}
