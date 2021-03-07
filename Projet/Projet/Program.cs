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
            Config.ClearConsole(null);
            Navigation.SetDesignNav();

            

            Console.ReadKey();


            /**
                Cell[,] map = WoodGenerator.GenerateWoods(55, 29);
                Draw(map);
                Console.ReadKey();
                InitiateFire(map);
                Console.SetCursorPosition(0, 0);
                Draw(map);
                while (true)
                {
                    PassTour(map);
                    ConsoleKey k =Console.ReadKey().Key;
                    if (k == ConsoleKey.F)
                    {
                        InitiateFire(map);
                    }
                }
            */
            
        }

        

        static void Draw(Cell[,] map)
        {
            for (int i=0; i<map.GetLength(0); i++)
            {
                for (int j=0; j<map.GetLength(1); j++)
                {
                    if (map[i,j].GetType() == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    } else if(map[i,j].GetType() == 2)
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
                    
                    Console.Write(map[i, j].GetDisplaySymbol() + " ");
                }
                Console.Write("\n");
            }
        }

        static void PassTour(Cell[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j].GetIsInFire() == 2)
                    {
                        map[i, j].SetIsInFire(1);
                    }
                    if (map[i,j].GetIsInFire() == 1 && map[i,j].GetLife() > 1)
                    {
                        map[i, j].SetLife(map[i, j].GetLife() - 1);
                    }
                    else if (map[i, j].GetIsInFire() == 1 && map[i, j].GetLife() == 1)
                    {
                        map[i, j].SetType(7);
                        map[i, j].SetLife(0);
                    }
                    else if (map[i, j].GetIsInFire() == 1 && map[i, j].GetLife() == 0)
                    {
                        map[i, j].SetType(8);
                        map[i, j].SetIsInFire(0);
                        map[i, j].SetIsFireable(false);
                    }
                    else if (map[i,j].GetIsInFire() == 0 && (map[i,j].GetIsFireable() == true))
                    {
                        if (AreSurroundingInFire(map, i, j)== true)
                        {
                            map[i, j].SetIsInFire(2);
                        }
                    }
                    
                }
            }
            Console.SetCursorPosition(0,0);
            Draw(map);
        }

        static bool AreSurroundingInFire(Cell[,] map, int x, int y)
        {
            int somme = 0;
            if (x > 0)
            {
                if (map[x - 1, y].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[map.GetLength(0)-1, y].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y > 0)
            {
                if (map[x, y - 1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[x, map.GetLength(1)-1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y > 0 && x > 0)
            {
                if (map[x - 1, y - 1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[map.GetLength(0)-1, map.GetLength(1)-1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }

            if (x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[0, y].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y < map.GetLength(1) - 1)
            {
                if (map[x, y + 1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[x, 0].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y < map.GetLength(1) - 1 && x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y + 1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[0,0].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y > 0 && x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y - 1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[0, map.GetLength(1) - 1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            if (y < map.GetLength(1) - 1 && x > 0)
            {
                if (map[x - 1, y + 1].GetIsInFire() == 1)
                {
                    somme++;
                }
            }
            else
            {
                if (map[map.GetLength(0) - 1, 0].GetIsInFire() == 1)
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

        static void InitiateFire(Cell[,] map)
        {
            Random rdm = new Random();
            int x;
            int y;
            do
            {
                x = rdm.Next(0, map.GetLength(0) - 1);
                y = rdm.Next(0, map.GetLength(1) - 1);
            } while (map[x, y].GetIsFireable() == false || map[x,y].GetIsInFire() != 0);

            map[x, y].SetIsInFire(2);
        }
    }
}
