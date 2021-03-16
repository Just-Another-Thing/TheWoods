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





        
        public static void DisplaySlider(int select)
        {

            Config.ClearConsole(null);
            Console.ResetColor();
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10, i);
                Console.Write("|");

            }
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i< Navigation.GetSliderList().Length; i++) 
            {
                int position = Navigation.GetSliderListByID(i).GetPosition();
                if (position >= 2 && position <= Console.WindowHeight-2)
                {
                    string name = Navigation.GetSliderListByID(i).GetName();
                    string[] value = Navigation.GetSliderListByID(i).GetValue();
                    int lastSelect = Navigation.GetSliderListByID(i).GetLastSelect();
                    if (Navigation.GetSliderListByID(i).GetSliderType() == 2)
                    {
                        int nb = (Navigation.GetSliderListByID(i).GetLastSelect() + 1) * Convert.ToInt32(Navigation.GetSliderListByID(i).GetInterval()[1]) / Navigation.GetSliderListByID(i).GetValue().Length;
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
                        if (lastSelect == value.Length-1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write(value[value.Length - 1]);
                        Console.ResetColor();
                    }else if(Navigation.GetSliderListByID(i).GetSliderType() == 2)
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
                            stringValue += "  "+ Navigation.GetSliderListByID(i).GetInterval()[1];
                        }
                        Console.ResetColor();
                        Console.SetCursorPosition(new Slider().CenterPositionSlider(stringValue), position + 1);
                        if(select == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(Navigation.GetSliderListByID(i).GetInterval()[0]+ "  ");
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
                        Console.Write("  "+ Navigation.GetSliderListByID(i).GetInterval()[1]);
                        Console.ResetColor();
                    }else if (Navigation.GetSliderListByID(i).GetSliderType() == 3)
                    {
                        string stringValue = "";
                        string[] Name = { "Herbe", "Arbre", "Terrain", "Feuille", "Eau", "Rocher", "Cendres", "Cendres éteintes" };
                        stringValue += Name[Navigation.GetSliderListByID(i).GetLastSelect()] + " : ";
                        Cell type = new Cell();
                        type.SetType(Navigation.GetSliderListByID(i).GetLastSelect()+1);
                        stringValue += "\""+type.GetDisplaySymbol(Navigation.GetSliderListByID(i).GetLastSelect()) + "\"";
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
