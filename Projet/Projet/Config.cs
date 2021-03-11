using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
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


        public static void ClearConsole(string title, int zone)
        {
            SetFullScreen();
            //Console.Clear();
            if (title != null)
            {
                SetTitle(title);
            }
            Console.ResetColor();
            //for (int i = 0; i < Console.WindowHeight; i++)
            //{
            //   Console.SetCursorPosition(0, i);
            //    Console.Write("*");
            //    Console.SetCursorPosition(Console.WindowWidth - 2, i);
            //    Console.Write("*");
            //};
            Console.SetCursorPosition(0, 0);
            if(zone == 1)
            {
                int max = Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10;
                for (int i = 0; i< Console.WindowHeight; i++)
                {
                    
                    for (int j = max; j<Console.WindowWidth;j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("");
                    }
                }
            }
        }







    }
}
