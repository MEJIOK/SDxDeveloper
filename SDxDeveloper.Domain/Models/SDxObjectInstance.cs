using System.Collections.Generic;
using System.Xml;

namespace SDxDeveloper.Domain.Models
{
    public class SDxObjectInstance : Base.SourceInstance
    {
        public string ClassName => Source.Name;

        public List<SDxInterfaceInstance> Interfaces { get; } = new();

        public List<SDxObjectInstance> Relations { get; } = new();

        public SDxObjectInstance(XmlElement source) : base(source)
        {
            foreach (XmlElement elInterface in source.ChildNodes)
                Interfaces.Add(new SDxInterfaceInstance(elInterface));
        }

        public string? GetProperty(string propertyName)
        {
            foreach (SDxInterfaceInstance intf in Interfaces)
                foreach (SDxPropertyInstance prop in intf.Properties)
                    if (prop.Name == propertyName)
                        return prop.Value;

            return null;
        }
    }
}
