using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battlefield.GameLogic
{
    class Fortress
    {
        private int fortressHitpoints;

        public Fortress(int fortressHitpoints) 
        {
            this.fortressHitpoints = fortressHitpoints;
        }

        public int getHitpoints()
        {
            return fortressHitpoints;
        }

        public void subtractHitPoints(int damage)
        {
            fortressHitpoints -= damage;
            if (fortressHitpoints < 0)
            {
                fortressHitpoints = 0;
            }
        }
    }
}
