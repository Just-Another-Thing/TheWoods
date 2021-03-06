using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell[,] map = WoodGenerator.generateWoods(55, 30);
            draw(map);
            Console.ReadKey();
        }

        

        static void draw(Cell[,] map)
        {
            for (int i=0; i<map.GetLength(0); i++)
            {
                for (int j=0; j<map.GetLength(1); j++)
                {
                    if (map[i,j].getType() == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    } else if(map[i,j].getType() == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else if (map[i, j].getType() == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (map[i, j].getType() == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j].getIsInFire() == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(map[i, j].getDisplaySymbol() + " ");
                }
                Console.Write("\n");
            }
        }

        static void passTour(Cell[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j].getIsInFire() == true && map[i,j].getLife() > 1)
                    {
                        map[i, j].setLife(map[i, j].getLife() - 1);
                    }
                }
            }
        }
    }
}
