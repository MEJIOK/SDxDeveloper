using Microsoft.Win32;
using SDxDeveloper.Client.ViewModels;
using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace SDxDeveloper.Client.Commands
{
    public class ExportToFileCommand : ICommand
    {
        private readonly IEnumerable<SDxObjectInstanceViewModel>? _ObjectsToExport = null;

        public event EventHandler? CanExecuteChanged;

        public ExportToFileCommand(IEnumerable<SDxObjectInstanceViewModel> objectsToExport)
        {
            _ObjectsToExport = objectsToExport;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var ofd = new SaveFileDialog
            {
                InitialDirectory = Properties.Settings.Default.DefaultFileExplorePath,
                Filter = "XML|*.xml|Original|*.dwh",
                FileName = "exported_objects",
                Title = "Export SDx Objects..."
            };
            if (ofd.ShowDialog() == true)
            {
                var document = new XmlDocument { PreserveWhitespace = Properties.Settings.Default.ExportPreserveWhitespace };
                document.InsertBefore(document.CreateXmlDeclaration("1.0", "utf-8", null), document.DocumentElement);
                XmlNode container = document.CreateNode(XmlNodeType.Element, "Container", string.Empty);
                document.AppendChild(container);
                _ObjectsToExport?.ToList().ForEach(obj => container.AppendChild(document.ImportNode(obj.Instance.Source, true)));
                document.Save(ofd.FileName);
            }
        }
    }
}
