using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Resource
    {
        public string type;
        public int amount;
        public Resource(string type, int amt)
        {
            this.type = type;
            this.amount = amt;
        }
    }
}