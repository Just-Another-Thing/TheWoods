﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Navigation
    {

        public static int NavigationManager(Slider[] SliderList, int ActivateSlider)
        {
            bool result = false;
            do
            {
                Console.SetCursorPosition(0, 0);
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");
                    for (int i = 0; i<SliderList.Length;i++)
                    {
                        if (i == ActivateSlider)
                        {
                            if (SliderList[i].GetLastSelect() > 0)
                            {
                                SliderList[i].SetLastSelect(SliderList[i].GetLastSelect() - 1);
                            }
                        }
                    }
                    result = true;
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");
                    for (int i = 0; i < SliderList.Length; i++)
                    {
                        if (i == ActivateSlider)
                        {
                            if (SliderList[i].GetLastSelect() < SliderList[i].GetValue().Length)
                            {
                                SliderList[i].SetLastSelect(SliderList[i].GetLastSelect() + 1);
                            }
                        }
                    }
                    result = true;
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");
                    if(ActivateSlider > 0)
                    {
                        ActivateSlider--;
                        for (int i = 0; i < SliderList.Length; i++)
                        {
                            if(SliderList[ActivateSlider].GetPosition() < 2)
                            {
                                SliderList[i].SetPosition(SliderList[i].GetPosition() - 4);
                            }
                        }
                    }
                    result = true;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");
                    if (ActivateSlider < SliderList.Length-1)
                    {
                        ActivateSlider++;
                        for (int i = 0; i < SliderList.Length; i++)
                        {
                            if (SliderList[ActivateSlider].GetPosition() > Console.WindowHeight - 2)
                            {
                                SliderList[i].SetPosition(SliderList[i].GetPosition() + 4);
                            }
                        }
                    }
                    result = true;
                }
                else if (key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");
                    result = true;
                    ActivateSlider = -1;
                }
            } while (!result);

            return ActivateSlider;
        }

        public static void SetDesignNav()
        {
            Config.ClearConsole(null);
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10, i);
                Console.Write("|");
                Console.SetCursorPosition(0, 0);
            };
        }

    }
}
