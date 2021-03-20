using System;

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
        private static readonly Slider[] SliderList = new Slider[10];

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

        #region Accés au slider
        /// <summary>
        /// Retourne la liste des sliders
        /// </summary>
        /// <returns>Tableau de slider</returns>
        public static Slider[] GetSliderList()
        {
            return SliderList;
        }
        /// <summary>
        /// Permet d'obtenir les informations du slider demandé
        /// </summary>
        /// <param name="id">ID du slider recherché</param>
        /// <returns>Les informations du slider recherché</returns>
        public static Slider GetSliderListByID(int id)
        {
            return SliderList[id];
        }
        /// <summary>
        /// Permet d'ajouter un slider
        /// </summary>
        /// <param name="id">ID du slider ajouté</param>
        /// <param name="NewSlider">Informations du slider ajouté</param>
        public static void AddSlider(int id, Slider NewSlider)
        {
            SliderList[id] = NewSlider;
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
            Name = name;
            Value = value;
            Interval = interval;
            Position = position;
            LastSelect = lastSelect;
            SliderType = sliderType;
        }
        #endregion

        /// <summary>
        /// Permet de centrer un l'élément placer en arguments dans le slider
        /// </summary>
        /// <param name="element">élément a centrer</param>
        /// <returns>Position de début d'ecriture afin que l'élément sois centrer</returns>
        public int CenterPositionSlider(string element)
        {
            int CenterPosition = (Console.WindowWidth - Console.WindowWidth / 3 + Console.WindowWidth / 10) - ((Console.WindowWidth / 10 - Console.WindowWidth / 3) / 2) - element.Length / 2;
            return CenterPosition;
        }
        /// <summary>
        /// Fonction permettant de Generer tous les sliders nécéssaire au fonctionnement de l'application
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
            string[] value03 = { "Réaliste", "Consigne" };
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
        }

        #endregion
    }
}
