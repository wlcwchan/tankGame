using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Battlefield.GameLogic
{
    class GameUtilities
    {
        public static bool tankHit(ArrayList enemyTanks, String coordinate)
        {
            foreach (Tank tank in enemyTanks)
            {
                if (tank.tankHit(coordinate))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isFortressDestroyed(int fortressHitPoints)
        {
            return (fortressHitPoints > 0) ? true : false;
        }

        public static bool isTanksDestroyed(ArrayList enemyTanks, int numTanks)
        {
            foreach (Tank tank in enemyTanks)
            {
                numTanks -= tank.isTankDestroyed() ? 1 : 0;
            }
            return (numTanks) == 0 ? true : false;
        }
    }
}
