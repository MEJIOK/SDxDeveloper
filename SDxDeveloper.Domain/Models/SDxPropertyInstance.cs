using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDxDeveloper.Domain.Models
{
    public class SDxPropertyInstance
    {
        private readonly XmlAttribute _Source;

        public string? Name { get; set; }

        public string? Value { get; set; }

        public SDxPropertyInstance(XmlAttribute source)
        {
            _Source = source;
            Name = source.Name;
            Value = source.Value;
        }
    }
}
