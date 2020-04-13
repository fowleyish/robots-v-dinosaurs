using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Job
    {
        public string JobName;
        public int FireStrength;
        public int BoltStrength;
        public int HealStrength;
        public int FireCost;
        public int BoltCost;
        public int HealCost;
        public int AttackStrength;

        public Job(string job)
        {
            JobName = job;
            FireStrength = setMagicPower(null);
            BoltStrength = setMagicPower(null);
            HealStrength = setHealPower();
            FireCost = 3;
            BoltCost = 4;
            HealCost = 3;
            AttackStrength = setAttackPower();
        }

        public int setAttackPower()
        {
            int baseAttack = 20;
            Random random = new Random();
            int variance = random.Next(1, 6);
            return baseAttack + variance;
        }

        public int setHealPower()
        {
            int baseHeal = 25;
            Random random = new Random();
            int variance = random.Next(1, 5);
            return baseHeal + variance;
        }

        public int setMagicPower(string spell)
        {
            if (spell == "fireball")
            {
                int baseFire = 20;
                Random random = new Random();
                int variance = random.Next(1, 20);
                return baseFire + variance;
            }
            else if (spell == "lightning bolt")
            {
                int baseBolt = 30;
                Random random = new Random();
                int variance = random.Next(1, 5);
                return baseBolt + variance;
            }
            else
            {
                return 0;
            }
        }
    }
}
