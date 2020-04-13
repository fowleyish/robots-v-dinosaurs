using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Dinosaur
    {

        public string Name;
        public object Job;
        public int Hp;
        public int Mp;
        public int Intelligence;

        public Dinosaur(string name, string job)
        {
            Name = name;
            Job = setJob(job);
            Hp = getHp();
            Mp = getMp();
            Intelligence = getIntelligence();
        }

        public int getHp()
        {
            int baseHp = 100;
            Random random = new Random();
            int variance = random.Next(1, 20);
            return baseHp + variance;
        }

        public int getMp()
        {
            int baseMp = 5;
            Random random = new Random();
            int variance = random.Next(1, 3);
            return baseMp + variance;
        }

        public int getIntelligence()
        {
            int baseInt = 10;
            Random random = new Random();
            int variance = random.Next(1, 5);
            return baseInt + variance;
        }

        public object setJob(string jobChoice)
        {
            if (jobChoice == "wizard")
            {
                Wizard wizard = new Wizard();
                return wizard;
            }
            else
            {
                Healer healer = new Healer();
                return healer;
            }
        }
    }
}
