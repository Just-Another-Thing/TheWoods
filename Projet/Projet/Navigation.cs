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

         /// <summary>Permet de gérer la navigation dans le menu de droite</summary>
         /// <param name="ActivateSlider">ID du slider activé</param>
         /// <returns>L'ID du nouveau slider activé</returns>
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
                    for (int i = 0; i<Slider.GetSliderList().Length;i++)
                    {
                        if (i == ActivateSlider)
                        {
                            if (Slider.GetSliderListByID(i).GetLastSelect() > 0)
                            {
                                Slider.GetSliderList()[i].SetLastSelect(Slider.GetSliderListByID(i).GetLastSelect() - 1);
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
                    for (int i = 0; i < Slider.GetSliderList().Length; i++)
                    {
                        if (i == ActivateSlider)
                        {
                            if (Slider.GetSliderListByID(i).GetLastSelect() < Slider.GetSliderListByID(i).GetValue().Length-1)
                            {
                                Slider.GetSliderList()[i].SetLastSelect(Slider.GetSliderListByID(i).GetLastSelect() + 1);
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
                        int activePosition = Slider.GetSliderListByID(ActivateSlider).GetPosition();
                        for (int i = 1; i < Slider.GetSliderList().Length; i++)
                        {
                            if(activePosition < 2)
                            {
                                Slider.GetSliderListByID(i).SetPosition(Slider.GetSliderListByID(i).GetPosition() + 4);
                            }
                        }
                    }
                    Program.setOnlyRedrawMap(1);
                    result = true;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (ActivateSlider < Slider.GetSliderList().Length-1)
                    {
                        ActivateSlider++;
                        int activePosition = Slider.GetSliderListByID(ActivateSlider).GetPosition();
                        for (int i = 1; i < Slider.GetSliderList().Length; i++)
                        {
                            if (activePosition > Console.WindowHeight - 2)
                            {
                                Slider.GetSliderListByID(i).SetPosition(Slider.GetSliderListByID(i).GetPosition() - 4);
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
            WoodGenerator.SetTreeProportion((Slider.GetSliderListByID(5).GetLastSelect()+1)*10);
            WoodGenerator.SetWaterProportion((Slider.GetSliderListByID(6).GetLastSelect()+1)*10);
            WoodGenerator.SetLeaveProportion((Slider.GetSliderListByID(7).GetLastSelect() + 1) * 10);
            WoodGenerator.SetRockProportion((Slider.GetSliderListByID(8).GetLastSelect() + 1) * 10);
            WoodGenerator.SetGrassProportion((Slider.GetSliderListByID(9).GetLastSelect() + 1) * 10);

            return ActivateSlider;
        }

    }
}
