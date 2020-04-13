using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class MachineGun
    {
        public int AttackPower;
        public int DefensePower;

        public MachineGun()
        {
            AttackPower = setAttackPower();
            DefensePower = setDefensePower();
        }

        public int setAttackPower()
        {
            int baseAP = 15;
            Random random = new Random();
            int variance = random.Next(1, 3);
            return baseAP + variance;
        }

        public int setDefensePower()
        {
            int baseDP = 10;
            Random random = new Random();
            int variance = random.Next(1, 3);
            return baseDP + variance;
        }
    }
}
