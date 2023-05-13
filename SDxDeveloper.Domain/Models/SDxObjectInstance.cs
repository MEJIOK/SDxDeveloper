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
        private readonly XmlElement _Source;

        public string? ClassName { get; set; }

        public List<SDxInterfaceInstance>? Interfaces { get; set; } = new List<SDxInterfaceInstance>();

        public SDxObjectInstance(XmlElement source)
        {
            _Source = source;
            ClassName = source.Name;

            foreach (XmlElement elInterface in _Source.ChildNodes)
            {
                Interfaces.Add(new SDxInterfaceInstance(elInterface));
            }
        }
    }
}
