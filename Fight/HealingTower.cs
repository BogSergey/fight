using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class HealingTower : Tower, Healing
    {
    private int maxHealPower;
    private int maxNumOfTargets;

    public HealingTower()
    {
        this.setMaxHP(20);
        this.setHP(20);
        this.setPower(0);
        this.setPriority(1);
        this.setMaxNumOfTargets();
        this.setMaxHealPower();
    }


    
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
        this.maxHealPower = 15;
    }
    
    public void setMaxNumOfTargets()
    {
        this.maxNumOfTargets = 3;
    }
    
    public void healUnits(List<Mob> g)
        {
            Random r = new Random();
            int healPower = this.getMaxNumOfTargets();
            for (int i = 0; i < this.getMaxNumOfTargets(); i++)
            {
                int n = r.Next(g.Count);
                if (g[n] is Tower)
                {
                    i--;
                }
                else
                {
                    int diff = g[n].getMaxHP() - g[n].getHP();
                    if (diff >= healPower) diff = healPower;
                    g[n].setHP(g[n].getHP() + diff);
                    healPower -= diff;
                    if (healPower <= 0) break;
                }
            }
        }

    }
}