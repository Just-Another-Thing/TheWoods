using System;
using TheWoods;

namespace TheWoods
{
    public struct Cell
    {
        private int type;
        private int isInFire;
        private int life;
        private float height;
        private bool isFireable;


        /// <summary>
        /// Region with all accessers/getters necessary for the project. 
        /// </summary>
        #region Accessers
        /// <summary>
        /// Récupere le type d'une cellule
        /// </summary>
        /// <returns>Le type d'une cellule (Entier)</returns>
        public int GetCellType()
        {
            return this.type;
        }
        /// <summary>
        /// Edit le type d'une cellule
        /// </summary>
        /// <param name="type">Entier qui est le type de la cellule</param>
        public void SetType(int type) 
        { 
            this.type = type; 
        }
        /// <summary>
        /// Récupere le niveau de feu d'une cellule
        /// </summary>
        /// <returns>Niveau de feu (Entier)</returns>
        public int GetIsInFire()
        {
            return this.isInFire;
        }
        /// <summary>
        /// Edit le niveau de feu d'une cellule
        /// </summary>
        /// <param name="isInFire">Niveau de feu (Entier)</param>
        public void SetIsInFire(int isInFire)
        {
            this.isInFire = isInFire;
        }
        /// <summary>
        /// Récuperer le niveau de vie de la cellule
        /// </summary>
        /// <returns>Niveau de vie (Entier)</returns>
        public int GetLife()
        {
            return this.life;
        }
        /// <summary>
        /// Edit le niveau de vie d'une cellule
        /// </summary>
        /// <param name="life">Niveau de vie (Entier)</param>
        public void SetLife(int life)
        {
            this.life = life;
        }


        public float GetHeight()
        {
            return this.height;
        }

        public void SetHeight(float height)
        {
            this.height = height;
        }

        /// <summary>
        /// Savoir si la cellule est en feu
        /// </summary>
        /// <returns>True si en feu sinon false</returns>
        public bool GetIsFireable()
        {
            return this.isFireable;
        }
        /// <summary>
        /// Edit si la cellule est en feu
        /// </summary>
        /// <param name="isFireable">Bool si la cellule est en feu</param>
        public void SetIsFireable(bool isFireable)
        {
            this.isFireable = isFireable;
        }
        #endregion


        public CustomIcone.Icone GetIcone(int IconeType)
        {
            CustomIcone.Icone rtrn;
            if (IconeType == 0)
            {
                CustomIcone.Icone[] tab = new CustomIcone.Icone[]
                {
                    new CustomIcone.Icone('X',9),
                    new CustomIcone.Icone('*',7),
                    new CustomIcone.Icone(' ',14),
                    new CustomIcone.Icone('#',2),
                    new CustomIcone.Icone('~',10),
                    new CustomIcone.Icone('O',14),
                    new CustomIcone.Icone('\'',14),
                    new CustomIcone.Icone('.',14),
                };
                rtrn = tab[this.type - 1];
            }
            else if(IconeType == 1)
            {
                CustomIcone.Icone[] tab = new CustomIcone.Icone[]
                {
                    new CustomIcone.Icone('X',9),
                    new CustomIcone.Icone('*',7),
                    new CustomIcone.Icone('+',14),
                    new CustomIcone.Icone(' ',2),
                    new CustomIcone.Icone('/',10),
                    new CustomIcone.Icone('#',14),
                    new CustomIcone.Icone('-',14),
                    new CustomIcone.Icone('.',14),
                };
                rtrn = tab[this.type - 1];
            }
            else
            {
                CustomIcone.Icone[] tab = CustomIcone.CustomIconeList;
                rtrn = tab[this.type - 1];
            }
            return rtrn;
        }

        /// <summary>
        /// Return the symbol associated with the type and the icone type. 
        /// </summary>
        /// <param name="IconeType">The icone type. Refer to how the a type should look</param>
        /// <returns>The "char" to display</returns>
        public char GetDisplaySymbol(int IconeType)
        {
            return GetIcone(IconeType).GetIconeIcon();
        }
        
        public void GetColorSymbol(int IconeType, bool InFire)
        {
            CustomIcone.GetColor(GetIcone(IconeType), InFire, IconeType);

        }
    }
}
