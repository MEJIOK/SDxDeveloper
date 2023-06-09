using System.Xml;

namespace SDxDeveloper.Domain.Models.Base
{
    public abstract class SourceInstance
    {
        public XmlNode Source { get; }

        public SourceInstance(XmlNode source) => Source = source;
    }
}
