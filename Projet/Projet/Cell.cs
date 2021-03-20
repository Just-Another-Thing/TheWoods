namespace Projet
{
    public struct Cell
    {
        private int type;
        private int isInFire;
        private int life;
        private float height;
        private bool isFireable;

        

        #region accessers & getters 
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

        /// <summary>
        /// Retourne un caractére en fonction du type retourné
        /// </summary>
        /// <param name="IconeType">Type d'icone séléctionné</param>
        /// <returns>Caractére a affiché</returns>
        public char GetDisplaySymbol(int IconeType)
        {
            char rtrn;
            if (IconeType == 0)
            {
                char[] tab = { 'x','*',' ','#','~','O','\'','.' };
                rtrn = tab[this.type - 1];
            }
            else
            {
                char[] tab = { 'x', '*', '+', ' ', '/', '#', '-', '.' };
                rtrn = tab[this.type - 1];
            }
            return rtrn;
        }

        
        
    }
}
