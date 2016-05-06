using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCharGame
{
    class DisplayChar
    {
        static public string ground = "░";
        static public string tree = "T";
        static public string wall = "█";

        //0 = left/right wall, 1 = up/down wall, 2 = upperleft , 3 = upperright, 4 = lowerleft, 5 = lowerright
        static public string[] menuBrdr = { "║", "═", "╔", "╗", "╚", "╝" };

        //represents all objects that can be destroyed
        static public string[] canDestroy = { tree, wall };
    }
}
