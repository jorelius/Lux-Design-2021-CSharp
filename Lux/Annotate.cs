using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lux
{
    public class Annotate
    {
        public static string Circle(int x, int y)
        {
            return "dc " + x + " " + y;
        }

        public static string X(int x, int y)
        {
            return "dx " + x + " " + y;
        }

        public static string Line(int x1, int y1, int x2, int y2)
        {
            return "dl " + x1 + " " + y1 + " " + x2 + " " + y2;
        }

        public static string Text(int x1, int y1, string message)
        {
            return "dt " + x1 + " " + y1 + " 16 '" + message + "'";
        }

        public static string Text(int x1, int y1, string message, int fontsize)
        {
            return "dt " + x1 + " " + y1 + " " + fontsize + " '" + message + "'";
        }

        public static string Sidetext(string message)
        {
            return "dst '" + message + "'";
        }
    }
}