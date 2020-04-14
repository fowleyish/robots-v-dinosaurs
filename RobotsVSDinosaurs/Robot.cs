using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Robot
    {

        public string Name;
        public Weapon Weapon;
        public int Hp;
        public int Strength;
        public bool Defending;

        public Robot(string name, string weapon)
        {
            Name = name;
            Weapon = new Weapon(weapon);
            Hp = getHp();
            Strength = getStrength();
            Defending = false;
        }

        public int getHp()
        {
            int baseHp = 1;
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
    }
}
