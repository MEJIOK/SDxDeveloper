using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.Models
{
    public interface ITypeInput<T>
    {
        public T Value { get; set; }
    }
}
