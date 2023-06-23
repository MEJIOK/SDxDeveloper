using System;
using System.Windows.Input;

namespace SDxDeveloper.Client.Commands
{
    public sealed class SubmitCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
        }
    }
}
