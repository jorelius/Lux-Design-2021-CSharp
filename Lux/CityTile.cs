using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class CityTile
    {
        public string cityid;
        public int team;
        public Position pos;
        public double cooldown;
        public CityTile(int teamid, string cityid, int x, int y, double cooldown)
        {
            this.cityid = cityid;
            this.team = teamid;
            this.pos = new Position(x, y);
            this.cooldown = cooldown;
        }

        public virtual bool CanAct()
        {
            return this.cooldown < 1;
        }

        public virtual string Research()
        {
            return String.Format("r %d %d", this.pos.x, this.pos.y);
        }

        public virtual string BuildWorker()
        {
            return String.Format("bw %d %d", this.pos.x, this.pos.y);
        }

        public virtual string BuildCart()
        {
            return String.Format("bc %d %d", this.pos.x, this.pos.y);
        }
    }
}