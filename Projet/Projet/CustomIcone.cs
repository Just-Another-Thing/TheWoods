using TheWoods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Menu = TheWoods.Menu;

namespace TheWoods
{
    public class CustomIcone
    {
        public struct Icone
        {
            private char icon;
            private int color;
            
            #region accessers & getters
            public Icone(char icon, int color)
            {
                this.icon = icon;
                this.color = color;
            }
            public char GetIconeIcon()
            {
                return this.icon;
            }
            public void SetIconeIcon(char icon) 
            { 
                this.icon = icon; 
            }
            public int GetIconeColor()
            {
                return this.color;
            }
            public void SetIconeColor(int color) 
            { 
                this.color = color;
            }
            #endregion
            
        }


        public static bool IconeCustom = false;
        public static Icone[] CustomIconeList = new Icone[]
        {
            new Icone('X',9),
            new Icone('*',7),
            new Icone(' ',14),
            new Icone('#',2),
            new Icone('~',10),
            new Icone('O',14),
            new Icone('\'',14),
            new Icone('.',14),
            new Icone('_', 4),
        };

        public static String[] ColorsList = { "Black","DarkBlue","DarkGreen","DarkRed","DarkMagenta","DarkYellow","Gray","DarkGray","Blue","Green","Cyan","Red","Magenta","Yellow","White" };
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
            
            int startheigt = CenterHeightIcone(CustomIconeList.Length * 2)+1;

            string sentence1 = "Appuyez sur une touche pour affecter un caractère au type.";
            string sentence2 = "Utilisez les flèches gauches et droites pour modifier la couleur de ce type.";
            Console.SetCursorPosition(Console.WindowWidth/2 - sentence1.Length/2, startheigt - 4);
            Console.Write(sentence1);
            Console.SetCursorPosition(Console.WindowWidth/2 - sentence2.Length/2, startheigt - 3);
            Console.Write(sentence2);
            
            int select = 0;
            int[] cursorPosition = {0, 0};
            string[] name = { "Herbe", "Arbre", "Terrain", "Feuille", "Eau", "Rocher", "Cendres", "Cendres éteintes", "Couleur du feu"};
            do
            {
                for (int i = 0; i < CustomIconeList.Length; i++)
                {
                    int taille = name[i].Length + 4;
                    Console.SetCursorPosition(CenterMiddleIcone(taille), startheigt + (i * 2));
                    if (select == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                       // Console.Write("> ");
                    }

                    if (i < CustomIconeList.Length-1)
                    {
                        Console.Write(name[i] + " : ");
                        GetColor(CustomIconeList[i], false);
                        Console.Write(CustomIconeList[i].GetIconeIcon());
                    }
                    else
                    {
                        int j = Program.GetRandom().Next(0, CustomIconeList.Length - 1);
                        char icone = CustomIconeList[j].GetIconeIcon();
                        if (icone is ' ')
                        {
                            char[] s = {'-', '/', '_', '#', '\\', '~', '/', ',', '@', '|'};
                            icone = s[Program.GetRandom().Next(0, s.Length-1)];
                            
                        }
                        Console.Write(name[i] + " : ");
                        CustomIconeList[i].SetIconeIcon(icone);
                        GetColor(CustomIconeList[i], false);
                        Console.Write(CustomIconeList[i].GetIconeIcon());
                    }
                    
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
                    case ConsoleKey.LeftArrow:
                        CustomIconeList[select].SetIconeColor(CustomIconeList[select].GetIconeColor()-1);
                        if (CustomIconeList[select].GetIconeColor() < 0)
                        {
                            CustomIconeList[select].SetIconeColor(21);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        CustomIconeList[select].SetIconeColor(CustomIconeList[select].GetIconeColor()+1);
                        if (CustomIconeList[select].GetIconeColor() > 21)
                        {
                            CustomIconeList[select].SetIconeColor(0);
                        }
                        break;
                    case ConsoleKey.Enter:
                        select = -1;
                        Console.SetCursorPosition(0,0);
                        break;
                    default:
                        CustomIconeList[select].SetIconeIcon(key.KeyChar);
                        break;
                }
            } while (select != -1);
            Console.CursorVisible = false;

        }

        public static void GetColor(Icone icon, bool InFire, int IconeType = 2)
        {
            if (InFire)
            {
                if (IconeType == 2)
                {
                    GetColor(CustomIconeList[CustomIconeList.Length - 1], false, 3);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }else
            {
                switch (icon.GetIconeColor())
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 10:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 11:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 12:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 13:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 14:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 15:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case 16:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 17:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 18:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 19:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 20:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 21:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                }
            }
        }


    }
}
