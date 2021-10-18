using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lux
{
    public enum IOConstants
    {
        [Description("D_DONE")]
        DONE, 

        [Description("rp")]
        RESEARCH_POINTS, 

        [Description("r")]
        RESOURCES,

        [Description("u")] 
        UNITS, 

        [Description("c")]
        CITY, 

        [Description("ct")]
        CITY_TILES,

        [Description("ccd")] 
        ROADS
    }
}