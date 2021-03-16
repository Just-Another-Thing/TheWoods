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

        public static Cell[,] map;
        static void Main(string[] args)
        {
            int activeSlider = 0;
            Slider.GenerateSlider();
            Menu.ProgrammStart();
            map = WoodGenerator.GenerateWoods();

            do
            {
                Draws.Draw(map, Navigation.GetSliderListByID(3).GetLastSelect(), 0, activeSlider);
                activeSlider = Navigation.NavigationManager(activeSlider, WoodGenerator.GenerateWoods());
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

        

        public static void PassTour(Cell[,] map)
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
