using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class StartMenu
    {
        #region ProgrammStart
        public static void ProgrammStart()
        {
            Config.SetTitle("Menu de démarage");
            Console.WriteLine("Bienvenue sur The Woods");
            Console.WriteLine("Un projet présenté par Alexandre Michaud et Romain Pathé");
        }
        #endregion
    }
}
