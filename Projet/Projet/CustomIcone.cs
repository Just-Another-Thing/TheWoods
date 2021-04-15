using Projet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Menu = Projet.Menu;

namespace TheWoods
{
    class CustomIcone
    {

        public struct IconeList
        {
            private char icon;
        }

        public static bool IconeCustom = false;
        public static char[] CustomIconeList = { 'x', '*', ' ', '#', '~', 'O', '\'', '.' };

        public static void CustomIconeMenu()
        {
            Config.ClearConsole("Customisation des icônes");
            DisplaySelect();
        }

        public static int CenterHeightIcone(int nb)
        {
            int result = (Console.WindowHeight/2)-(nb/2);
            return result;
        }
        public static int CenterMiddleIcone(int nb)
        {
            int max = Console.WindowWidth - 1;
            int result = (max / 2) - (nb / 2);
            return result;
        }
        public static void DisplaySelect()
        {
            Config.ClearConsole("Customisation des icônes");
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(Console.WindowWidth - 2, i);
                Console.Write("|");
            };
            Console.CursorVisible = true;
            int startheigt = CenterHeightIcone(CustomIconeList.Length * 2);
            int select = 0;
            int[] cursorPosition = {0, 0};
            string[] name = { "Herbe", "Arbre", "Terrain", "Feuille", "Eau", "Rocher", "Cendres", "Cendres éteintes" };
            do
            {
                for (int i = 0; i < CustomIconeList.Length; i++)
                {
                    int taille = name[i].Length + 4;
                    if (select == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.SetCursorPosition(CenterMiddleIcone(taille), startheigt + (i * 2));
                    Console.Write(name[i] + " : " + CustomIconeList[i]);
                    if (select == i)
                    {
                        cursorPosition[0] = Console.CursorLeft;
                        cursorPosition[1] = Console.CursorTop;
                    }
                    Console.ResetColor();
                }
                Console.SetCursorPosition(cursorPosition[0]-1,cursorPosition[1]);
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (select != 0)
                        {
                            select--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (select != CustomIconeList.Length-1)
                        {
                            select++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        select = -1;
                        Console.SetCursorPosition(0,0);
                        break;
                    default:
                        CustomIconeList[select] = key.KeyChar;
                        break;
                }
            } while (select != -1);
            

        }




    }
}
