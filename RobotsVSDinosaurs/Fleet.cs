using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Fleet
    {
        public List<Robot> Robots;

        public Fleet()
        {
            Robots = getRobots();
        }

        public List<Robot> getRobots()
        {
            List<Robot> Robots = new List<Robot>();
            while (Robots.Count < 3)
            {
                Console.Write("Enter a name for your robot: ");
                string robotName = Console.ReadLine();
                Console.Write("Select a weapon for your robot (sword or gun): ");
                string weapon = Console.ReadLine();
                Robot robot = new Robot(robotName, weapon);
                Robots.Add(robot);
            }
            return Robots;
        }

    }
}
