using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Unit
    {
        public Position pos;
        public int team;
        public string id;
        public int type;
        public double cooldown;
        public Cargo cargo;
        public Unit(int teamid, int u_type, string unitid, int x, int y, double cooldown, int wood, int coal, int uranium)
        {
            this.pos = new Position(x, y);
            this.team = teamid;
            this.id = unitid;
            this.type = u_type;
            this.cooldown = cooldown;
            this.cargo = new Cargo(wood, coal, uranium);
        }

        public virtual bool IsWorker()
        {
            return this.type == 0;
        }

        public virtual bool IsCart()
        {
            return this.type == 1;
        }

        public virtual int GetCargoSpaceLeft()
        {
            int spaceused = this.cargo.wood + this.cargo.coal + this.cargo.uranium;
            if (this.type == GameConstants.UNIT_TYPES.WORKER)
            {
                return GameConstants.PARAMETERS.RESOURCE_CAPACITY.WORKER - spaceused;
            }
            else
            {
                return GameConstants.PARAMETERS.RESOURCE_CAPACITY.CART - spaceused;
            }
        }

        public virtual bool CanBuild(GameMap gameMap)
        {
            Cell cell = gameMap.GetCellByPos(this.pos);
            if (!cell.HasResource() && this.CanAct() && (this.cargo.wood + this.cargo.coal + this.cargo.uranium) >= GameConstants.PARAMETERS.CITY_BUILD_COST)
                return true;
            return false;
        }

        public virtual bool CanAct()
        {
            return this.cooldown < 1;
        }

        public virtual string Move(Direction dir)
        {
            return $"m {this.id} {dir.GetDescription()}";
        }

        public virtual string Transfer(string destId, string resourceType, int amount)
        {
            return $"t {this.id} {destId} {resourceType} {amount}";
        }

        public virtual string BuildCity()
        {
            return $"bcity {this.id}";
        }

        public virtual string Pillage()
        {
            return $"p {this.id}";
        }
    }
}