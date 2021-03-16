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
        private static Slider[] SliderList = new Slider[10];


        #region Getters & Accessers

        public static Slider[] GetSliderList()
        {
            return SliderList;
        }
        public static Slider GetSliderListByID(int id)
        {
            return SliderList[id];
        }
        public static void AddSlider(int position, Slider NewSlider)
        {
            SliderList[position] = NewSlider;
        }
        #endregion



        public static int NavigationManager(int ActivateSlider, Cell[,] map)
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
                    for (int i = 0; i<GetSliderList().Length;i++)
                    {
                        if (i == ActivateSlider)
                        {
                            if (GetSliderListByID(i).GetLastSelect() > 0)
                            {
                                GetSliderList()[i].SetLastSelect(GetSliderListByID(i).GetLastSelect() - 1);
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
                            if (GetSliderListByID(i).GetLastSelect() < GetSliderListByID(i).GetValue().Length-1)
                            {
                                GetSliderList()[i].SetLastSelect(GetSliderListByID(i).GetLastSelect() + 1);
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
                        int activePosition = GetSliderListByID(ActivateSlider).GetPosition();
                        for (int i = 1; i < GetSliderList().Length; i++)
                        {
                            if(activePosition < 2)
                            {
                                GetSliderListByID(i).SetPosition(GetSliderListByID(i).GetPosition() + 4);
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
                        int activePosition = GetSliderListByID(ActivateSlider).GetPosition();
                        for (int i = 1; i < GetSliderList().Length; i++)
                        {
                            if (activePosition > Console.WindowHeight - 2)
                            {
                                GetSliderListByID(i).SetPosition(GetSliderListByID(i).GetPosition() - 4);
                            }
                        }
                    }
                    result = true;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("*");
                    Program.map = WoodGenerator.GenerateWoods();
                    
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
            //here
            WoodGenerator.SetTreeProportion((GetSliderListByID(5).GetLastSelect()+1)*10);
            WoodGenerator.SetWaterProportion((GetSliderListByID(6).GetLastSelect()+1)*10);
            WoodGenerator.SetLeaveProportion((GetSliderListByID(7).GetLastSelect() + 1) * 10);
            WoodGenerator.SetRockProportion((GetSliderListByID(8).GetLastSelect() + 1) * 10);
            WoodGenerator.SetGrassProportion((GetSliderListByID(9).GetLastSelect() + 1) * 10);

            return ActivateSlider;
        }

    }
}
