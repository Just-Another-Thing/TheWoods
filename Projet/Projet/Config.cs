using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Projet
{
    class Config
    {
        public static void SetTitle(string title)
        {
            Console.Title = "> The Woods - " + title + " | Par Romain Pathé & Alexandre Michaud";
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public static void SetFullScreen()
        {
            int status = 3;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); 
            ShowWindow(ThisConsole, status);
        }


        /// <summary>
        /// Méthode permettant la remise a 0 de la console avec le design de base
        /// </summary>
        /// <param name=title>Titre a afficher dans la console</param>
        /// <returns>Aucun retour (Fonction d'affichage)</returns>
        public static void ClearConsole(string title)
        {
            SetFullScreen();
            //Console.Clear();
            if (title != null)
            {
                SetTitle(title);
            }
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("*");
                Console.SetCursorPosition(Console.WindowWidth - 2, i);
                Console.Write("*");
            };
        }







    }
}
