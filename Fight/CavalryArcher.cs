using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class CavalryArcher : Archer
        {
        public CavalryArcher()
            {
                this.setMaxHP(7);
                this.setHP(7);
                this.setPower(10);
                this.setPriority(2);
            }
    }
}