namespace SDxDeveloper.Client.ViewModels.TreeView.Base
{
    public abstract class NodeViewModel : ViewModelBase
    {
        /// <summary>
        /// Header is display text for each node in explorer.
        /// </summary>
        /// <remarks>Default value is <seealso cref="string.Empty"/></remarks>
        public string Header { get; protected set; } = string.Empty;

        /// <summary>
        /// This property using for manipulate node visible state.
        /// </summary>
        /// <remarks>Default value is true</remarks>
        public bool IsRequiredInView { get; set; }
    }
}
