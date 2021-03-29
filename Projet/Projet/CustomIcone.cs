using Projet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWoods
{
    class CustomIcone
    {

        struct IconeList
        {
            private int type;
            private char icon;
        }

        public static bool IconeCustom = false;

        public static void CustomIconeMenu()
        {
            /*
             * 
             * Si icone custom slider rouge alors icone nom créer
             * Si deja créer, touche pour les modifiers
             * 
             * Moitier d'ecran hauteur (Avec Texte)
             * Moitier d'ecran Largeur (Avec Texte)
             * Demandé saisir utilisateur pour quel affichage il veut (Enregistré pour la durée de l'éxecution)
             * ^ Modifiable a l'aide d'une touche specifique
             * Affichage de la liste selon utilisateur
             * Set position du curseur sous le texte
             * Gestion des couleurs
             * Gestion de la saisie utilisateur
             * Gestion de l'affichage de l'icone déjà remplis par l'utilisateur
             * Création du tableau d'icone
             */
            if(IconeCustom == false)
            {
                string[] option = { "Gauche", "Droite"};
                int select = 0;
                bool stop = false;
                do
                {
                    Config.ClearConsole("Customisation des icônes");
                    for (int i = 0; i < Console.WindowHeight; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10, i);
                        Console.Write('|');
                        Console.SetCursorPosition(Console.WindowWidth / 3 - Console.WindowWidth / 10, i);
                        Console.Write('|');
                    }
                    string exemple = "Nom de l'icone (#)";
                    Console.SetCursorPosition(CenterLeftIcone(exemple.Length), CenterHeightIcone(2));
                    Console.Write(exemple);
                    exemple = "Entrez votre icone :";
                    Console.SetCursorPosition(CenterLeftIcone(exemple.Length), CenterHeightIcone(2) + 1);
                    Console.Write(exemple);

                    exemple = "Nom de l'icone (#)";
                    Console.SetCursorPosition(CenterRightIcone(exemple.Length), CenterHeightIcone(8));
                    Console.Write(exemple);
                    exemple = "Entrez votre icone :";
                    Console.SetCursorPosition(CenterRightIcone(exemple.Length), CenterHeightIcone(8) + 1);
                    Console.Write(exemple);
                    exemple = "Nom de l'icone (#)";
                    Console.SetCursorPosition(CenterRightIcone(exemple.Length), CenterHeightIcone(8)+3);
                    Console.Write(exemple);
                    exemple = "Entrez votre icone :";
                    Console.SetCursorPosition(CenterRightIcone(exemple.Length), CenterHeightIcone(8) + 4);
                    Console.Write(exemple);
                    exemple = "Nom de l'icone (#)";
                    Console.SetCursorPosition(CenterRightIcone(exemple.Length), CenterHeightIcone(8)+6);
                    Console.Write(exemple);
                    exemple = "Entrez votre icone :";
                    Console.SetCursorPosition(CenterRightIcone(exemple.Length), CenterHeightIcone(8) + 7);
                    Console.Write(exemple);

                    exemple = "Quel type d'affichage voulez vous ?";
                    Console.SetCursorPosition(CenterMiddleIcone(exemple.Length), CenterHeightIcone(2));
                    Console.Write(exemple);
                    exemple = option[0] + " | " + option[1];
                    Console.SetCursorPosition(CenterMiddleIcone(exemple.Length), CenterHeightIcone(2) + 1);
                    Console.ResetColor();
                    if (select == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write(option[0]);
                    Console.ResetColor();
                    Console.Write(" | ");
                    if (select == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write(option[1]);
                    Console.SetCursorPosition(0, 0);
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.LeftArrow) {
                        select = 0;
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        select = 1;
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        stop = true;
                    }
                } while (stop != true);
            }
        }

        public static int CenterHeightIcone(int nb)
        {
            int result = (Console.WindowHeight/2)-(nb/2);
            return result;
        }
        public static int CenterLeftIcone(int nb)
        {
            int max = (Console.WindowWidth / 3 - Console.WindowWidth / 10)-1;
            int result = (max/2)-(nb/2);
            return result;
        }
        public static int CenterMiddleIcone(int nb)
        {
            int max = Console.WindowWidth - 1;
            int result = (max / 2) - (nb / 2);
            return result;
        }
        public static int CenterRightIcone(int nb)
        {
            int max = (Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) - ((Console.WindowWidth / 10 - Console.WindowWidth / 3) / 2);
            int result = max - (nb / 2);
            return result;
        }

    }
}
