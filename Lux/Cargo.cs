using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Cargo
    {
        public int wood;
        public int coal;
        public int uranium;
        public Cargo(int wood, int coal, int uranium)
        {
            this.wood = wood;
            this.coal = coal;
            this.uranium = uranium;
        }
    }
}