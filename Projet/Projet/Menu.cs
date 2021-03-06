using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projet
{
    class Menu
    {
        #region ProgrammStart
        public static void ProgrammStart()
        {
            Config.SetFullScreen();
            Config.SetTitle("Menu de démarage");
            Console.WriteLine("Bienvenue sur The Woods");
        }



        #endregion
    }
}
