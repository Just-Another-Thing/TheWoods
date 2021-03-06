using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class WoodGenerator
    {
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

            //generate trees
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int pourc = GetSurrounding(map, i, j, 2);
                    int rand = rdm.Next(0, 100);
                    if (rand <= pourc * 8 + 10)
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
                    int pourc = GetSurrounding(map, i, j, 5);
                    int rand = rdm.Next(0, 100);
                    if (rand <= pourc * 12 + 4 && map[i,j].GetType() == 3)
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
                    if (rand <= pourc * 10 && map[i, j].GetType() == 3)
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
                    if (rand <= pourc * 6 + 10 && map[i, j].GetType() == 3)
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
                    if (rand <= pourc * 12 && map[i, j].GetType() == 3)
                    {
                        map[i, j].SetType(1);
                        map[i, j].SetLife(8);
                        map[i, j].SetIsFireable(true);
                    }
                }
            }


            return map;
        }

        private static int GetSurrounding(Cell[,] map, int x, int y, int type)
        {
            int somme = 0;
            if (x > 0)
            {
                if (map[x - 1,y].GetType() == type)
                {
                    somme++;
                }
            }
            if (y > 0)
            {
                if (map[x, y - 1].GetType() == type)
                {
                    somme++;
                }
            }
            if (y > 0 && x > 0)
            {
                if (map[x - 1, y - 1].GetType() == type)
                {
                    somme++;
                }
            }

            if (x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y].GetType() == type)
                {
                    somme++;
                }
            }
            if(y < map.GetLength(1) - 1)
            {
                if (map[x, y + 1].GetType() == type)
                {
                    somme++;
                }
            }
            if (y < map.GetLength(1) - 1 && x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y + 1].GetType() == type)
                {
                    somme++;
                }
            }
            if (y>0 && x < map.GetLength(0) - 1)
            {
                if (map[x + 1, y - 1].GetType() == type)
                {
                    somme++;
                }
            }
            if (y < map.GetLength(1) - 1 && x > 0)
            {
                if (map[x - 1, y + 1].GetType() == type)
                {
                    somme++;
                }
            }
            return somme;
        }
        
    }
}
