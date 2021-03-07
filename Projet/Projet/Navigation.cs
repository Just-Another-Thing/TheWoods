using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Navigation
    {

        public static void NavigationManager()
        {
            bool result = false;
            do
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.LeftArrow)
                {
                }
                else if (key == ConsoleKey.RightArrow)
                {
                }
                else if (key == ConsoleKey.UpArrow)
                {
                }
                else if (key == ConsoleKey.DownArrow)
                {
                }
            } while (!result);
        }

        public static void SetDesignNav()
        {
            for (int i = 1; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10, i);
                Console.Write("|");
                Console.SetCursorPosition(0, 0);
            };
        }

    }
}
