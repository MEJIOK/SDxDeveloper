using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.Models
{
    public class BooleanInput : TypeInput, ITypeInput<bool>
    {
        public bool Value { get; set; }

        public BooleanInput(string text, bool value) : base(text) => Value = value;
    }
}
