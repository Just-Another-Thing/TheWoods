﻿using System;
using System.Collections.Generic;

namespace TheWoods
{
    class Program
    {
        private static int _onlyRedrawMap = 2;
        private static List<Cell[,]> maps= new List<Cell[,]>();
        private static int _turn = 0;
        private static readonly Random Rdm = new Random();
        /// <summary>
        /// Region with all accessers/getters necessary for the project. 
        /// </summary>
        #region accessers
        public static void SetOnlyRedrawMap(int value)
        {
            _onlyRedrawMap = value;
        }

        public static List<Cell[,]> GetMaps()
        {
            return maps;
        }

        public static Cell[,] GetMap(int version = 0)
        {
            return maps[Program.GetTurn()];
        }

        public static int GetTurn()
        {
            return _turn;
        }

        public static void SetTurn(int value)
        {
            _turn = value;
        }

        public static void IncrTurn()
        {
            _turn++;
        }

        public static void DecrTurn()
        {
            _turn--;
        }

        public static Random GetRandom()
        {
            return Rdm;
        }
        #endregion
        
        /// <summary>
        /// Start of the program.
        /// </summary>
        static void Main()
        {
            int[] activeSlider = { 0, 0};
            Slider.GenerateSlider();
            Menu.ProgrammStart();
            Console.Clear();
            WoodGenerator.GenerateWoods();
            Console.CursorVisible = false;
            
            do
            {
                Draws.Draw(GetMap(), Slider.GetSliderListById(3).GetLastSelect(), 0, activeSlider[0], _onlyRedrawMap, activeSlider[1], _turn, GetMaps().Count-1);
                activeSlider = Navigation.NavigationManager(activeSlider);
            } while (activeSlider[0] != -1);
            
            Console.ReadKey();
            
        }
        /// <summary>
        /// Simulate a round, and update the array map. 
        /// </summary>
        /// <param name="map">The 'map' array, where the game is stored.</param>
        public static void PassTour(Cell[,] map)
        {
            
            if (Slider.GetSliderListById(4).GetLastSelect() == 0)
            {
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
                        else if (map[i, j].GetIsInFire() == 0 && (map[i, j].GetIsFireable()))
                        {
                            if (AreSurroundingInFire(map, i, j))
                            {
                                map[i, j].SetIsInFire(2);
                            }
                        }

                    }
                }
            }
            Console.SetCursorPosition(0,0);
        }

        /// <summary>
        /// Check if there is fire in the surrounding area.  
        /// </summary>
        /// <param name="map">The 'map' array, where the game is stored</param>
        /// <param name="x">The abscissa position of the cell</param>
        /// <param name="y">The ordinate position of the cell</param>
        /// <returns>Return if there is at least one cell in fire in the surrounding area</returns>
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

        /// <summary>
        /// Initiate a new fire pit on the map.
        /// </summary>
        /// <param name="map">The 'map' array, where the game is stored.</param>
        public static void InitiateFire(Cell[,] map)
        {
            bool canStartFire = false;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].GetIsFireable() && map[i, j].GetIsInFire() == 0)
                    {
                        canStartFire = true;
                    }
                }
            }

            
            if (canStartFire)
            {
                int x;
                int y;
                do
                {
                    x = Program.Rdm.Next(0, map.GetLength(0));
                    y = Program.Rdm.Next(0, map.GetLength(1));
                } while (map[x, y].GetIsFireable() == false || map[x, y].GetIsInFire() != 0);

                map[x, y].SetIsInFire(2);
            }
            
        }

        public static void SaveMaps(Cell[,] map, bool restart)
        {
            if (restart)
            {
                maps.Clear();
                maps.Add(map);
                _turn = 0;
            }
            else
            {
                Cell[,] temp = new Cell[map.GetLength(0), map.GetLength(1)];
                for (int i =0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        temp[i, j] = map[i, j];
                    }
                }
                maps.Add(temp);
                _turn++;
            }
            
        }
    }
}
