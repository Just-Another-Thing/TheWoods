using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public struct Slider
    {
        private int Position;
        private int LastSelect;
        private string[] Interval;
        private String Name;
        private String[] Value;
        private int SliderType;

        #region Getters & Accessers
        public int GetPosition()
        {
            return this.Position;
        }
        public void SetPosition(int Position)
        {
            this.Position = Position;
        }

        public int GetLastSelect()
        {
            return this.LastSelect;
        }
        public void SetLastSelect(int LastSelect)
        {
            this.LastSelect = LastSelect;
        }

        public string[] GetInterval()
        {
            return this.Interval;
        }
        public void SetInterval(string[] Interval)
        {
            this.Interval = Interval;
        }

        public string GetName()
        {
            return this.Name;
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public string[] GetValue()
        {
            return this.Value;
        }
        public void SetValue(string[] Value)
        {
            this.Value = Value;
        }

        public int GetSliderType()
        {
            return this.SliderType;
        }
        public void SetSliderType(int SliderType)
        {
            this.SliderType = SliderType;
        }

        #endregion

        #region Function 
        public Slider (string name, string[] value, string[] interval, int position, int lastSelect, int sliderType)
        {
            Name = name;
            Value = value;
            Interval = interval;
            Position = position;
            LastSelect = lastSelect;
            SliderType = sliderType;

        }

        public int CenterPositionSlider(string element)
        {
            int CenterPosition = (Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) - ((Console.WindowWidth / 10 - Console.WindowWidth / 3) / 2) - element.Length / 2;
            return CenterPosition;
        }

        public static Slider[] GenerateSlider()
        {
            int NbSlider = 5;
            Slider[] SliderList = new Slider[NbSlider];

            string[] value00 = { "1", "2", "3", "4", "5", "6", "7", "8" };
            string[] interval00 = { null };
            SliderList[0] = new Slider("Légende", value00, interval00, 2, 0, 3);

            string[] value01 = { "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
            string[] interval01 = { "5", "100" };
            SliderList[1] = new Slider("Largeur", value01, interval01, 6, 9, 2);
            string[] value02 = { "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
            string[] interval02 = { "5", "100" };
            SliderList[2] = new Slider("Hauteur", value02, interval02, 10, 9, 2);
            string[] value03 = { "Réaliste", "Consigne" };
            string[] interval03 = { null };
            SliderList[3] = new Slider("Icone", value03, interval03, 14, 0, 1);
            string[] value04 = { "Activé", "Désactivé" };
            string[] interval04 = { null };
            SliderList[4] = new Slider("Propagation du feu", value04, interval04, 18, 0, 1);



            return SliderList;

        }

        #endregion
    }
}
