using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Battlefield.GameLogic
{
    class Tank
    {
        private int damageCounter = 4;
        private ArrayList tankLocation;
        private bool tankDestroyed;

        public Tank(ArrayList tankLocation)
        {
            this.tankLocation = tankLocation;
            tankDestroyed = false;
        }

        public bool tankHit(String coordinate)
        {
            if (tankLocation.Contains(coordinate))
            {
                damageCounter -= 1;
                tankLocation.Remove(coordinate);
                return true;
            }
            return false;
        }

        public int getDamage()
        {
            const int UNDAMAGED_TANK_CELL_FOUR = 4;
            const int UNDAMAGED_TANK_CELL_THREE = 3;
            const int UNDAMAGED_TANK_CELL_TWO = 2;
            const int UNDAMAGED_TANK_CELL_ONE = 1;

            int damageDone = 0;
            switch (damageCounter)
            {
                case (UNDAMAGED_TANK_CELL_FOUR):
                    damageDone = 20;
                    break;
                case (UNDAMAGED_TANK_CELL_THREE):
                    damageDone = 5;
                    break;
                case (UNDAMAGED_TANK_CELL_TWO):
                    damageDone = 2;
                    break;
                case (UNDAMAGED_TANK_CELL_ONE):
                    damageDone = 1;
                    break;
                default:
                    damageDone = 0;
                    tankDestroyed = true;
                    break;
            }
            return damageDone;
        }

        public ArrayList getTankLocations()
        {
            return tankLocation;
        }

        public bool isTankDestroyed()
        {
            return tankDestroyed;
        }
    }
}
