using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Agent agent = new Agent();

            // initialize
            agent.Initialize();
            while (true)
            {

                // wait for updates
                agent.Update();
                List<string> actions = new List<string>();
                GameState gameState = agent.gameState;

                /// <summary>
                /// AI Code Goes Below! *
                /// </summary>
                Player player = gameState.players[gameState.id];
                Player opponent = gameState.players[(gameState.id + 1) % 2];
                GameMap gameMap = gameState.map;
                List<Cell> resourceTiles = new List<Cell>();
                for (int y = 0; y < gameMap.height; y++)
                {
                    for (int x = 0; x < gameMap.width; x++)
                    {
                        Cell cell = gameMap.GetCell(x, y);
                        if (cell.HasResource())
                        {
                            resourceTiles.Add(cell);
                        }
                    }
                }


                // we iterate over all our units and do something with them
                for (int i = 0; i < player.units.Count; i++)
                {
                    Unit unit = player.units[i];
                    if (unit.IsWorker() && unit.CanAct())
                    {
                        if (unit.GetCargoSpaceLeft() > 0)
                        {

                            // if the unit is a worker and we have space in cargo, lets find the nearest resource tile and try to mine it
                            Cell closestResourceTile = null;
                            double closestDist = 9999999;
                            foreach (Cell cell in resourceTiles)
                            {
                                if (cell.resource.type.Equals(GameConstants.RESOURCE_TYPES.COAL) && !player.ResearchedCoal())
                                    continue;
                                if (cell.resource.type.Equals(GameConstants.RESOURCE_TYPES.URANIUM) && !player.ResearchedUranium())
                                    continue;
                                double dist = cell.pos.DistanceTo(unit.pos);
                                if (dist < closestDist)
                                {
                                    closestDist = dist;
                                    closestResourceTile = cell;
                                }
                            }

                            if (closestResourceTile != null)
                            {
                                Direction dir = unit.pos.DirectionTo(closestResourceTile.pos);

                                // move the unit in the direction towards the closest resource tile's position.
                                actions.Add(unit.Move(dir));
                            }
                        }
                        else
                        {

                            // if unit is a worker and there is no cargo space left, and we have cities, lets return to them
                            if (player.cities.Count > 0)
                            {
                                City city = player.cities.Values.First();
                                double closestDist = 999999;
                                CityTile closestCityTile = null;
                                foreach (CityTile citytile in city.citytiles)
                                {
                                    double dist = citytile.pos.DistanceTo(unit.pos);
                                    if (dist < closestDist)
                                    {
                                        closestCityTile = citytile;
                                        closestDist = dist;
                                    }
                                }

                                if (closestCityTile != null)
                                {
                                    Direction dir = unit.pos.DirectionTo(closestCityTile.pos);
                                    actions.Add(unit.Move(dir));
                                }
                            }
                        }
                    }
                }


                // you can add debug annotations using the static methods of the Annotate class.
                // actions.add(Annotate.circle(0, 0));
                /// <summary>
                /// AI Code Goes Above! *
                /// </summary>
                /// <summary>
                /// Do not edit! *
                /// </summary>
                StringBuilder commandBuilder = new StringBuilder("");
                for (int i = 0; i < actions.Count; i++)
                {
                    if (i != 0)
                    {
                        commandBuilder.Append(",");
                    }

                    commandBuilder.Append(actions[i]);
                }

                Console.WriteLine(commandBuilder.ToString());

                // end turn
                agent.EndTurn();
            }
        }
    }
}