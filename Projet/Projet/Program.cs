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
            Cell[,] map = generateWoods(10, 10);
            draw(map);
            Console.ReadKey();
        }

        static Cell[,] generateWoods(int l, int c)
        {
            Cell[,] map = new Cell[c, l];
            for (int i = 0; i <= map.GetLength(0); i++)
            {
                for (int j = 0; j <= map.GetLength(1); j++)
                {
                    map[i, j].setRandomValue();
                }
            }
            return map;
        }

        static void draw(Cell[,] map)
        {
            for (int i=0; i<=map.GetLength(0); i++)
            {
                for (int j=0; j<=map.GetLength(1); j++)
                {
                    Console.Write(map[i, j].getDisplaySymbol() + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
