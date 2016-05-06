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

        static int numTree = 100;
        static int fps = 100;

        static Player player = new Player(1, 1);

        static bool gameOver = false;


        static void Main(string[] args)
        {

            CreateGameWorld();

            Console.CursorVisible = false;
            Console.SetWindowSize(worldWidth, worldHeight + 2);

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
                        player.DestroyObject(DisplayChar.canDestroy, "░");
                        break;
                    case ConsoleKey.Q:
                        player.PlaceObject(DisplayChar.wall, DisplayChar.tree);
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
                display[rnd.Next(worldWidth), rnd.Next(worldHeight)] = DisplayChar.tree;
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
                    display[x, y] = DisplayChar.ground;
                }
                CreateTrees();
                //CreateMenuBoarder();
            }
        }
    }
}
