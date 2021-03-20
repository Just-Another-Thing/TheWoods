using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public int GetType()
        {
            return this.type;
        }

        public void SetType(int type) 
        { 
            this.type = type; 
        }

        public int GetIsInFire()
        {
            return this.isInFire;
        }

        public void SetIsInFire(int isInFire)
        {
            this.isInFire = isInFire;
        }

        public int GetLife()
        {
            return this.life;
        }

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


        public bool GetIsFireable()
        {
            return this.isFireable;
        }

        public void SetIsFireable(bool isFireable)
        {
            this.isFireable = isFireable;
        }
        #endregion

        public string GetDisplaySymbol(int IconeType)
        {
            string rtrn = "";
            if (IconeType == 0)
            {
                switch (this.type)
                {
                    case 1:
                        rtrn = "x";
                        break;
                    case 2:
                        rtrn = "*";
                        break;
                    case 3:
                        rtrn = " ";
                        break;
                    case 4:
                        rtrn = "#";
                        break;
                    case 5:
                        rtrn = "~";
                        break;
                    case 6:
                        rtrn = "O";
                        break;
                    case 7:
                        rtrn = "'";
                        break;
                    case 8:
                        rtrn = ".";
                        break;
                }
            }
            else
            {
                switch (this.type)
                {
                    case 1:
                        rtrn = "x";
                        break;
                    case 2:
                        rtrn = "*";
                        break;
                    case 3:
                        rtrn = "+";
                        break;
                    case 4:
                        rtrn = " ";
                        break;
                    case 5:
                        rtrn = "/";
                        break;
                    case 6:
                        rtrn = "#";
                        break;
                    case 7:
                        rtrn = "-";
                        break;
                    case 8:
                        rtrn = ".";
                        break;
                }
            }

            return rtrn;
        }

        
        
    }
}
