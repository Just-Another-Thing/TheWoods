using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projet
{
    class Menu
    {
        #region ProgrammStart
        public static void ProgrammStart()
        {
            Console.WriteLine(System.Windows.Input);
            Console.CursorVisible = false;
            Config.SetTitle("Menu de démarage");
            Console.WriteLine("Bienvenue sur The Woods");
        }



        #endregion
    }
}
