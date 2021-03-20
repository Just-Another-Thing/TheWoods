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



        public static int NavigationManager(int ActivateSlider)
        {
            bool result = false;
            Program.setOnlyRedrawMap(2);
            do
            {
                Console.SetCursorPosition(0, 0);
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.LeftArrow)
                {
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
                    if (ActivateSlider == 3)
                    {
                        Program.setOnlyRedrawMap(2);
                    }
                    else
                    {
                        Program.setOnlyRedrawMap(1);
                    }
                    result = true;
                }
                else if (key == ConsoleKey.RightArrow)
                {
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
                    if (ActivateSlider == 3)
                    {
                        Program.setOnlyRedrawMap(2);
                    }
                    else
                    {
                        Program.setOnlyRedrawMap(1);
                    }
                    result = true;
                }
                else if (key == ConsoleKey.UpArrow)
                {
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
                    Program.setOnlyRedrawMap(1);
                    result = true;
                }
                else if (key == ConsoleKey.DownArrow)
                {
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
                    Program.setOnlyRedrawMap(1);
                    result = true;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Program.map = WoodGenerator.GenerateWoods();
                    Program.setOnlyRedrawMap(2);
                    result = true;
                }else if (key == ConsoleKey.Escape)
                {
                    result = true;
                    ActivateSlider = -1;
                }else if (key == ConsoleKey.Spacebar)
                {
                    Program.PassTour(Program.map);
                    Program.setOnlyRedrawMap(0);
                    result = true;
                }else if (key == ConsoleKey.F)
                {
                    Program.InitiateFire(Program.map);
                    Program.setOnlyRedrawMap(0);
                    result = true;
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("*");
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
