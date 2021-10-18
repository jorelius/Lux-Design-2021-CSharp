using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Lux
{
    public enum Direction
    {
        [Description("n")]
        NORTH,

        [Description("e")]
        EAST,

        [Description("s")]
        SOUTH,

        [Description("w")]
        WEST,

        [Description("c")]
        CENTER
    }
}