using System;
using System.Runtime.InteropServices;

namespace Projet
{
    class Config
    {
        /// <summary>
        /// Initiate title of the console. 
        /// </summary>
        /// <param name="title">Name of the window</param>
        public static void SetTitle(string title)
        {
            Console.Title = "> The Woods - " + title + " | Par Romain Pathé & Alexandre Michaud";
        }
        /// <summary>
        /// Library allowing to get user information, as Length/height of the screen.
        /// </summary>
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// Full screen function
        /// </summary>
        public static void SetFullScreen()
        {
            int status = 3;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); 
            ShowWindow(ThisConsole, status);
        }

        /// <summary>
        /// More advanced clear. 
        /// </summary>
        /// <param name=title>Title to show on the console</param>
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
        }
    }
}
