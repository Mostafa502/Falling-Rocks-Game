using static System.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DropRock
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Rock Drop";

            WindowWidth = 50;
            WindowHeight = 30;
            BufferWidth = 50;
            BufferHeight = 30;
            BackgroundColor = ConsoleColor.DarkGray;
            ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(0, 4);
            Write("Please, Enter your name : ");
            string name = ReadLine();
            WriteLine("Hello {0} ,Press any key to start => ", name);
            ReadKey();
            Start();
            bool bo = true;
            while (bo)
            {

                SetCursorPosition(10, 13);
                Write(@"Press (y) or (Y) to play again 
                else press any other key : ");
                string check = ReadLine();
                if (!(check == "y" || check == "Y"))
                    bo = false;
                else
                    Start();
            }
        }
        /******StartMethods******/
        static void Start()
        {
            LinkedList<Rock> rocks = new LinkedList<Rock>();
            char[] coll = {'#', '@', '^', '$',
                '*', '+', '%', '!',
                '.', ';', '&', '-' };
            int x = 25, y = 29, c = 0;
            Random rand = new Random();

            while (true)
            {
                Clear();
                if (c % 2 == 0)
                {
                    Rock R = new Rock(rand.Next(0, 50), 0, coll[rand.Next(0, 11)]);
                    rocks.AddFirst(R);
                }
                drawRocks(rocks);

                foreach (Rock rock in rocks)
                {
                    rock.y++;
                    if (rock.y == 30)
                    {
                        rock.representation = coll[rand.Next(0, 11)];
                        rock.x = rand.Next(0, 50);
                        rock.y = 0;
                    }
                }
                Player(ref x, ref y);
                if (!hit(x, rocks))
                {
                    break;
                }
                c++;
                Thread.Sleep(150);
            }
            Console.Beep();
            //WriteLine('\a');
            Clear();
            SetCursorPosition(10, 9);
            Write("GAME OVER");
            SetCursorPosition(10, 11);
            WriteLine("Score : {0}", c / 3);
        }
        /************/
        static void drawRocks(LinkedList<Rock> rocks)
        {
            foreach (Rock rock in rocks)
            {
                SetCursorPosition(rock.x, rock.y);
                Write(rock.representation);
            }
        }
        /************/
        static void Player(ref int x, ref int y)
        {
            int wid = 50;
            char toWrite = 'Q';
            SetCursorPosition(x, y);
            Write(toWrite);

            if (KeyAvailable && x >= 0 && x <= 50)
            {
                var command = ReadKey().Key;
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < wid - 2)
                        {
                            x++;
                        }
                        break;
                }
            }
            Thread.Sleep(20);
        }
        /************/
        static bool hit(int x, LinkedList<Rock> rocks)
        {
            foreach (Rock rock in rocks)
            {
                if (rock.x == x && rock.y == 29)
                {
                    return false;
                }
            }
            return true;
        }
        /******Finish Methods******/
    }
    //Class of rocks
    public class Rock{
        public int x,y;
        public char representation;        
        public Rock(int x, int y, char representation) {
            this.x = x;
            this.y = y;
            this.representation = representation;
}   }   }