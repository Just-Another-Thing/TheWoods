using System;
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
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.LeftArrow)
                {
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

                }
                else if (key == ConsoleKey.DownArrow)
                {

                }
            } while (!result);

            return ActivateSlider;
        }

        public static void SetDesignNav()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10, i);
                Console.Write("|");
                Console.SetCursorPosition(0, 0);
            };
        }

    }
}
