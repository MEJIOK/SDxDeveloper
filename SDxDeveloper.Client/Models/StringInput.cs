using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.Models
{
    public class StringInput : TypeInput, ITypeInput<string>
    {
        public string Value { get; set; }

        public StringInput(string text, string value) : base(text) => Value = value;
    }
}
