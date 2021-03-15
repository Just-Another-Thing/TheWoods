using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Projet
{
    class Navigation
    {

        public static int NavigationManager(Slider[] SliderList, int ActivateSlider, Cell[,] map)
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
                            if (SliderList[i].GetLastSelect() < SliderList[i].GetValue().Length-1)
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
                    if (ActivateSlider > 0)
                    {
                        ActivateSlider--;
                        int activePosition = SliderList[ActivateSlider].GetPosition();
                        for (int i = 1; i < SliderList.Length; i++)
                        {
                            if(activePosition < 2)
                            {
                                SliderList[i].SetPosition(SliderList[i].GetPosition() + 4);
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
                        Debug.WriteLine(SliderList[ActivateSlider].GetPosition());
                        int activePosition = SliderList[ActivateSlider].GetPosition();
                        for (int i = 1; i < SliderList.Length; i++)
                        {
                            if (activePosition > Console.WindowHeight - 2)
                            {
                                SliderList[i].SetPosition(SliderList[i].GetPosition() - 4);
                            }
                        }
                    }
                    result = true;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");

                    int maxl = ((Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) / 2) - 1;
                    int maxm = Console.WindowHeight-1;
                    int result1 = (SliderList[1].GetLastSelect() + 1) * maxl / SliderList[1].GetValue().Length;
                    int result2 = (SliderList[2].GetLastSelect() + 1) * maxm / SliderList[2].GetValue().Length;
                    Program.map = WoodGenerator.GenerateWoods(result1, result2);
                    
                    result = true;
                }else if (key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");
                    result = true;
                    ActivateSlider = -1;
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");
                }
            } while (!result);
            return ActivateSlider;
        }

        public static void SetDesignNav()
        {
            Config.ClearConsole(null,1);
            Console.ResetColor();
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10, i);
                Console.Write("|");
                Console.SetCursorPosition(0, 0);
            };
        }

    }
}
