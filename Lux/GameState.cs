using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class GameState
    {
        public GameMap map;
        public int turn = 0;
        public int id = 0;
        public Player[] players = new[] {new Player(0), new Player(1)};
        public GameState()
        {
        }
    }
}