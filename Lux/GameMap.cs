using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class GameMap
    {
        public int width;
        public int height;
        public Cell[,] map;
        public GameMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.map = new Cell[height,width];
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    this.map[y,x] = new Cell(x, y);
                }
            }
        }

        public virtual Cell GetCellByPos(Position pos)
        {
            return this.map[pos.y,pos.x];
        }

        public virtual Cell GetCell(int x, int y)
        {
            return this.map[y,x];
        }

        /// <summary>
        /// Internal use only
        /// </summary>
        public virtual void _setResource(string rType, int x, int y, int amount)
        {
            Cell cell = this.GetCell(x, y);
            cell.resource = new Resource(rType, amount);
        }
    }
}