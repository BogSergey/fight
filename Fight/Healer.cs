using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class Healer : Mob, Healing
    {
        private int maxHealPower;
        private int maxNumOfTargets;


        public int getMaxHealPower()
        {
            return maxHealPower;
        }


        public int getMaxNumOfTargets()
        {
            return maxNumOfTargets;
        }

        public void setMaxHealPower()
        {
            this.maxHealPower = 2;
        }

        public void setMaxNumOfTargets()
        {
            this.maxNumOfTargets = 1;
        }

        public Healer():
            base(3, 0, 5)
        {
            this.setMaxHealPower();
            this.setMaxNumOfTargets();
        }

        public void healUnits(List<Mob> g)
        {
            Random r = new Random();
            int n = r.Next(g.Count);
            if (g[n] is Tower)
            {
                
            }
            else
            {
                g[n].setHP(g[n].getHP() + this.getMaxHealPower());
                if (g[n].getHP() > g[n].getMaxHP()) g[n].setHP(g[n].getMaxHP());
            }
                    
        }
    }
}
