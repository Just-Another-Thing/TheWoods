using System;
using System.Diagnostics;
using System.Threading;
using TheWoods;

namespace TheWoods
{
    class Navigation
    {
        /// <summary>Allow to navigate throug the sliders</summary>
        /// <param name="ActivateSlider">Array with the slider used</param>
        /// <returns>Array with the new slider in use and the old one</returns>
        public static int[] NavigationManager(int[] ActivateSlider)
        {
            bool result = false;
            int reDraw = 1;
            Program.SetOnlyRedrawMap(2);
            do
            {
                Thread.Sleep(100);
                
                Console.SetCursorPosition(0, 0);
                ActivateSlider[1] = ActivateSlider[0];
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        for (int i = 0; i < Slider.GetSliderList().Length; i++)
                        {
                            if (i == ActivateSlider[0] && ActivateSlider[0] != 10)
                            {
                                if (Slider.GetSliderListById(i).GetLastSelect() > 0)
                                {
                                    Slider.GetSliderList()[i].SetLastSelect(Slider.GetSliderListById(i).GetLastSelect() - 1);
                                    if (ActivateSlider[0] == 3)
                                    {
                                        reDraw = 2;
                                    }
                                }
                            }else if(i == ActivateSlider[0] && ActivateSlider[0] == 10)
                            {
                                if (Program.GetTurn() > 0)
                                {                
                                    Program.DecrTurn();
                                    reDraw = 2;
                                }
                            }

                        }
                        result = true;
                        break;
                    case ConsoleKey.RightArrow:
                        for (int i = 0; i < Slider.GetSliderList().Length; i++)
                        {
                            if (i == ActivateSlider[0] && ActivateSlider[0] != 10)
                            {
                                if (Slider.GetSliderListById(i).GetLastSelect() < Slider.GetSliderListById(i).GetValue().Length - 1)
                                {
                                    Slider.GetSliderList()[i].SetLastSelect(Slider.GetSliderListById(i).GetLastSelect() + 1);
                                    if (ActivateSlider[0] == 3)
                                    {
                                        reDraw = 2;
                                    }
                                }
                            }
                            else if (i == ActivateSlider[0] && ActivateSlider[0] == 10)
                            {
                                if (Program.GetTurn() < Program.GetMaps().Count-1)
                                {
                                    Program.IncrTurn();
                                    reDraw = 2;
                                }
                            }
                        }
                        result = true;
                        break;
                    case ConsoleKey.UpArrow:
                        if (ActivateSlider[0] > 0)
                        {
                            ActivateSlider[1] = ActivateSlider[0];
                            ActivateSlider[0]--;
                            int activePosition = Slider.GetSliderListById(ActivateSlider[0]).GetPosition();
                            for (int i = 0; i < Slider.GetSliderList().Length; i++)
                            {
                                if (activePosition < 2)
                                {
                                    Slider.GetSliderList()[i].SetPosition(Slider.GetSliderListById(i).GetPosition() + 4);
                                }
                            }
                        }
                        result = true;
                        break;
                    case ConsoleKey.DownArrow:
                        if (ActivateSlider[0] < Slider.GetSliderList().Length - 1)
                        {
                            ActivateSlider[1] = ActivateSlider[0];
                            ActivateSlider[0]++;
                            int activePosition = Slider.GetSliderListById(ActivateSlider[0]).GetPosition();
                            for (int i = 0; i < Slider.GetSliderList().Length; i++)
                            {
                                if (activePosition > Console.WindowHeight - 2)
                                {
                                    Slider.GetSliderList()[i].SetPosition(Slider.GetSliderListById(i).GetPosition() - 4);
                                }
                            }
                        }
                        result = true;
                        break;
                    case ConsoleKey.Enter:
                        if(ActivateSlider[0] == 3)
                        {
                            CustomIcone.CustomIconeMenu();
                        }else
                        {
                            WoodGenerator.GenerateWoods();
                        }
                        reDraw = 3;
                        result = true;
                        break;
                    case ConsoleKey.Escape:
                        ActivateSlider[0] = -1;
                        result = true;
                        break;
                    case ConsoleKey.Spacebar:
                        Program.SetTurn(Program.GetMaps().Count - 1);
                        Program.SaveMaps(Program.GetMap(), false);
                        Program.PassTour(Program.GetMap());
                        reDraw = 2;
                        result = true;
                        break;
                    case ConsoleKey.F:
                        Program.SetTurn(Program.GetMaps().Count - 1);
                        Program.InitiateFire(Program.GetMap());
                        Program.SaveMaps(Program.GetMap(), false);
                        reDraw = 2;
                        result = true;
                        break;
                }
           
                
                Program.SetOnlyRedrawMap(reDraw);
                

            } while (!result);
            WoodGenerator.SetTreeProportion((Slider.GetSliderListById(5).GetLastSelect()+1)*10);
            WoodGenerator.SetWaterProportion((Slider.GetSliderListById(6).GetLastSelect()+1)*10);
            WoodGenerator.SetLeaveProportion((Slider.GetSliderListById(7).GetLastSelect() + 1) * 10);
            WoodGenerator.SetRockProportion((Slider.GetSliderListById(8).GetLastSelect() + 1) * 10);
            WoodGenerator.SetGrassProportion((Slider.GetSliderListById(9).GetLastSelect() + 1) * 10);
            return ActivateSlider;
        }

    }
}
