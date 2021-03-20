using System;
using System.Runtime.InteropServices;

namespace Projet
{
    class Config
    {
        /// <summary>
        /// Initialiser le titre de la console
        /// </summary>
        /// <param name="title">Nom de l'onglet</param>
        public static void SetTitle(string title)
        {
            Console.Title = "> The Woods - " + title + " | Par Romain Pathé & Alexandre Michaud";
        }
        /// <summary>
        /// Librairie externe permettant de récupérer les informations du systéme de l'utilisateur afin de set en pleine ecran la console
        /// </summary>
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// Fonction pour set le full screen de l'utilisateur
        /// </summary>
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
