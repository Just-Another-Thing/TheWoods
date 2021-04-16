﻿using System;

namespace TheWoods
{
    class WoodGenerator
    {
        private static int _treeProportion = 100;
        private static int _waterProportion = 100;
        private static int _leaveProportion = 100;
        private static int _rockProportion = 100;
        private static int _grassProportion = 100;

        /// <summary>
        /// Region with all accessers/getters necessary for the project. 
        /// </summary>
        #region getters && setters
        public static int GetTreeProportion()
        {
            return _treeProportion;
        }
        public static void SetTreeProportion(int proportion)
        {
            _treeProportion = proportion;
        }

        public static int GetWaterProportion()
        {
            return _waterProportion;
        }
        public static void SetWaterProportion(int proportion)
        {
            _waterProportion = proportion;
        }

        public static int GetLeaveProportion()
        {
            return _leaveProportion;
        }
        public static void SetLeaveProportion(int proportion)
        {
            _leaveProportion = proportion;
        }

        public static int GetRockProportion()
        {
            return _rockProportion;
        }
        public static void SetRockProportion(int proportion)
        {
            _rockProportion = proportion;
        }

        public static int GetGrassProportion()
        {
            return _grassProportion;
        }
        public static void SetGrassProportion(int proportion)
        {
            _grassProportion = proportion;
        }

        #endregion

        /// <summary>
        /// Generate the woods with semi random generation. 
        /// </summary>
        /// <returns>A Cell array already filled</returns>
        public static void GenerateWoods()
        {
            int maxl = ((Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) / 2) - 1;
            int maxm = Console.WindowHeight - 1;
            int l = (Slider.GetSliderListById(1).GetLastSelect() + 1) * maxl / Slider.GetSliderListById(1).GetValue().Length;
            int c = (Slider.GetSliderListById(2).GetLastSelect() + 1) * maxm / Slider.GetSliderListById(2).GetValue().Length;


            Random rdm = Program.GetRandom();
            Cell[,] map = new Cell[c, l];

            //generate terrain
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j].SetType(3);
                    map[i, j].SetLife(0);
                }
            }
            //generate trees
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    float pourc = GetSurrounding(map, i, j, 2);
                    float rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 8 + 10)+(_treeProportion/10-10))
                    {
                        map[i, j].SetType(2);
                        map[i, j].SetLife(10);
                        map[i, j].SetIsFireable(true);
                    }
                }
            }

            
            //generate water
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    float pourc = GetSurrounding(map, i, j, 5);
                    float rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 6 + 10)+(_waterProportion/10-10) && map[i, j].GetCellType() == 3)
                    {
                        map[i, j].SetType(5);
                        map[i, j].SetLife(0);
                    }
                    
                }
            } 

            //generate leaves
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    float pourc = GetSurrounding(map, i, j, 2);
                    float rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 10)+(_leaveProportion / 10-10) && map[i, j].GetCellType() == 3)
                    {
                        map[i, j].SetType(4);
                        map[i, j].SetLife(4);
                        map[i, j].SetIsFireable(true);
                    }
                }
            }

            //generate rocks
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    float pourc = GetSurrounding(map, i, j, 5);
                    float rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 6 + 10) + (_rockProportion / 10-10) && map[i, j].GetCellType() == 3)
                    {
                        map[i, j].SetType(6);
                        map[i, j].SetLife(0);
                    }
                }
            }
            //generate grass
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    float pourc = (float) GetSurrounding(map, i, j, 5)/2;
                    pourc +=  (float) GetSurrounding(map, i, j, 2) / 2;
                    float rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 12)+(_grassProportion / 10-10) && map[i, j].GetCellType() == 3)
                    {
                        map[i, j].SetType(1);
                        map[i, j].SetLife(8);
                        map[i, j].SetIsFireable(true);
                    }
                }
            }

            Program.SaveMaps(map, true);
        }
        /// <summary>
        /// Get the amount of cell with specific type around a specific cell. 
        /// </summary>
        /// <param name="map">The 'map' array, where the game is stored</param>
        /// <param name="x">Abscissa position of the cell to check</param>
        /// <param name="y">Ordonate position of the cell to check</param>
        /// <param name="type">The cell's type to check</param>
        /// <returns>The amount of cell fullfilling the test</returns>
        private static int GetSurrounding(Cell[,] map, int x, int y, int type)
        {
            int somme = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Cell c = GetCase(map, x + i, y + j);
                    if (c.GetCellType() == type)
                    {
                        somme += 1;
                    }
                }
            }
            return somme;
        }

        /// <summary>
        /// Return a cell at a specific place, with connection between edges. 
        /// </summary>
        /// <param name="map">The 'map' array, where the game is stored</param>
        /// <param name="x">Abscissa position of the cell to check</param>
        /// <param name="y">Ordonate position of the cell to check</param>
        /// <returns>The cell</returns>
        public static Cell GetCase(Cell[,] map, int x, int y)
        {
            Cell rtrn;

            if (x < 0)
            {
                x = map.GetLength(0) - 1;
            }
            if (y < 0)
            {
                y = map.GetLength(1) - 1;
            }
            if (x == map.GetLength(0))
            {
                x = 0;
            }
            if (y == map.GetLength(1))
            {
                y = 0;
            }

            rtrn = map[x, y];

            return rtrn;
        }

    }
}
