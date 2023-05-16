using System.Collections.Generic;
using System.Xml;

namespace SDxDeveloper.Domain.Models
{
    public class SDxInterfaceInstance
    {
        private readonly XmlElement _Source;

        public string? Name { get; set; }

        public List<SDxPropertyInstance> Properties { get; } = new();

        public SDxInterfaceInstance(XmlElement source)
        {
            _Source = source;
            Name = source.Name;

            foreach (XmlAttribute attrib in source.Attributes)
            {
                Properties.Add(new SDxPropertyInstance(attrib));
            }
        }
    }
}
