using System.Xml;

namespace SDxDeveloper.Domain.Models
{
    public class SDxPropertyInstance : Base.SourceInstance
    {
        public string Name => Source.Name;

        public string? Value
        {
            get => Source.Value;
            set => Source.Value = value;
        }

        public SDxPropertyInstance(XmlAttribute source) : base(source) { }
    }
}
