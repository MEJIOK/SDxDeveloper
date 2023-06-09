using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SDxDeveloper.Domain.Models
{
    public class SDxInterfaceInstance : Base.SourceInstance
    {
        public string Name => Source.Name;

        public List<SDxPropertyInstance> Properties { get; } = new();

        public SDxInterfaceInstance(XmlElement source) : base(source)
        {
            foreach (XmlAttribute attrib in source.Attributes)
                Properties.Add(new SDxPropertyInstance(attrib));
        }
    }
}
