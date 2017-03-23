using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class AttackTower : Tower
    {
        public AttackTower()
        {
            this.setMaxHP(30);
            this.setHP(30);
            this.setPower(20);
            this.setPriority(1);
        }
    }
}