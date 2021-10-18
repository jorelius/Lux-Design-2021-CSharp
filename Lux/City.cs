using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class City
    {
        public string cityid;
        public int team;
        public double fuel;
        public List<CityTile> citytiles = new List<CityTile>();
        private double lightUpKeep = 0;
        public City(int teamid, string cityid, double fuel, double lightUpKeep)
        {
            this.cityid = cityid;
            this.team = teamid;
            this.fuel = fuel;
            this.lightUpKeep = lightUpKeep;
        }

        public virtual CityTile _add_city_tile(int x, int y, double cooldown)
        {
            CityTile ct = new CityTile(this.team, this.cityid, x, y, cooldown);
            this.citytiles.Add(ct);
            return ct;
        }

        public virtual double GetLightUpkeep()
        {
            return this.lightUpKeep;
        }
    }
}