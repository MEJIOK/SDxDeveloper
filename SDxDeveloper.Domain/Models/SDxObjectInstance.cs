using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDxDeveloper.Domain.Models
{
    public class SDxObjectInstance
    {
        public XmlElement Source { get; }

        public string? ClassName { get; set; }

        public List<SDxInterfaceInstance>? Interfaces { get; set; } = new List<SDxInterfaceInstance>();

        public SDxObjectInstance(XmlElement source)
        {
            Source = source;
            ClassName = source.Name;

            foreach (XmlElement elInterface in Source.ChildNodes)
            {
                Interfaces.Add(new SDxInterfaceInstance(elInterface));
            }
        }

        public string? GetProperty(string propertyName)
        {
            if (Interfaces != null)
            {
                foreach (SDxInterfaceInstance intf in Interfaces)
                {
                    if (intf.Properties != null)
                    {
                        foreach (SDxPropertyInstance prop in intf.Properties)
                        {
                            if (prop != null && prop.Name == propertyName)
                            {
                                return prop.Value;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
