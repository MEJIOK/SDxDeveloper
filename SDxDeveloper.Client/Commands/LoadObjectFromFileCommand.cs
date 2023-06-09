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
        private readonly IEnumerable<SDxObjectInstanceViewModel> _LoadedObjects;

        public event EventHandler? CanExecuteChanged;

        public LoadObjectFromFileCommand(IEnumerable<SDxObjectInstanceViewModel> loadedObjects)
        {
            _LoadedObjects = loadedObjects;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Properties.Settings.Default.DefaultFileExplorePath,
                Filter = "XML|*.xml",
                Multiselect = true,
                Title = "Load SDx Objects..."
            };

            if (dialog.ShowDialog() == true)
            {
                foreach (var filename in dialog.FileNames)
                {
                    var doc = new XmlDocument();
                    doc.Load(filename);

                    if (doc != null
                        && doc.DocumentElement != null
                        && _LoadedObjects is ObservableCollection<SDxObjectInstanceViewModel> observableLoadedObjects)
                    {
                        if (doc.DocumentElement.Name == "Containers")
                            foreach (XmlNode container in doc.DocumentElement.ChildNodes)
                                if (container.Name == "Container")
                                {
                                    foreach (XmlNode node in container.ChildNodes)
                                        if (node is XmlElement element) 
                                            observableLoadedObjects.Add(new SDxObjectInstanceViewModel(new SDxObjectInstance(element)));

                                    foreach (SDxObjectInstanceViewModel rel in observableLoadedObjects)
                                        if (rel.ClassName == "Rel")
                                            foreach (SDxObjectInstanceViewModel obj in observableLoadedObjects)
                                                if (obj.ClassName != "Rel" && (obj.UID == rel.Instance.GetProperty("UID1") || obj.Instance.GetProperty("UID") == rel.Instance.GetProperty("UID2")))
                                                    obj.Instance.Relations.Add(rel.Instance);
                                }
                    }
                }
            }
        }
    }
}
