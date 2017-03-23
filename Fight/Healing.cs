using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public interface Healing
    {
        void setMaxNumOfTargets();
        int getMaxNumOfTargets();
        void setMaxHealPower();
        int getMaxHealPower();
        void healUnits(List<Mob> g);

    }
}