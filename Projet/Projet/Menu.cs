using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Projet
{
    class Menu
    {
        #region ProgrammStart



        public static void ProgrammStart()
        {
            // Delete ScrollBar 
            int origWidth = Console.WindowWidth;
            int origHeight = Console.WindowHeight;
            int width = origWidth / 2;
            int height = origHeight / 4;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            // Menu de start
            string texte;
            Config.ClearConsole("Menu de démarage");
            Console.ForegroundColor = ConsoleColor.Red;
            texte = "Avertissement : Enlever le mode pleine écran déformera l'enssemble du design !";
            Console.SetCursorPosition(Console.WindowWidth / 2 - (texte.Length / 2), 1);
            Console.WriteLine(texte);
            Console.ResetColor();
            texte = "Bienvenue sur";
            Console.SetCursorPosition(Console.WindowWidth/2-(texte.Length/2), Console.WindowHeight/2-5);
            Console.WriteLine(texte);
            texte = "THE WOODS";
            Console.SetCursorPosition(Console.WindowWidth / 2 - (texte.Length / 2), Console.WindowHeight / 2 - 4);
            Console.WriteLine(texte);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            texte = "Objectif du projet: Réaliser une map généré aléatoirement et simuler un feu afin de voir son évolution au sein de cette map ";
            Console.SetCursorPosition(Console.WindowWidth / 2 - (texte.Length / 2), Console.WindowHeight / 2 - 3);
            Console.Write(texte);
            Console.ForegroundColor = ConsoleColor.Gray;
            texte = "Créé et présenté par Romain Pathé et Alexandre Michaud";
            Console.SetCursorPosition(Console.WindowWidth / 2 - (texte.Length / 2), Console.WindowHeight-2);
            Console.WriteLine(texte);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            texte = "Continuer: Espace";
            Console.SetCursorPosition(Console.WindowWidth - texte.Length - 3, Console.WindowHeight - 2);
            Console.WriteLine(texte);
            Console.ResetColor();
            Console.CursorVisible = false;
            Slider[] SliderList = GenerateSlider();


            bool result = false;
            do
            {
                Console.SetCursorPosition(0, 0);
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    result = true;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write("*");
            } while(!result);

            //Config.NavigationManager();

            if (result) return;


            //Console.WriteLine("╭━━━━╮╭╮╱╭╮╭━━━╮ ╭╮╭╮╭╮╭━━━╮╭━━━╮╭━━━╮╭━━━╮");
            //Console.WriteLine("┃╭╮╭╮┃┃┃╱┃┃┃╭━━╯ ┃┃┃┃┃┃┃╭━╮┃┃╭━╮┃╰╮╭╮┃┃╭━╮┃");
            //Console.WriteLine("╰╯┃┃╰╯┃╰━╯┃┃╰━━╮ ┃┃┃┃┃┃┃┃╱┃┃┃┃╱┃┃╱┃┃┃┃┃╰━━╮");
            //Console.WriteLine("╱╱┃┃╱╱┃╭━╮┃┃╭━━╯ ┃╰╯╰╯┃┃┃╱┃┃┃┃╱┃┃╱┃┃┃┃╰━━╮┃");
            //Console.WriteLine("╱╱┃┃╱╱┃┃╱┃┃┃╰━━╮ ╰╮╭╮╭╯┃╰━╯┃┃╰━╯┃╭╯╰╯┃┃╰━╯┃");
            //Console.WriteLine("╱╱╰╯╱╱╰╯╱╰╯╰━━━╯ ╱╰╯╰╯╱╰━━━╯╰━━━╯╰━━━╯╰━━━╯");


        }
        #endregion





        public static Slider[] GenerateSlider()
        {
            int NbSlider = 19;
            Slider[] SliderList = new Slider[NbSlider];
            string[] value01 = { "10","15","20","25","30","35" };
            string[] interval01 = { null };
            SliderList[0] = new Slider("Largeur (En case)", value01, interval01, 2, 0, 1);
            string[] value02 = { "10", "15", "20", "25", "30", "35" };
            string[] interval02 = { null };
            SliderList[1] = new Slider("Hauteur (En case)", value02, interval02, 6, 0, 1);
            string[] value0 = { "Automatique", "Manuel" };
            string[] interval0 = { null };
            //SliderList[0] = new Slider("Mode de jeu", value0, interval0, 2, 0, 1);
            string[] value1 = { "OUI", "NON" };
            string[] interval1 = { null };
            //SliderList[1] = new Slider("Propagation du feu", value1, interval1, 6, 0, 1);
            SliderList[2] = new Slider("Propagation du feu", value1, interval1, 10, 0, 1);
            //string[] value2 = { "*","*","*","*","*","*","*","*","*","*","*" };
            string[] value2 = { "*","*","*","*","*","*","*","*","*","*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
            string[] interval2 = { "0","100" };
            SliderList[3] = new Slider("TEST", value2, interval2, 14, 0, 2);
            SliderList[4] = new Slider("Propagation du feu", value1, interval1, 18, 0, 1);
            SliderList[5] = new Slider("Propagation du feu", value1, interval1, 22, 0, 1);
            SliderList[6] = new Slider("Propagation du feu", value1, interval1, 26, 0, 1);
            SliderList[7] = new Slider("Propagation du feu", value1, interval1, 30, 0, 1);
            SliderList[8] = new Slider("Propagation du feu", value1, interval1, 34, 0, 1);
            SliderList[9] = new Slider("Propagation du feu", value1, interval1, 38, 0, 1);
            SliderList[10] = new Slider("Propagation du feu", value1, interval1, 42, 0, 1);
            SliderList[11] = new Slider("Propagation du feu", value1, interval1, 46, 0, 1);
            SliderList[12] = new Slider("Propagation du feu", value1, interval1, 50, 0, 1);
            SliderList[13] = new Slider("Propagation du feu", value1, interval1, 54, 0, 1);
            SliderList[14] = new Slider("Propagation du feu", value1, interval1, 58, 0, 1);
            SliderList[15] = new Slider("Propagation du feu", value1, interval1, 62, 0, 1);
            SliderList[16] = new Slider("Propagation du feu", value1, interval1, 66, 0, 1);
            SliderList[17] = new Slider("Propagation du feu", value1, interval1, 70, 0, 1);
            SliderList[18] = new Slider("Propagation du feu", value1, interval1, 74, 0, 1);

            return SliderList;

        }

        public static void DisplaySlider(Slider[] SliderTab, int select)
        {
            for (int i = 0; i< SliderTab.Length; i++) 
            {
                int position = SliderTab[i].GetPosition();
                if (position >= 2 && position <= Console.WindowHeight-2)
                {
                    string name = SliderTab[i].GetName();
                    string[] value = SliderTab[i].GetValue();
                    int lastSelect = SliderTab[i].GetLastSelect();
                    if (SliderTab[i].GetSliderType() == 2)
                    {
                        int nb = (SliderTab[i].GetLastSelect() + 1) * Convert.ToInt32(SliderTab[i].GetInterval()[1]) / SliderTab[i].GetValue().Length;
                        name += " (" + nb + " %)";
                    }
                    Console.SetCursorPosition(new Slider().CenterPositionSlider(name), position);
                    if (select == i)
                    {
                        Console.SetCursorPosition(new Slider().CenterPositionSlider(name)-1, position);
                        Console.Write("> ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write(name);
                    Console.ResetColor();
                    if (SliderTab[i].GetSliderType() == 1)
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
                        if (lastSelect == value.Length-1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write(value[value.Length - 1]);
                        Console.ResetColor();
                    }
                    else if(SliderTab[i].GetSliderType() == 2)
                    {

                        string stringValue = "";
                        Debug.WriteLine(SliderTab[i].GetInterval()[0]);
                        Debug.WriteLine(SliderTab[i].GetInterval()[1]);
                        if (SliderTab[i].GetInterval()[0] != null)
                        {
                            stringValue += SliderTab[i].GetInterval()[0] + "  ";
                        }
                        for (int j = 0; j < value.Length - 1; j++)
                        {
                            stringValue += value[j];
                        }
                        stringValue += value[value.Length - 1];
                        if (SliderTab[i].GetInterval()[1] != null)
                        {
                            stringValue += "  "+SliderTab[i].GetInterval()[1];
                        }
                        Debug.WriteLine(stringValue);
                        Console.ResetColor();
                        Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                        if(select == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(SliderTab[i].GetInterval()[0]+ "  ");
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
                        if (select == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write("  "+SliderTab[i].GetInterval()[1]);
                        Console.ResetColor();



                    }
                }
                
            }
        }


    }
}
