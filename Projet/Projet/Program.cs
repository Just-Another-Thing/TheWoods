﻿using System;

namespace Projet
{
    class Program
    {
        static private int onlyRedrawMap = 2;
        public static Cell[,] map;
        #region accessers
        static public void SetOnlyRedrawMap(int value)
        {
            onlyRedrawMap = value;
        }
        #endregion
        
        //OUI
        static void Main(string[] args)
        {
            int[] activeSlider = { 0, 0};
            Slider.GenerateSlider();
            Menu.ProgrammStart();
            map = WoodGenerator.GenerateWoods();

            do
            {
                Draws.Draw(map, Slider.GetSliderListByID(3).GetLastSelect(), 0, activeSlider[0], onlyRedrawMap, activeSlider[1]);
                activeSlider = Navigation.NavigationManager(activeSlider);
            } while (activeSlider[0] != -1);
            




            Console.ReadKey();
            
        }



        public static void PassTour(Cell[,] map)
        {
            
            if (Slider.GetSliderListByID(4).GetLastSelect() == 0)
            {
                //les feux qui ont commencés au tour précédent deviennent propagateurs. 
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j].GetIsInFire() == 2)
                        {
                            map[i, j].SetIsInFire(1);
                        }
                    }
                }
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j].GetIsInFire() == 1 && map[i, j].GetLife() > 1)
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
                        else if (map[i, j].GetIsInFire() == 0 && (map[i, j].GetIsFireable() == true))
                        {
                            if (AreSurroundingInFire(map, i, j) == true)
                            {
                                map[i, j].SetIsInFire(2);
                            }
                        }

                    }
                }
            }
            Console.SetCursorPosition(0,0);
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

        public static void InitiateFire(Cell[,] map)
        {
            Random rdm = new Random();
            int x;
            int y;
            do
            {
                x = rdm.Next(0, map.GetLength(0));
                y = rdm.Next(0, map.GetLength(1));
            } while (map[x, y].GetIsFireable() == false || map[x,y].GetIsInFire() != 0);

            map[x, y].SetIsInFire(2);
        }
    }
}
