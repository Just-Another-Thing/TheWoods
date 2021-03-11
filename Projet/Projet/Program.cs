using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Projet
{
    class Program
    {

        public static Cell[,] map = WoodGenerator.GenerateWoods(3, 3);
        static void Main(string[] args)
        {
            int activeSlider = 0;

            Menu.ProgrammStart();
            Navigation.SetDesignNav();
            Slider[] SliderList = Menu.GenerateSlider();
            Menu.DisplaySlider(SliderList, activeSlider);
            Program.map = WoodGenerator.GenerateWoods(30, 30);
            do
            {
                activeSlider = Navigation.NavigationManager(SliderList, activeSlider, WoodGenerator.GenerateWoods(55, 29));
                Navigation.SetDesignNav();
                Menu.DisplaySlider(SliderList, activeSlider);
                Draw(Program.map, SliderList[2].GetLastSelect(), 0);
            } while (activeSlider != -1);
            




            Console.ReadKey();


            
                /*Cell[,] map = WoodGenerator.GenerateWoods(55, 29);
                Draw(map, 0);
                Console.ReadKey();
                InitiateFire(map);
                Console.SetCursorPosition(0, 0);
                Draw(map, 0);
                while (true)
                {
                    PassTour(map);
                    ConsoleKey k =Console.ReadKey().Key;
                    if (k == ConsoleKey.F)
                    {
                        InitiateFire(map);
                    }
                }*/
            
            
        }

        

        public static void Draw(Cell[,] map, int IconeType, int test = 0)
        {
            int maxl = ((Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) / 2) - 1;
            int maxh = Console.WindowHeight - 1;
            int x = maxh - ((maxh+ map.GetLength(0))/2);
            int y = maxl - maxl/2 - map.GetLength(1)/2;
            Debug.WriteLine(map.GetLength(0));
            if (test == 0)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    Console.SetCursorPosition(y, x/2+i+1);
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j].GetType() == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
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
                        Console.Write((int)(map[i, j].GetHeight()*100)+"|");
                    }
                    Console.Write("\n");
                }
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
            //Draw(map, 0);
        }

        static bool AreSurroundingInFire(Cell[,] map, int x, int y)
        {
            int somme = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Cell c = WoodGenerator.GetCase(map, x + i, y + j);
                    if (c.GetIsInFire() == 1)
                    {
                        somme++;
                    }
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
