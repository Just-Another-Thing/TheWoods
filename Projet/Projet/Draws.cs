using System;
using System.Threading;

namespace Projet
{
    class Draws
    {
        static Thread mthread = new Thread(DrawMap);
        /// <summary>
        /// Parameters structure.
        /// </summary>
        private struct Param
        {
            public Cell[,] map;
            public int IconeType;
            public int test;
            public int selectTab;
            public int oldSelectTab;
            public int onlyRedrawMap;
        }
        /// <summary>
        /// Map display, with thread management. 
        /// </summary>
        /// <param name="map">The 'map' array, where the game is stored</param>
        /// <param name="IconeType">Icone type</param>
        /// <param name="test">Jsut for test purpose, only there because it could be useful in specifics cases</param>
        /// <param name="activeSlider">The slider in use</param>
        /// <param name="onlyRedrawMap"> Allow to choose what to redraw : the map, the sliders or both (0,1,2)</param>
        /// <param name="oldSelectSlider">The old selected slider</param>
        public static void Draw(Cell[,] map, int IconeType, int test, int activeSlider, int onlyRedrawMap, int oldSelectSlider)
        {
            Param p;
            p.map = map;
            p.IconeType = IconeType;
            p.test = test;
            p.selectTab = activeSlider;
            p.oldSelectTab = oldSelectSlider;
            p.onlyRedrawMap = onlyRedrawMap;

            if (mthread.IsAlive)
            {
                mthread.Abort();
                mthread = new Thread(DrawMap);
                mthread.Start((object) p);
            }
            else
            {
                mthread = new Thread(DrawMap);
                mthread.Start((object) p);
            }

            
        }
        /// <summary>
        /// Display of the map.
        /// </summary>
        /// <param name="p">All parameters of the map</param>
        private static void DrawMap(object p)
        {
            Param param = (Param) p;
            Cell[,] map = param.map;
            int IconeType = param.IconeType;
            int test = param.test;
            int active = param.selectTab;
            int oldActive = param.oldSelectTab;
            int redraw = param.onlyRedrawMap;

            if (redraw == 2)
            {
                Config.ClearConsole("Jeu en cours");
            }
            
            if (redraw == 1 || redraw == 2)
            {
                for (int j = (Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) + 1; j < Console.WindowWidth - 2; j++)
                {
                    Console.SetCursorPosition(j, Slider.GetSliderListByID(oldActive).GetPosition()+1);
                    Console.Write(" "); 
                    Console.SetCursorPosition(j, Slider.GetSliderListByID(oldActive).GetPosition());
                    Console.Write(" ");
                }
                DisplaySlider(active);
            }
            
            if (redraw == 0 || redraw == 2)
            {

                int maxl = ((Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) / 2) - 1;
                int maxh = Console.WindowHeight - 1;
                int x = maxh - ((maxh + map.GetLength(0)) / 2);
                int y = maxl - maxl / 2 - map.GetLength(1) / 2;
                if (test == 0)
                {
                    for (int i = 0; i < map.GetLength(0); i++)
                    {

                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            Console.SetCursorPosition(y + j * 2 + 1, x / 2 + i + 1);
                            switch (map[i,j].GetCellType())
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
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
                            Console.Write((int)(map[i, j].GetHeight() * 100) + "|");
                        }
                        Console.Write("\n");
                    }
                }
            }

        }
        /// <summary>
        /// Display of the sliders. 
        /// </summary>
        /// <param name="select">Slider in use</param>
        public static void DisplaySlider(int select)
        {
            Console.ResetColor();
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10, i);
                Console.Write("|");

            }
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < Slider.GetSliderList().Length; i++)
            {
                int position = Slider.GetSliderListByID(i).GetPosition();
                if (position >= 2 && position <= Console.WindowHeight - 2)
                {
                    string name = Slider.GetSliderListByID(i).GetName();
                    string[] value = Slider.GetSliderListByID(i).GetValue();
                    int lastSelect = Slider.GetSliderListByID(i).GetLastSelect();
                    if (Slider.GetSliderListByID(i).GetSliderType() == 2)
                    {
                        int nb = (Slider.GetSliderListByID(i).GetLastSelect() + 1) * Convert.ToInt32(Slider.GetSliderListByID(i).GetInterval()[1]) / Slider.GetSliderListByID(i).GetValue().Length;
                        if (nb >= 10)
                        {
                            name += " (" + nb + " %)";
                        }
                        else
                        {
                            name += " (0" + nb + " %)";
                        }
                        
                    }
                    if (i == 0)
                    {
                        Console.SetCursorPosition(new Slider().CenterPositionSlider(name) - 5, position);
                    }
                    else
                    {
                        Console.SetCursorPosition(new Slider().CenterPositionSlider(name) - 1, position);
                    }
                    if (select == i)
                    {
                        Console.Write("> ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write(name);
                    if(i == 0)
                    {
                        Console.Write(" ("+ (Slider.GetSliderListByID(i).GetLastSelect()+1) + "/" +Slider.GetSliderListByID(i).GetValue().Length + ")");
                    }
                    Console.ResetColor();
                    string stringValue = "";
                    switch (Slider.GetSliderListByID(i).GetSliderType())
                    {
                        case 1:
                            for (int j = 0; j < value.Length - 1; j++)
                            {
                                stringValue += value[j] + " | ";
                            }
                            stringValue += value[value.Length - 1];
                            Console.ResetColor();
                            Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                            for (int j = 0; j < value.Length - 1; j++)
                            {
                                if (lastSelect == j)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                Console.Write(value[j]);
                                Console.ResetColor();
                                Console.Write(" | ");
                            }
                            if (lastSelect == value.Length - 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            Console.Write(value[value.Length - 1]);
                            Console.ResetColor();
                            break;
                        case 2:
                            if (Slider.GetSliderListByID(i).GetInterval()[0] != null)
                            {
                                stringValue += Slider.GetSliderListByID(i).GetInterval()[0] + "  ";
                            }
                            for (int j = 0; j < value.Length - 1; j++)
                            {
                                stringValue += value[j];
                            }
                            stringValue += value[value.Length - 1];
                            if (Slider.GetSliderListByID(i).GetInterval()[1] != null)
                            {
                                stringValue += "  " + Slider.GetSliderListByID(i).GetInterval()[1];
                            }
                            Console.ResetColor();
                            Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                            if (select == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            Console.Write(Slider.GetSliderListByID(i).GetInterval()[0] + "  ");
                            Console.ResetColor();
                            for (int j = 0; j < value.Length - 1; j++)
                            {
                                if (lastSelect >= j)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                Console.Write(value[j]);
                                Console.ResetColor();
                            }
                            if (lastSelect == value.Length - 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            Console.Write(value[value.Length - 1]);
                            Console.ResetColor();
                            if (select == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            Console.Write("  " + Slider.GetSliderListByID(i).GetInterval()[1]);
                            Console.ResetColor();
                            break;
                        case 3:
                            //string[] Name = { "     Herbe      ", "     Arbre      ", "    Terrain     ", "    Feuille     ", "      Eau       ", "     Rocher     ", "    Cendres     ", "Cendres éteintes" };
                            string[] Name = { "Herbe", "Arbre", "Terrain", "Feuille", "Eau", "Rocher", "Cendres", "Cendres éteintes" };
                            stringValue += Name[Slider.GetSliderListByID(i).GetLastSelect()] + " : ";
                            Cell type = new Cell();
                            type.SetType(Slider.GetSliderListByID(i).GetLastSelect() + 1);
                            stringValue += "\"" + type.GetDisplaySymbol(Slider.GetSliderListByID(i).GetLastSelect()) + "\"";
                            Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(Name[Slider.GetSliderListByID(i).GetLastSelect()]);
                            Console.ResetColor();
                            Console.Write(" : \"");
                            switch (type.GetCellType())
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }
                            Console.Write(type.GetDisplaySymbol(Slider.GetSliderListByID(3).GetLastSelect()));
                            Console.ResetColor();
                            Console.Write("\"");
                            Console.ResetColor();
                            break;
                        case 4:
                            for (int j = 0; j < value.Length - 1; j++)
                            {
                                stringValue += value[j] + " | ";
                            }
                            stringValue += value[value.Length - 1];
                            Console.ResetColor();
                            Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                            for (int j = 0; j < value.Length - 1; j++)
                            {
                                Console.Write(value[j]);
                                Console.ResetColor();
                                Console.Write(" | ");
                            }
                            Console.Write(value[value.Length - 1]);
                            Console.ResetColor();
                            break;
                    }
                }

            }

        }
    }
}
