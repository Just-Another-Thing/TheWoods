using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class WoodGenerator
    {
        private static int treeProportion = 100;
        private static int waterProportion = 100;
        private static int leaveProportion = 100;
        private static int rockProportion = 100;
        private static int grassProportion = 100;

        #region getters && setters
        public static int GetTreeProportion()
        {
            return treeProportion;
        }
        public static void SetTreeProportion(int proportion)
        {
            treeProportion = proportion;
        }

        public static int GetWaterProportion()
        {
            return waterProportion;
        }
        public static void SetWaterProportion(int proportion)
        {
            waterProportion = proportion;
        }

        public static int GetLeaveProportion()
        {
            return leaveProportion;
        }
        public static void SetLeaveProportion(int proportion)
        {
            leaveProportion = proportion;
        }

        public static int GetRockProportion()
        {
            return rockProportion;
        }
        public static void SetRockProportion(int proportion)
        {
            rockProportion = proportion;
        }

        public static int GetGrassProportion()
        {
            return grassProportion;
        }
        public static void SetGrassProportion(int proportion)
        {
            grassProportion = proportion;
        }

        #endregion


        public static Cell[,] GenerateWoods(int l, int c)
        {
            Random rdm = new Random();
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
            Console.Write(treeProportion);
            //generate trees
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    float pourc = GetSurrounding(map, i, j, 2);
                    float rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 8 + 10)*(treeProportion/100))
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
                    if (rand <= (pourc * 6 + 10)*(waterProportion/100))
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
                    int pourc = GetSurrounding(map, i, j, 2);
                    int rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 10)*(leaveProportion / 100) && map[i, j].GetType() == 3)
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
                    int pourc = GetSurrounding(map, i, j, 5);
                    int rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 6 + 10)* (rockProportion / 100) && map[i, j].GetType() == 3)
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
                    int pourc = GetSurrounding(map, i, j, 5)/2;
                    pourc += GetSurrounding(map, i, j, 2) / 2;
                    int rand = rdm.Next(0, 100);
                    if (rand <= (pourc * 12)*(grassProportion / 100) && map[i, j].GetType() == 3)
                    {
                        map[i, j].SetType(1);
                        map[i, j].SetLife(8);
                        map[i, j].SetIsFireable(true);
                    }
                }
            }


            return map;
        }

        private static int HeightSurrounding(Cell[,] map, int x, int y)
        {
            float height = 0;
            for (int i=-1; i<=1; i++)
            {
                for (int j=-1; j<=1; j++)
                {
                    Cell c = GetCase(map, x+i, y+j);
                    height += c.GetHeight();
                }
            }
            return 0;
        }

        private static int GetSurrounding(Cell[,] map, int x, int y, int type)
        {
            int somme = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Cell c = GetCase(map, x + i, y + j);
                    if (c.GetType() == type)
                    {
                        somme += 1;
                    }
                }
            }
            return somme;
        }

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
