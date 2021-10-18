using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Agent
    {
        public GameState gameState = new GameState();
        /// <summary>
        /// Constructor for a new agent User should edit this according to their `Design`
        /// </summary>
        public Agent()
        {
        }

        public virtual void Initialize()
        {

            // get agent ID
            gameState.id = int.Parse(Console.ReadLine());
            string mapInfo = Console.ReadLine();
            String[] mapInfoSplit = mapInfo.Split(" ");
            int mapWidth = int.Parse(mapInfoSplit[0]);
            int mapHeight = int.Parse(mapInfoSplit[1]);
            gameState.map = new GameMap(mapWidth, mapHeight);
        }

        public virtual void Update()
        {
            // wait for the engine to send any updates
            gameState.map = new GameMap(gameState.map.width, gameState.map.height);
            gameState.turn += 1;
            gameState.players[0].cities.Clear();
            gameState.players[0].units.Clear();
            gameState.players[1].cities.Clear();
            gameState.players[1].units.Clear();
            while (true)
            {
                string updateInfo = Console.ReadLine();
                if (updateInfo.Equals(IOConstants.DONE.GetDescription()))
                {
                    break;
                }

                String[] updates = updateInfo.Split(" ");
                string inputIdentifier = updates[0];
                if (inputIdentifier.Equals(IOConstants.RESEARCH_POINTS.GetDescription()))
                {
                    int team = int.Parse(updates[1]);
                    this.gameState.players[team].researchPoints = int.Parse(updates[2]);
                }
                else if (inputIdentifier.Equals(IOConstants.RESOURCES.GetDescription()))
                {
                    string type = updates[1];
                    int x = int.Parse(updates[2]);
                    int y = int.Parse(updates[3]);
                    int amt = (int)(Double.Parse(updates[4]));
                    this.gameState.map._setResource(type, x, y, amt);
                }
                else if (inputIdentifier.Equals(IOConstants.UNITS.GetDescription()))
                {
                    int i = 1;
                    int unittype = int.Parse(updates[i++]);
                    int team = int.Parse(updates[i++]);
                    string unitid = updates[i++];
                    int x = int.Parse(updates[i++]);
                    int y = int.Parse(updates[i++]);
                    double cooldown = Double.Parse(updates[i++]);
                    int wood = int.Parse(updates[i++]);
                    int coal = int.Parse(updates[i++]);
                    int uranium = int.Parse(updates[i++]);
                    Unit unit = new Unit(team, unittype, unitid, x, y, cooldown, wood, coal, uranium);
                    this.gameState.players[team].units.Add(unit);
                }
                else if (inputIdentifier.Equals(IOConstants.CITY.GetDescription()))
                {
                    int i = 1;
                    int team = int.Parse(updates[i++]);
                    string cityid = updates[i++];
                    double fuel = Double.Parse(updates[i++]);
                    double lightUpkeep = Double.Parse(updates[i++]);
                    this.gameState.players[team].cities.Add(cityid, new City(team, cityid, fuel, lightUpkeep));
                }
                else if (inputIdentifier.Equals(IOConstants.CITY_TILES.GetDescription()))
                {
                    int i = 1;
                    int team = int.Parse(updates[i++]);
                    string cityid = updates[i++];
                    int x = int.Parse(updates[i++]);
                    int y = int.Parse(updates[i++]);
                    double cooldown = Double.Parse(updates[i++]);
                    City city = this.gameState.players[team].cities[cityid];
                    CityTile citytile = city._add_city_tile(x, y, cooldown);
                    this.gameState.map.GetCell(x, y).citytile = citytile;
                    this.gameState.players[team].cityTileCount += 1;
                }
                else if (inputIdentifier.Equals(IOConstants.ROADS.GetDescription()))
                {
                    int i = 1;
                    int x = int.Parse(updates[i++]);
                    int y = int.Parse(updates[i++]);
                    double road = Double.Parse(updates[i++]);
                    Cell cell = this.gameState.map.GetCell(x, y);
                    cell.road = road;
                }
            }
        }

        /// <summary>
        /// End a turn
        /// </summary>
        public virtual void EndTurn()
        {
            Console.WriteLine("D_FINISH");
        }
    }
}