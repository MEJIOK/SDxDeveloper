using Microsoft.Win32;
using SDxDeveloper.Client.ViewModels;
using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            var ofd = new SaveFileDialog { };
        }
    }
}
