using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCharGame
{
    //player class that stores data need for the player
    class Player
    {
        public string id = "@";
        public int x = 0;
        public int y = 0;

        Inventory inv = new Inventory();

        public bool[] direction = { true, false, false, false };

        /// <summary>
        /// creates a new player
        /// </summary>
        /// <param name="x">where on the x axis the player should be</param>
        /// <param name="y">where on the y axis the player should be</param>
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Move(Direction dir)
        {
            bool moved = false;

            int newX = x;
            int newY = y;

            switch (dir)
            {
                case Direction.Up:
                        newY--;
                        DirectPlayer(2);
                    break;
                case Direction.Down:
                        newY++;
                        DirectPlayer(3);
                    break;
                case Direction.Left:
                        newX--;
                        DirectPlayer(0);
                    break;
                case Direction.Right:
                        newX++;
                        DirectPlayer(1);
                    break;
            }

            int worldWidth = Program.display.GetLength(0);
            int worldHeight = Program.display.GetLength(1);

            newX = (newX + worldWidth) % worldWidth;
            newY = (newY + worldHeight) % worldHeight;

            if (Program.display[newX, newY] == Program.ground)
            {
                x = newX;
                y = newY;
                moved = true;
            }

            return moved;
        }

        public string[] SenseObjAround()
        {

            string left = "";
            string right = "";
            string up = "";
            string down = "";

                left = Program.display[x - 1, y];
            if (x + 1< Program.worldWidth)
                right = Program.display[x + 1, y];
            if (y > 0)
                up = Program.display[x, y - 1];
            if (y < Program.worldHeight - 1)
                down = Program.display[x, y + 1];

            List<string> objects = new List<string>();

                objects.Add(left);
                objects.Add(right);
                objects.Add(up);
                objects.Add(down);

            return objects.ToArray();
        }

        //what ever direction is selected, the object in front will be replaced
        public void DestroyObject(string[] objs, string replacement)
        {
            string[] allAround = SenseObjAround();
            for (int i = 0; i < 4; i++)
            {
                foreach (string obj in objs)
                { 
                    if (direction[i] && allAround[i] == obj)
                    {
                        switch (i)
                        {
                            case 0:
                                Program.display[x - 1, y] = replacement;
                                break;
                            case 1:
                                Program.display[x + 1, y] = replacement;
                                break;
                            case 2:
                                Program.display[x, y - 1] = replacement;
                                break;
                            case 3:
                                Program.display[x, y + 1] = replacement;
                                break;
                        }
                        if (obj == Program.tree)
                            inv.ModInv("wood", 1);
                        Console.WriteLine(inv.wood);
                        if (obj == Program.wall)
                            inv.ModInv("wood", 1);
                    }
                }
            }
        }

        //0 = left, 1 = right, 2 = up, 3 = down
        public void DirectPlayer(int direct)
        {
            for(int i = 0; i < 4; i++)
            {
                direction[i] = false;
            }

            if (direct == 0)
                direction[0] = true;
            if (direct == 1)
                direction[1] = true;
            if (direct == 2)
                direction[2] = true;
            if (direct == 3)
                direction[3] = true;

        }

        //what ever direction is selected, an object of choosing will be placed
        public void PlaceObject(string replacement, string limit)
        {

            string[] allAround = SenseObjAround();

            for (int i = 0; i < 4; i++)
            {
                if (direction[i] && inv.wood > 0 && allAround[i] != limit)
                {
                    if (i == 0)
                        Program.display[x, y] = replacement;
                    if (i == 1)
                        Program.display[x, y] = replacement;
                    if (i == 2)
                        Program.display[x, y] = replacement;
                    if (i == 3)
                        Program.display[x, y] = replacement;


                }
            }
            if (replacement == Program.wall && inv.wood > 0)
                inv.ModInv("wood", -1);
            Console.WriteLine(inv.wood);
        }
    }

    public enum Direction
    {
        Up, Down, Left, Right
    }


}
