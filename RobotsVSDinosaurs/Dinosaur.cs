using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Dinosaur
    {

        public string Name;
        public Job Job;
        public int Hp;
        public int Mp;
        public int Intelligence;

        public Dinosaur(string name, string job)
        {
            Name = name;
            Job = new Job(job);
            Hp = getHp();
            Mp = getMp();
            Intelligence = getIntelligence();
        }

        public int getHp()
        {
            int baseHp = 80;
            Random random = new Random();
            int variance = random.Next(1, 30);
            return baseHp + variance;
        }

        public int getMp()
        {
            int baseMp = 30;
            Random random = new Random();
            int variance = random.Next(1, 6);
            return baseMp + variance;
        }

        public int getIntelligence()
        {
            int baseInt = 26;
            Random random = new Random();
            int variance = random.Next(1, 5);
            return baseInt + variance;
        }
    }
}
