using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Config
    {
        public static void SetTitle(string title)
        {
            Console.Title = "The Woods - " + title + " | Par Romain Pathé & Alexandre Michaud";
        }
    }
}
