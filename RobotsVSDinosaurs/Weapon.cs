using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Weapon
    {
        public string WeaponName;
        public int WeaponStrength;
        public int WeaponDefense;

        public Weapon(string weapon)
        {
            WeaponName = weapon;
            WeaponStrength = setAttackPower();
            WeaponDefense = setDefensePower();
        }

        public int setAttackPower()
        {
            if ( WeaponName == "sword" )
            {
                int baseAP = 15;
                Random random = new Random();
                int variance = random.Next(1, 6);
                return baseAP + variance;
            }
            else if (WeaponName == "gun" )
            {
                int baseAP = 19;
                Random random = new Random();
                int variance = random.Next(1, 3);
                return baseAP + variance;
            }
            else
            {
                return 0;
            }
        }

        public int setDefensePower()
        {
            if (WeaponName == "sword")
            {
                int baseDP = 20;
                Random random = new Random();
                int variance = random.Next(1, 4);
                return baseDP + variance;
            }
            else if (WeaponName == "gun")
            {
                int baseDP = 10;
                Random random = new Random();
                int variance = random.Next(1, 3);
                return baseDP + variance;
            }
            else
            {
                return 0;
            }
        }
    }
}
