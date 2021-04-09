using System;

namespace Projet
{
    class Program
    {
        private static int onlyRedrawMap = 2;
        public static Cell[,] map;

        /// <summary>
        /// Region with all accessers/getters necessary for the project. 
        /// </summary>
        #region accessers
        static public void SetOnlyRedrawMap(int value)
        {
            onlyRedrawMap = value;
        }
        #endregion
        
        /// <summary>
        /// Start of the program.
        /// </summary>
        static void Main()
        {
            Console.CursorVisible = false;
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
        /// <summary>
        /// Simulate a round, and update the array map. 
        /// </summary>
        /// <param name="map">The 'map' array, where the game is stored.</param>
        public static void PassTour(Cell[,] map)
        {
            
            if (Slider.GetSliderListByID(4).GetLastSelect() == 0)
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
            Random rdm = new Random();
            bool canStartFire = false;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].GetIsFireable() == true && map[i, j].GetIsInFire() == 0)
                    {
                        canStartFire = true;
                    }
                }
            }
            int x;
            int y;
            if (canStartFire)
            {
                do
                {
                    x = rdm.Next(0, map.GetLength(0));
                    y = rdm.Next(0, map.GetLength(1));
                } while (map[x, y].GetIsFireable() == false || map[x,y].GetIsInFire() != 0);
                map[x, y].SetIsInFire(2);
            }
            
        }
    }
}
