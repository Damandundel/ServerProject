using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerProject.Server.Common;

namespace ServerProject.Server.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value) 
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            Name = name;
            Value = value;
            
        }

        public string Name { get; init; }
        public string Value { get; init; }


        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
