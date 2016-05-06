using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCharGame
{
    class Inventory
    {
        public int wood = 0;
        public int stone = 0;

        public void ModInv(string item, int value)
        {
            switch (item)
            {
                case "wood":
                    wood = wood + value;
                    break;
                case "stone":
                    stone = stone + value;
                    break;
            }
        }
    }
}
