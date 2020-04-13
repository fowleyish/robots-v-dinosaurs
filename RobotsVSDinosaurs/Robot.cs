using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Robot
    {

        public string Name;
        public object Weapon;
        public int Hp;
        public int Strength;

        public Robot(string name, string weapon)
        {
            Name = name;
            Weapon = setWeapon(weapon);
            Hp = getHp();
            Strength = getStrength();
        }

        public int getHp()
        {
            int baseHp = 160;
            Random random = new Random();
            int variance = random.Next(1, 40);
            return baseHp + variance;
        }

        public int getStrength()
        {
            int baseInt = 12;
            Random random = new Random();
            int variance = random.Next(1, 7);
            return baseInt + variance;
        }

        public object setWeapon(string weaponChoice)
        {
            if (weaponChoice == "sword")
            {
                Sword sword = new Sword();
                return sword;
            }
            else
            {
                MachineGun gun = new MachineGun();
                return gun;
            }
        }

        public void attack()
        {

        }

    }
}
