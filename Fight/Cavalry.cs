using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class Cavalry : Warrior
    {

        public Cavalry()
        {
            this.setMaxHP(10);
            this.setHP(10);
            this.setPower(7);
            this.setPriority(3);
        }

    }
}

