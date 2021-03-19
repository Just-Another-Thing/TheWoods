using Projet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet
{
    class Draws
    {
        static Thread mthread = new Thread(DrawMap);
        private struct Param
        {
            public Cell[,] map;
            public int IconeType;
            public int test;
            public int selectTab;
            public int onlyRedrawMap;
        }

        public static void Draw(Cell[,] map, int IconeType, int test, int activeSlider, int onlyRedrawMap)
        {
            Param p = new Param();
            p.map = map;
            p.IconeType = IconeType;
            p.test = test;
            p.selectTab = activeSlider;
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

        private static void DrawMap(object p)
        {
            Param param = (Param) p;
            Cell[,] map = param.map;
            int IconeType = param.IconeType;
            int test = param.test;
            int active = param.selectTab;
            int redraw = param.onlyRedrawMap;

            if (redraw == 2)
            {
                Config.ClearConsole(null);
            }
            
            if (redraw == 1 || redraw == 2)
            {
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
                            if (map[i, j].GetType() == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
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
                            Console.Write((int)(map[i, j].GetHeight() * 100) + "|");
                        }
                        Console.Write("\n");
                    }
                }
            }

        }

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

            for (int i = 0; i < Navigation.GetSliderList().Length; i++)
            {
                int position = Navigation.GetSliderListByID(i).GetPosition();
                if (position >= 2 && position <= Console.WindowHeight - 2)
                {
                    string name = Navigation.GetSliderListByID(i).GetName();
                    string[] value = Navigation.GetSliderListByID(i).GetValue();
                    int lastSelect = Navigation.GetSliderListByID(i).GetLastSelect();
                    if (Navigation.GetSliderListByID(i).GetSliderType() == 2)
                    {
                        int nb = (Navigation.GetSliderListByID(i).GetLastSelect() + 1) * Convert.ToInt32(Navigation.GetSliderListByID(i).GetInterval()[1]) / Navigation.GetSliderListByID(i).GetValue().Length;
                        name += " (" + nb + " %)";
                    }
                    Console.SetCursorPosition(new Slider().CenterPositionSlider(name) - 1, position);
                    if (select == i)
                    {
                        Console.SetCursorPosition(new Slider().CenterPositionSlider(name) - 1, position);
                        Console.Write("> ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write(name + "  ");
                    Console.ResetColor();
                    if (Navigation.GetSliderListByID(i).GetSliderType() == 1)
                    {
                        string stringValue = "";
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
                    }
                    else if (Navigation.GetSliderListByID(i).GetSliderType() == 2)
                    {

                        string stringValue = "";
                        if (Navigation.GetSliderListByID(i).GetInterval()[0] != null)
                        {
                            stringValue += Navigation.GetSliderListByID(i).GetInterval()[0] + "  ";
                        }
                        for (int j = 0; j < value.Length - 1; j++)
                        {
                            stringValue += value[j];
                        }
                        stringValue += value[value.Length - 1];
                        if (Navigation.GetSliderListByID(i).GetInterval()[1] != null)
                        {
                            stringValue += "  " + Navigation.GetSliderListByID(i).GetInterval()[1];
                        }
                        Console.ResetColor();
                        Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                        if (select == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(Navigation.GetSliderListByID(i).GetInterval()[0] + "  ");
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
                        Console.Write("  " + Navigation.GetSliderListByID(i).GetInterval()[1]);
                        Console.ResetColor();
                    }
                    else if (Navigation.GetSliderListByID(i).GetSliderType() == 3)
                    {
                        string stringValue = "";
                        string[] Name = { "Herbe", "Arbre", "Terrain", "Feuille", "Eau", "Rocher", "Cendres", "Cendres éteintes" };
                        stringValue += Name[Navigation.GetSliderListByID(i).GetLastSelect()] + " : ";
                        Cell type = new Cell();
                        type.SetType(Navigation.GetSliderListByID(i).GetLastSelect() + 1);
                        stringValue += "\"" + type.GetDisplaySymbol(Navigation.GetSliderListByID(i).GetLastSelect()) + "\"";
                        Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Name[Navigation.GetSliderListByID(i).GetLastSelect()]);
                        Console.ResetColor();
                        Console.Write(" : \"");
                        if (type.GetType() == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (type.GetType() == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        else if (type.GetType() == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else if (type.GetType() == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write(type.GetDisplaySymbol(Navigation.GetSliderListByID(3).GetLastSelect()));
                        Console.ResetColor();
                        Console.Write("\"");
                        Console.ResetColor();
                    }
                }

            }

        }
    }
}
