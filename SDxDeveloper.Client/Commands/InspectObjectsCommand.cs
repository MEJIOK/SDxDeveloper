using SDxDeveloper.Client.ViewModels;
using SDxDeveloper.Services.API;
using System;
using System.Windows;
using System.Windows.Input;

namespace SDxDeveloper.Client.Commands
{
    public sealed class InspectObjectsCommand : ICommand
    {
        private bool _ModalState;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public async void Execute(object? parameter)
        {
            // new Views.Windows.QuerySelector { DataContext = new QuerySelectorViewModel() }.ShowDialog();
            var odata = new ODataProvider(
                Properties.Settings.Default.SiteTargetPath2,
                Properties.Settings.Default.OAuthToken,
                "PR_BGPP");
            try
            {
                var res = await odata.GetObjectByOBID("6WPS000A");
                MessageBox.Show(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
