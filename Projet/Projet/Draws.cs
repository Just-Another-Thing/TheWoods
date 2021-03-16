using Projet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet
{
    class Draws
    {
        static Thread thread = new Thread(DrawThread);
        private struct Param
        {
            public Cell[,] map;
            public int IconeType;
            public int test;
        }

        public static void Draw(Cell[,] map, int IconeType, int test = 0)
        {
            Param p = new Param();
            p.map = map;
            p.IconeType = IconeType;
            p.test = test;

            if (thread.IsAlive)
            {
                thread.Abort();
                thread = new Thread(DrawThread);
                thread.Start((object)p);
            }
            else
            {
                thread = new Thread(DrawThread);
                thread.Start((object)p);
            }
            

        }



        private static void DrawThread(object p)
        {
            Param param = (Param) p;
            Cell[,] map = param.map;
            int IconeType = param.IconeType;
            int test = param.test;

            int maxl = ((Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) / 2) - 1;
            int maxh = Console.WindowHeight - 1;
            int x = maxh - ((maxh + map.GetLength(0)) / 2);
            int y = maxl - maxl / 2 - map.GetLength(1) / 2;
            if (test == 0)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(y+j*2+1, x / 2 + i + 1);
                        if (map[i, j].GetType() == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (map[i, j].GetType() == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        else if (map[i, j].GetType() == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else if (map[i, j].GetType() == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (map[i, j].GetIsInFire() == 1 || map[i, j].GetIsInFire() == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(map[i, j].GetDisplaySymbol(IconeType) + " ");
                    }
                }
            }
            else if (test == 1)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write((int)(map[i, j].GetHeight() * 100) + "|");
                    }
                    Console.Write("\n");
                }
            }

        }
    }
}
