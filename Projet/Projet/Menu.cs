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
            int NbSlider = 2;
            Slider[] SliderList = new Slider[NbSlider] ;
            string[] value0 = { "Automatique", "Manuel" };
            string[] interval0 = { null };
            SliderList[0] = new Slider().SetSlider("Mode de jeu", "Séléctionnez automatique ou manuel", value0, interval0, 10, 0, 1);
            string[] value1 = { "OUI", " NON" };
            string[] interval1 = { null };
            SliderList[1] = new Slider().SetSlider("Propagation du feu", "xxxxxxx", value1, interval1, 20, 0, 1);

            return SliderList;

        }




    }
}
