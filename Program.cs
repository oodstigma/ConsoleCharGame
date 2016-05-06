using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCharGame
{
    class Program
    {
        static public int worldWidth = 65;
        static public int worldHeight = 20;

        static public int menuWidth = 15;
        static public int menuHeight = 1;

        static public string[,] display = new string[worldWidth, worldHeight];
        static public string[,] map = new string[worldWidth, worldHeight];

        static public string ground = "░";
        static public string tree = "T";
        static public string wall = "█";

        //0 = left/right wall, 1 = up/down wall, 2 = upperleft , 3 = upperright, 4 = lowerleft, 5 = lowerright
        static string[] menuBrdr = {"║", "═", "╔", "╗", "╚", "╝"};

        static string[] canDestroy = { tree, wall };

        static int numTree = 100;
        static int fps = 300;

        static Player player = new Player(1, 1);

        static bool gameOver = false;



        static void Main(string[] args)
        {

            CreateGameWorld();

            Console.CursorVisible = false;
            Console.SetWindowSize(worldWidth, worldHeight + 1);

            while (!gameOver)
            {
                GetInput();

                DrawWorld();

                System.Threading.Thread.Sleep(1000 / fps);
            }
        }
        //watches for the user input on the console window
        static void GetInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        gameOver = true;
                        break;
                    case ConsoleKey.W:
                        player.Move(Direction.Up);
                        player.DirectPlayer(2);
                        break;
                    case ConsoleKey.S:
                        player.Move(Direction.Down);
                        player.DirectPlayer(3);
                        break;
                    case ConsoleKey.A:
                        player.Move(Direction.Left);
                        player.DirectPlayer(0);
                        break;
                    case ConsoleKey.D:
                        player.Move(Direction.Right);
                        player.DirectPlayer(1);
                        break;
                    case ConsoleKey.E:
                        player.DestroyObject(canDestroy, "░");
                        break;
                    case ConsoleKey.Q:
                        player.PlaceObject(wall, tree);
                        break;
                    default:
                        break;
                }

                //clear the input buffer
                while (Console.KeyAvailable) { Console.ReadKey(); }
            }
        }

        static string windowBuffer = "";

        //create the trees
        static void CreateTrees()
        {
            Random rnd = new Random(48);

            for (int i = 0; i < numTree; i++)
            {
                display[rnd.Next(worldWidth), rnd.Next(worldHeight)] = tree;
            }
        }
        //puts the world into the console window
        static void DrawWorld()
        {

            string newScreen = "";

            for (int y = 0; y < worldHeight; y++)
            {
                string currentLine = "";
                for (int x = 0; x < worldWidth; x++)
                {
                    currentLine += display[x, y];
                }

                currentLine += "\n";

                if (y == player.y)
                {
                    currentLine = currentLine.Substring(0, player.x) + player.id + currentLine.Substring(player.x + 1);
                }
                newScreen = newScreen + currentLine;
            }

            if (newScreen != windowBuffer)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(newScreen);
            }

            windowBuffer = newScreen;
        }
        //places ground and trees on the world
        static void CreateGameWorld()
        {
            for (int y = 0; y < worldHeight; y++)
            {
                for (int x = 0; x < worldWidth; x++)
                {
                    display[x, y] = ground;
                }
                CreateTrees();
                //CreateMenuBoarder();
            }
        }

       /* static void CreateMenuBoarder()
        {
            for (int y = 0; y < worldHeight; y++)
            {
                for (int x = worldWidth + 1; x <= worldWidth + menuWidth; x++)
                {
                    if (y == 0)
                    {
                        if (x == worldWidth + 1)
                            display[x, y] = menuBrdr[2];
                        if (x > worldWidth + 1 && x < worldWidth + menuWidth - 5)
                            display[x, y] = menuBrdr[1];
                        //if (x == worldWidth + menuWidth)
                        //menu[x, y] = menuBrdr[3];
                    }
                }
            }
        }*/
    }
}
