using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public sealed class GameConstants
    {
        public class UNIT_TYPES
        {
            public static readonly int WORKER = 0;
            public static readonly int CART = 1;
        }

        public class RESOURCE_TYPES
        {
            public static readonly string WOOD = "wood";
            public static readonly string COAL = "coal";
            public static readonly string URANIUM = "uranium";
        }

        public class PARAMETERS
        {
            public static readonly int DAY_LENGTH = 30;
            public static readonly int NIGHT_LENGTH = 10;
            public static readonly int MAX_DAYS = 360;
            public class LIGHT_UPKEEP
            {
                public static readonly int CITY = 23;
                public static readonly int WORKER = 4;
                public static readonly int CART = 10;
            }

            public static readonly double WOOD_GROWTH_RATE = 1.025;
            public static readonly int MAX_WOOD_AMOUNT = 500;
            public static readonly int CITY_ADJACENCY_BONUS = 5;
            public static readonly int CITY_BUILD_COST = 100;
            public class RESOURCE_CAPACITY
            {
                public static readonly int WORKER = 100;
                public static readonly int CART = 2000;
            }

            public class WORKER_COLLECTION_RATE
            {
                public static readonly int WOOD = 20;
                public static readonly int COAL = 5;
                public static readonly int URANIUM = 2;
            }

            public class RESOURCE_TO_FUEL_RATE
            {
                public static readonly int WOOD = 1;
                public static readonly int COAL = 10;
                public static readonly int URANIUM = 40;
            }

            public class RESEARCH_REQUIREMENTS
            {
                public static readonly int COAL = 50;
                public static readonly int URANIUM = 200;
            }

            public static readonly int CITY_ACTION_COOLDOWN = 10;
            public class UNIT_ACTION_COOLDOWN
            {
                public static readonly int CART = 3;
                public static readonly int WORKER = 2;
            }

            public static readonly double MAX_ROAD = 6;
            public static readonly double MIN_ROAD = 0;
            public static readonly double CART_ROAD_DEVELOPMENT_RATE = 0.75;
            public static readonly double PILLAGE_RATE = 0.5;
        }
    }
}