using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu.ProgrammStart();
            Console.ReadKey();




            /**
                Cell[,] map = WoodGenerator.generateWoods(55, 29);
                draw(map);
                Console.ReadKey();
                initiateFire(map);
                Console.SetCursorPosition(0, 0);
                draw(map);
                while (true)
                {
                    passTour(map);
                    ConsoleKey k =Console.ReadKey().Key;
                    if (k == ConsoleKey.F)
                    {
                        initiateFire(map);
                    }
                }
            */
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
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (map[i, j].getIsInFire() == 1 || map[i, j].getIsInFire() == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
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
                    if (map[i,j].getIsInFire() == 2)
                    {
                        map[i, j].setIsInFire(1);
                    }
                    if (map[i,j].getIsInFire() == 1 && map[i,j].getLife() > 1)
                    {
                        map[i, j].setLife(map[i, j].getLife() - 1);
                    }
                    else if (map[i, j].getIsInFire() == 1 && map[i, j].getLife() == 1)
                    {
                        map[i, j].setType(7);
                        map[i, j].setLife(0);
                    }
                    else if (map[i, j].getIsInFire() == 1 && map[i, j].getLife() == 0)
                    {
                        map[i, j].setType(8);
                        map[i, j].setIsInFire(0);
                        map[i, j].setIsFireable(false);
                    }
                    else if (map[i,j].getIsInFire() == 0 && (map[i,j].getIsFireable() == true))
                    {
                        if (areSurroundingInFire(map, i, j)== true)
                        {
                            map[i, j].setIsInFire(2);
                        }
                    }
                    
                }
            }
            Console.SetCursorPosition(0,0);
            draw(map);
        }

        static bool areSurroundingInFire(Cell[,] map, int x, int y)
        {
            int somme = 0;
            if (x > 0)
            {
                if (map[x - 1, y].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[map.GetLength(0)-1, y].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y > 0)
            {
                if (map[x, y - 1].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[x, map.GetLength(1)-1].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y > 0 && x > 0)
            {
                if (map[x - 1, y - 1].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[map.GetLength(0)-1, map.GetLength(1)-1].getIsInFire() == 1)
                {
                    somme++;
                }
            }

            if (x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[0, y].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y < map.GetLength(1) - 1)
            {
                if (map[x, y + 1].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[x, 0].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y < map.GetLength(1) - 1 && x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y + 1].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[0,0].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y > 0 && x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y - 1].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[0, map.GetLength(1) - 1].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y < map.GetLength(1) - 1 && x > 0)
            {
                if (map[x - 1, y + 1].getIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[map.GetLength(0) - 1, 0].getIsInFire() == 1)
                {
                    somme++;
                }
            }

            if (somme > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        static void initiateFire(Cell[,] map)
        {
            Random rdm = new Random();
            int x;
            int y;
            do
            {
                x = rdm.Next(0, map.GetLength(0) - 1);
                y = rdm.Next(0, map.GetLength(1) - 1);
            } while (map[x, y].getIsFireable() == false || map[x,y].getIsInFire() != 0);

            map[x, y].setIsInFire(2);
        }
    }
}
