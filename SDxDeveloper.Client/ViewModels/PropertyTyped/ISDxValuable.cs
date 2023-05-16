namespace SDxDeveloper.Client.ViewModels.PropertyTyped
{
    public interface ISDxValuable<T> 
    {
        public T? Value { get; set; }
    }
}
