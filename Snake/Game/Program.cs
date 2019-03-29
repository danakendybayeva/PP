using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Vars
            int[] xPosition = new int[50];
            xPosition[0] = 35;
            int[] yPosition = new int[50];
            yPosition[0] = 20;
            int appleXDim = 10;
            int appleYDim = 10;
            int applesEaten = 0;

            string userAction = "";

            decimal gameSpeed = 150m;

            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;
            bool isStayInMenu = true;

            Random random = new Random();

            Console.CursorVisible = false;
            #endregion
            // build welcome screen
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hello {0}", userName);
            ShowMenu(out userAction);
            // give player option to read directions
            do
            {
            
                switch (userAction)
                {

                    #region Case Play
                    case "1":
                    case "p":
                    case "play":
                        Console.Clear();
                        #region Game Setup
                        // get snake to appear on screen
                        PaintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

                        // set apple on screen
                        SetApplePositionOnScreen(random, out appleXDim, out appleYDim);
                        PaintApple(appleXDim, appleYDim);

                        // build boundry
                        buildWall();

                        ConsoleKey command = Console.ReadKey().Key;
                        #endregion
                        // get snake to move

                        do
                        {
                            #region Change Directions
                            switch (command)
                            {
                                case ConsoleKey.LeftArrow:
                                    Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                    Console.Write(" ");
                                    xPosition[0]--;
                                    break;
                                case ConsoleKey.UpArrow:
                                    Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                    Console.Write(" ");
                                    yPosition[0]--;
                                    break;
                                case ConsoleKey.RightArrow:
                                    Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                    Console.Write(" ");
                                    xPosition[0]++;
                                    break;
                                case ConsoleKey.DownArrow:
                                    Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                    Console.Write(" ");
                                    yPosition[0]++;
                                    break;
                            }
                            #endregion

                            #region Playing Game
                            //Paint the snake, make snake longer
                            PaintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

                            isWallHit = DidSnakeHitWall(xPosition[0], yPosition[0]);
                            // detect when snake hits boundry
                            if (isWallHit)
                            {
                                isGameOn = false;
                                Console.SetCursorPosition(9, 15);
                                Console.WriteLine("The snake hit the wall and died");

                                // show score
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(12, 16);
                                Console.Write("Your Score is {0}!", applesEaten * 100);
                                Console.SetCursorPosition(12, 17);
                                Console.WriteLine("Press enter to continue");
                                applesEaten = 0;
                                Console.ReadLine();
                                Console.Clear();
                                // give player option to replay the game
                                ShowMenu(out userAction);
                            }

                            // detect when apple was eaten
                            isAppleEaten = DetermineIfAppleWasEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);

                            // Place apple on board(random)
                            if (isAppleEaten)
                            {
                                SetApplePositionOnScreen(random, out appleXDim, out appleYDim);
                                PaintApple(appleXDim, appleYDim);
                                // keep track of how many apples were eaten
                                applesEaten++;
                                // make snake faster
                                gameSpeed *= .925m;
                                
                            }
                            
                            if (Console.KeyAvailable) command = Console.ReadKey().Key;
                            //slow game down
                            System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));
                            #endregion
                        } while (isGameOn);
                        break;
                    #endregion

                    case "2":
                    case "e":
                    case "exit":
                        isStayInMenu = false;
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Your input was not understood, please press enter and try again");
                        Console.ReadLine();
                        Console.Clear();
                        ShowMenu(out userAction);
                        break;
                }
            } while (isStayInMenu);
        }

        

        #region Methods
        #region Menu
        private static void ShowMenu(out string userAction)
        {
            string menu = "1) Play\n2) Exit";
            Console.WriteLine(menu);
            userAction = Console.ReadLine().ToLower();
        }
        #endregion
        private static void PaintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            // Paint the head
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("O");

            // Paint the body
            for(int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }

            // Erase last part of snake
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(" ");

            // Record the location of each body part
            for(int i = applesEaten +1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }

            // Return the new array
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        }//end Paint snake

        private static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 50 || yPosition == 1 || yPosition == 29) return true;
            return false;
        }

        private static void buildWall()
        {
            for(int i = 1; i < 30; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.WriteLine("#");
                Console.SetCursorPosition(50, i);
                Console.WriteLine("#");
            }
            for (int i = 1; i < 51; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("#");
                Console.SetCursorPosition(i, 29);
                Console.WriteLine("#");
            }
        }//end Build Wall

        private static void SetApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
        {
            appleXDim = random.Next(0 + 2, 50 - 2);
            appleYDim = random.Next(0 + 2, 29 - 2);
        }

        private static void PaintApple(int appleXDim, int appleYDim)
        {
            Console.SetCursorPosition(appleXDim, appleYDim);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
        }
        private static bool DetermineIfAppleWasEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
        {
            if (xPosition == appleXDim && yPosition == appleYDim) return true;
            return false;

        }
        public bool IsIntersected(List<Point> points)
        {
            bool res = false;

            foreach(Point p in points)
            {
                if(p.X == body[0].X && p.Y == body[0].Y)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }
        #endregion
    }
}
