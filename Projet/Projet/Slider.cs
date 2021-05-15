using System;

namespace TheWoods
{
    public struct Slider
    {
        private int _position;
        private int _lastSelect;
        private string[] _interval;
        private String _name;
        private String[] _value;
        private int _sliderType;
        private static readonly Slider[] SliderList = new Slider[15];

        /// <summary>
        /// Region with all accessers/getters necessary for the project. 
        /// </summary>
        #region Getters & Accessers
        public int GetPosition()
        {
            return this._position;
        }
        public void SetPosition(int position)
        {
            this._position = position;
        }

        public int GetLastSelect()
        {
            return this._lastSelect;
        }
        public void SetLastSelect(int lastSelect)
        {
            this._lastSelect = lastSelect;
        }

        public string[] GetInterval()
        {
            return this._interval;
        }
        public void SetInterval(string[] interval)
        {
            this._interval = interval;
        }

        public string GetName()
        {
            return this._name;
        }
        public void SetName(string name)
        {
            this._name = name;
        }

        public string[] GetValue()
        {
            return this._value;
        }
        public void SetValue(string[] value)
        {
            this._value = value;
        }

        public int GetSliderType()
        {
            return this._sliderType;
        }
        public void SetSliderType(int sliderType)
        {
            this._sliderType = sliderType;
        }

        #endregion

        #region Accés au slider
        /// <summary>
        /// Return all sliders
        /// </summary>
        /// <returns>Array of slider</returns>
        public static Slider[] GetSliderList()
        {
            return SliderList;
        }
        /// <summary>
        /// Get slider from the id (position). 
        /// </summary>
        /// <param name="id">Id of the wanted slider</param>
        /// <returns>The slider</returns>
        public static Slider GetSliderListById(int id)
        {
            return SliderList[id];
        }
        /// <summary>
        /// Add one new slider to the list
        /// </summary>
        /// <param name="id">Id of the new slider</param>
        /// <param name="newSlider">The slider to add</param>
        private static void AddSlider(int id, Slider newSlider)
        {
            SliderList[id] = newSlider;
        }
        #endregion

        #region Fonction 

        #region Constructeur
        /// <summary>
        /// Constructeur permetant de générer un slider
        /// </summary>
        /// <param name="name">Nom du slider</param>
        /// <param name="value">Tableau des valeur du slider</param>
        /// <param name="interval">Interval des valeurs du slider</param>
        /// <param name="position">Position du Slider</param>
        /// <param name="lastSelect">Derniére valeur séléctionné dans le slider</param>
        /// <param name="sliderType">Type du slider</param>
        public Slider(string name, string[] value, string[] interval, int position, int lastSelect, int sliderType)
        {
            _name = name;
            _value = value;
            _interval = interval;
            _position = position;
            _lastSelect = lastSelect;
            _sliderType = sliderType;
        }
        #endregion

        /// <summary>
        /// Center one element inside a slider.
        /// </summary>
        /// <param name="element">text to center</param>
        /// <returns>Amount of "spaces" needed to center</returns>
        public int CenterPositionSlider(string element)
        {
            int centerPosition = (Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) - ((Console.WindowWidth / 10 - Console.WindowWidth / 3) / 2) - element.Length / 2;
            return centerPosition;
        }
        /// <summary>
        /// Generate all necessary sliders. 
        /// </summary>
        public static void GenerateSlider()
        {
            string[] value00 = { "1", "2", "3", "4", "5", "6", "7", "8" };
            string[] interval00 = { null };
            AddSlider(0, new Slider("Légende", value00, interval00, 2, 0, 3));
            string[] value01 = { "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
            string[] interval01 = { "5", "100" };
            AddSlider(1, new Slider("Largeur", value01, interval01, 6, 9, 2));
            string[] value02 = { "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
            string[] interval02 = { "5", "100" };
            AddSlider(2, new Slider("Hauteur", value02, interval02, 10, 9, 2));
            string[] value03 = { "Réaliste", "Consigne", "Customisé" };
            string[] interval03 = { null };
            AddSlider(3, new Slider("Icone", value03, interval03, 14, 0, 1));
            string[] value04 = { "Activé", "Désactivé" };
            string[] interval04 = { null };
            AddSlider(4, new Slider("Propagation du feu", value04, interval04, 18, 0, 1));
            string[] value05 = {"*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
            string[] interval05 = { "5", "200"};
            AddSlider(5, new Slider("Fréquence arbres", value05, interval05, 22, 9, 2));
            AddSlider(6, new Slider("Fréquence eau", value05, interval05, 26, 9, 2));
            AddSlider(7, new Slider("Fréquence feuilles", value05, interval05, 30, 9, 2));
            AddSlider(8, new Slider("Fréquence rochers", value05, interval05, 34, 9, 2));
            AddSlider(9, new Slider("Fréquence herbe", value05, interval05, 38, 9, 2));
            
            string[] value06 = { "<",">" };
            string[] interval06 = {};
            AddSlider(10, new Slider("Retour en arrière", value06, interval06, 42, 0, 4));
        }

        #endregion
    }
}
