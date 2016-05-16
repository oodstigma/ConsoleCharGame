using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayWindow
{
    class DisplayChar
    {
         const string grnd = "░";
         const string tre = "T";
         const string wll = "█";
         const string rck = "R";

         const string rckwll = "▓";

        //0 = left/right wall, 1 = up/down wall, 2 = upperleft , 3 = upperright, 4 = lowerleft, 5 = lowerright
         static public string[] menuBrdr = { "║", "═", "╔", "╗", "╚", "╝" };

        //represents all objects that can be destroyed
         static public string[] canDestroy = { tre, wll, rck, rckwll };

        public string ground
        {
            get { return grnd; }
        }
        public string tree
        {
            get { return tre; }
        }
        public string wall
        {
            get { return wll; }
        }
        public string rock
        {
            get { return rck; }
        }
        public string rockwall
        { get { return rckwll; } }
    }
}
