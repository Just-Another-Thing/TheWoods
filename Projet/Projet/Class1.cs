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
        private bool isInFire;
        private int life;
        

        #region accessers & getters 
        public int getType()
        {
            return this.type;
        }

        public void setType(int type) 
        { 
            this.type = type; 
        }

        public bool getIsInFire()
        {
            return this.isInFire;
        }

        public void setIsInFire(bool isInFire)
        {
            this.isInFire = isInFire;
        }

        public int getLife()
        {
            return this.life;
        }

        public void setLife(int life)
        {
            this.life = life;
        }
        #endregion

        public string getDisplaySymbol()
        {
            string rtrn = "";
            if (this.type == 1)
            {
                rtrn = "x";
            }else if (this.type == 2)
            {
                rtrn = "*";
            }
            else if (this.type == 3)
            {
                rtrn = " ";
            }
            else if (this.type == 4)
            {
                rtrn = "#";
            }
            else if (this.type == 5)
            {
                rtrn = "~";
            }
            else if (this.type == 6)
            {
                rtrn = "O";
            }
            else if (this.type == 7)
            {
                rtrn = "'";
            }
            else if (this.type == 8)
            {
                rtrn = ".";
            }

            return rtrn;
        }

        
        
    }
}
