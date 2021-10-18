using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Cell
    {
        public Position pos;
        public Resource resource = null;
        public double road = 0;
        public CityTile citytile = null;
        public Cell(int x, int y)
        {
            this.pos = new Position(x, y);
        }

        public virtual bool HasResource()
        {
            return this.resource != null && this.resource.amount > 0;
        }
    }
}