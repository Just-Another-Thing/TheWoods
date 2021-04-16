using System;
using System.IO;
using System.Text;
using System.Threading;

namespace TheWoods
{
    class Draws
    {
        /// <summary>
        /// Map display, with thread management. 
        /// </summary>
        /// <param name="map">The 'map' array, where the game is stored</param>
        /// <param name="IconeType">Icone type</param>
        /// <param name="test">Jsut for test purpose, only there because it could be useful in specifics cases</param>
        /// <param name="activeSlider">The slider in use</param>
        /// <param name="onlyRedrawMap"> Allow to choose what to redraw : the map, the sliders or both (0,1,2)</param>
        /// <param name="oldSelectSlider">The old selected slider</param>
        public static void Draw(Cell[,] map, int IconeType, int test, int activeSlider, int redraw, int oldActive, int turn, int turnCount)
        {

            if (redraw == 3)
            {
                Config.ClearConsole("Jeu en cours");
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("|");

            if (redraw == 1 || redraw == 2 || redraw == 3)
            {
                for (int j = (Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) + 1; j < Console.WindowWidth - 2; j++)
                {
                    Console.SetCursorPosition(j, Slider.GetSliderListById(oldActive).GetPosition()+1);
                    Console.Write(" "); 
                    Console.SetCursorPosition(j, Slider.GetSliderListById(oldActive).GetPosition());
                    Console.Write(" ");
                }
                DisplaySlider(activeSlider, turn, turnCount);
            }
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(Console.WindowWidth - 2, i);
                Console.Write("|");
            };
            Console.SetCursorPosition(0, 0);
            if (redraw == 0 || redraw == 2 || redraw == 3)
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
                            if (Program.GetMaps().Count > 1)
                            {
                                if (map[i,j].GetCellType() != 3 && map[i, j].GetCellType() != 5 && map[i, j].GetCellType() != 6)
                                {
                                    Console.Write(map[i, j].GetDisplaySymbol(IconeType) + " ");
                                }
                            }
                            else
                            {
                                Console.Write(map[i, j].GetDisplaySymbol(IconeType) + " ");
                            }
                            
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
        public static void DisplaySlider(int select, int turn, int turnCount)
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
                int position = Slider.GetSliderListById(i).GetPosition();
                if (position >= 2 && position <= Console.WindowHeight - 2)
                {
                    string name = Slider.GetSliderListById(i).GetName();
                    string[] value = Slider.GetSliderListById(i).GetValue();
                    int lastSelect = Slider.GetSliderListById(i).GetLastSelect();
                    if (Slider.GetSliderListById(i).GetSliderType() == 2)
                    {
                        int nb = (Slider.GetSliderListById(i).GetLastSelect() + 1) * Convert.ToInt32(Slider.GetSliderListById(i).GetInterval()[1]) / Slider.GetSliderListById(i).GetValue().Length;
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
                        Console.Write(" ("+ (Slider.GetSliderListById(i).GetLastSelect()+1) + "/" +Slider.GetSliderListById(i).GetValue().Length + ")");
                    }else if (i == 10)
                    {
                        Console.Write(" (" + turn + "/" + turnCount + ")");
                    }
                    Console.ResetColor();
                    string stringValue = "";
                    switch (Slider.GetSliderListById(i).GetSliderType())
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
                            if (Slider.GetSliderListById(i).GetInterval()[0] != null)
                            {
                                stringValue += Slider.GetSliderListById(i).GetInterval()[0] + "  ";
                            }
                            for (int j = 0; j < value.Length - 1; j++)
                            {
                                stringValue += value[j];
                            }
                            stringValue += value[value.Length - 1];
                            if (Slider.GetSliderListById(i).GetInterval()[1] != null)
                            {
                                stringValue += "  " + Slider.GetSliderListById(i).GetInterval()[1];
                            }
                            Console.ResetColor();
                            Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                            if (select == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            Console.Write(Slider.GetSliderListById(i).GetInterval()[0] + "  ");
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
                            Console.Write("  " + Slider.GetSliderListById(i).GetInterval()[1]);
                            Console.ResetColor();
                            break;
                        case 3:
                            //string[] Name = { "     Herbe      ", "     Arbre      ", "    Terrain     ", "    Feuille     ", "      Eau       ", "     Rocher     ", "    Cendres     ", "Cendres éteintes" };
                            string[] Name = { "Herbe", "Arbre", "Terrain", "Feuille", "Eau", "Rocher", "Cendres", "Cendres éteintes" };
                            stringValue += Name[Slider.GetSliderListById(i).GetLastSelect()] + " : ";
                            Cell type = new Cell();
                            type.SetType(Slider.GetSliderListById(i).GetLastSelect() + 1);
                            stringValue += "\"" + type.GetDisplaySymbol(Slider.GetSliderListById(i).GetLastSelect()) + "\"";
                            Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(Name[Slider.GetSliderListById(i).GetLastSelect()]);
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
                            Console.Write(type.GetDisplaySymbol(Slider.GetSliderListById(3).GetLastSelect()));
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
