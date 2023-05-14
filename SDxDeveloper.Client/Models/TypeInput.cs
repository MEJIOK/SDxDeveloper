namespace SDxDeveloper.Client.Models
{
    public abstract class TypeInput
    {
        public string Text { get; }

        public TypeInput(string text)
        {
            Text = text;
        }
    }
}
