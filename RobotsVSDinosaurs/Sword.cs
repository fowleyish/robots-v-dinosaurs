using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Sword
    {
        public int AttackPower;
        public int DefensePower;

        public Sword()
        {
            AttackPower = setAttackPower();
            DefensePower = setDefensePower();
        }

        public int setAttackPower()
        {
            int baseAP = 10;
            Random random = new Random();
            int variance = random.Next(1, 6);
            return baseAP + variance;
        }

        public int setDefensePower()
        {
            int baseDP = 20;
            Random random = new Random();
            int variance = random.Next(1, 4);
            return baseDP + variance;
        }
    }
}
