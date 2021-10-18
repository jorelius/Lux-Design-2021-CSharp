using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Player
    {
        public int team;
        public int researchPoints;
        public List<Unit> units = new List<Unit>();
        public Dictionary<string, City> cities = new Dictionary<string, City>();
        public int cityTileCount;
        public Player(int team)
        {
            this.team = team;
            this.researchPoints = 0;
            this.cityTileCount = 0;
        }

        public virtual bool ResearchedCoal()
        {
            return this.researchPoints >= GameConstants.PARAMETERS.RESEARCH_REQUIREMENTS.COAL;
        }

        public virtual bool ResearchedUranium()
        {
            return this.researchPoints >= GameConstants.PARAMETERS.RESEARCH_REQUIREMENTS.URANIUM;
        }
    }
}