using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual bool IsAdjacent(Position pos)
        {
            int dx = this.x - pos.x;
            int dy = this.y - pos.y;
            if (Math.Abs(dx) + Math.Abs(dy) > 1)
            {
                return false;
            }

            return true;
        }

        public virtual bool Equals(Position pos)
        {
            return this.x == pos.x && this.y == pos.y;
        }

        public virtual Position Translate(Direction direction, int units)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return new Position(this.x, this.y - units);
                case Direction.EAST:
                    return new Position(this.x + units, this.y);
                case Direction.SOUTH:
                    return new Position(this.x, this.y + units);
                case Direction.WEST:
                    return new Position(this.x - units, this.y);
                case Direction.CENTER:
                    return new Position(this.x, this.y);
            }

            throw new Exception("Did not supply valid direction");
        }

        public virtual double DistanceTo(Position pos)
        {
            return Math.Abs(pos.x - this.x) + Math.Abs(pos.y - this.y);
        }

        public virtual Direction DirectionTo(Position targetPos)
        {
            Direction[] checkDirections = new[]{Direction.NORTH, Direction.EAST, Direction.SOUTH, Direction.WEST};
            Direction closestDirection = Direction.CENTER;
            double closestDist = this.DistanceTo(targetPos);
            foreach (Direction dir in checkDirections)
            {
                Position newpos = this.Translate(dir, 1);
                double dist = targetPos.DistanceTo(newpos);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestDirection = dir;
                }
            }

            return closestDirection;
        }

        public override string ToString()
        {
            return "(" + this.x + ", " + this.y + ")";
        }
    }
}