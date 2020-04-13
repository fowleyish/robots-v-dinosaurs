using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Wizard
    {
        public int FirePower;
        public int BoltPower;

        public Wizard()
        {
            FirePower = setFirePower();
            BoltPower = setBoltPower();
        }

        public int setFirePower()
        {
            int baseFire = 20;
            Random random = new Random();
            int variance = random.Next(1, 10);
            return baseFire + variance;
        }

        public int setBoltPower()
        {
            int baseBolt = 15;
            Random random = new Random();
            int variance = random.Next(1, 20);
            return baseBolt + variance;
        }
    }
}
