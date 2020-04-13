using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Healer
    {
        public int HealPower;
        public int AttackPower;

        public Healer()
        {
            HealPower = setHealPower();
            AttackPower = setAttackPower();
        }

        public int setHealPower()
        {
            int baseHeal = 20;
            Random random = new Random();
            int variance = random.Next(1, 4);
            return baseHeal + variance;
        }

        public int setAttackPower()
        {
            int baseAttack = 12;
            Random random = new Random();
            int variance = random.Next(1, 3);
            return baseAttack + variance;
        }

    }
}
