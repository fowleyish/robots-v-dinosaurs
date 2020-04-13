using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Battlefield
    {
        public Fleet Fleet = new Fleet();
        public Herd Herd = new Herd();
        public int RoundCount = 0;

        public void getStatus()
        {
            Console.WriteLine("Robot stats: ");
            for (int i = 0; i < Fleet.Robots.Count; i++)
            {
                Console.WriteLine("Name: {0}, HP: {1}, Weapon: {2}, Is Defending: {3}", Fleet.Robots[i].Name, Fleet.Robots[i].Hp, Fleet.Robots[i].Weapon.WeaponName, Fleet.Robots[i].Defending.ToString().ToUpper());
            }
            Console.WriteLine("Dinosaur stats: ");
            for (int i = 0; i < Herd.Dinosaurs.Count; i++)
            {
                Console.WriteLine("Name: {0}, HP: {1}, MP: {2}, Job: {3}", Herd.Dinosaurs[i].Name, Herd.Dinosaurs[i].Hp, Herd.Dinosaurs[i].Mp, Herd.Dinosaurs[i].Job.JobName);
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        public void roboRound()
        {
            foreach (Robot robot in Fleet.Robots)
            {
                Console.Write("Press Enter to continue with the Robots' turn");
                Console.ReadLine();
                robot.Defending = false;
                chooseRoboCommand(robot);
            }
        }

        public void chooseRoboCommand(Robot thisRobot)
        {
            Console.Write("Will {0} ATTACK or DEFEND? ", thisRobot.Name);
            string command = Console.ReadLine();
            if ( command.ToLower() == "attack" )
            {
                chooseDinoTarget(thisRobot, "attack");
            }
            else if ( command.ToLower() == "defend" )
            {
                executeRoboCommand(thisRobot, command, null);
            }
            
        }

        public void chooseDinoTarget(Robot robot, string command)
        {
            Console.Write("Which dinosaur will {0} attack? ", robot.Name);
            foreach ( Dinosaur dino in Herd.Dinosaurs) { Console.Write($"{dino.Name} "); }
            string dinoName = Console.ReadLine();
            foreach (Dinosaur dino in Herd.Dinosaurs) { if (dinoName == dino.Name) { executeRoboCommand(robot, command, dino); } }
        }

        public void executeRoboCommand(Robot robot, string command, Dinosaur dino)
        {
            if ( command == "defend" )
            {
                robot.Defending = true;
                Console.WriteLine("{0} is now defending until their next turn!", robot.Name);
            }
            else if ( command == "attack" )
            {
                int damage = (robot.Strength + robot.Weapon.WeaponStrength) / 2;
                dino.Hp -= damage;
                if (dino.Hp > 0)
                {
                    Console.WriteLine("{0} took {1} damage! {0}'s HP is now {2}", dino.Name, damage, dino.Hp);
                }
                else
                {
                    Herd.Dinosaurs.Remove(dino);
                    Console.WriteLine("{0} died!", dino.Name);
                }
            }
        }

        public void dinoRound()
        {
            foreach (Dinosaur dino in Herd.Dinosaurs)
            {
                Console.Write("Press Enter to continue with the Dinosaurs' turn");
                Console.ReadLine();
                chooseDinoCommand(dino);
            }
        }

        public void chooseDinoCommand(Dinosaur thisDino)
        {
            if (thisDino.Job.JobName.ToLower() == "wizard")
            {
                Console.Write("Will {0} use FIREBALL or LIGHTNING BOLT? ", thisDino.Name);
                string command = Console.ReadLine().ToLower();
                chooseRoboOrDinoTarget(thisDino, command);
            }
            else
            {
                Console.Write("Will {0} ATTACK an enemy or HEAL an ally? ", thisDino.Name);
                string command = Console.ReadLine().ToLower();
                chooseRoboOrDinoTarget(thisDino, command);
            }
        }

        public void chooseRoboOrDinoTarget(Dinosaur dino, string command)
        {
            if (command != "heal")
            {
                Console.Write("Which robot will {0} use {1} on? ", dino.Name, command);
                foreach (Robot robo in Fleet.Robots) { Console.Write($"{robo.Name} "); }
                string roboName = Console.ReadLine();
                foreach (Robot robo in Fleet.Robots) { if (roboName == robo.Name) { executeDinoCommand(dino, command, robo, null); } }
            }
            else
            {
                Console.Write("Which dinosaur will {0} heal? ", dino.Name);
                foreach (Dinosaur thisDino in Herd.Dinosaurs) { Console.Write($"{thisDino.Name} ");  }
                string dinoName = Console.ReadLine();
                foreach (Dinosaur targetDino in Herd.Dinosaurs) { if (dinoName == targetDino.Name) { executeDinoCommand(dino, command, null, targetDino); } }
            }
        }

        public void executeDinoCommand(Dinosaur dino, string command, Robot targetRobo, Dinosaur targetDino)
        {
            if (command == "fireball" && dino.Mp >= dino.Job.FireCost)
            {
                int damage = (dino.Intelligence + dino.Job.FireStrength) / 2;
                if (targetRobo.Defending == true) { damage -= 8; }
                targetRobo.Hp -= damage;
                dino.Mp -= dino.Job.FireCost;
                if (targetRobo.Hp > 0)
                {
                    Console.WriteLine("{0} took {1} damage! {0}'s HP is now {2} and {3}'s MP is now {4}", targetRobo.Name, damage, targetRobo.Hp, dino.Name, dino.Mp);
                }
                else
                {
                    Fleet.Robots.Remove(targetRobo);
                    Console.WriteLine("{0} died! {1}'s MP is now {4}", targetRobo.Name, dino.Name, dino.Mp);
                }
            }
            else if (command == "lightning bolt" && dino.Mp >= dino.Job.BoltCost)
            {
                int damage = (dino.Intelligence + dino.Job.BoltStrength) / 2;
                if (targetRobo.Defending == true) { damage -= 8; }
                targetRobo.Hp -= damage;
                dino.Mp -= dino.Job.BoltCost;
                if (targetRobo.Hp > 0)
                {
                    Console.WriteLine("{0} took {1} damage! {0}'s HP is now {2} and {3}'s MP is now {4}", targetRobo.Name, damage, targetRobo.Hp, dino.Name, dino.Mp);
                }
                else
                {
                    Fleet.Robots.Remove(targetRobo);
                    Console.WriteLine("{0} died! {1}'s MP is now {4}", targetRobo.Name, dino.Name, dino.Mp);
                }
            }
            else if (command == "heal" && dino.Mp >= dino.Job.HealCost)
            {
                int health = (dino.Intelligence + dino.Job.HealStrength) / 2;
                targetDino.Hp += health;
                dino.Mp -= dino.Job.HealCost;
                Console.WriteLine("{0} healed by {1} HP! {0}'s HP is now {2} and {3}'s MP is now {4}", targetDino.Name, health, targetDino.Hp, dino.Name, dino.Mp);
            }
            else if (command == "attack")
            {
                int damage = dino.Job.AttackStrength;
                if (targetRobo.Defending == true) { damage -= 8; }
                targetRobo.Hp -= damage;
                if (targetRobo.Hp > 0)
                {
                    Console.WriteLine("{0} took {1} damage! {0}'s HP is now {2}", targetRobo.Name, damage, targetRobo.Hp);
                }
                else
                {
                    Fleet.Robots.Remove(targetRobo);
                    Console.WriteLine("{0} died!", targetRobo.Name);
                }
            }
        }

        public void controlBattle()
        {
            int survivingRobots = Fleet.Robots.Count;
            int survivingDinosaurs = Herd.Dinosaurs.Count;
            while (survivingRobots > 0 || survivingDinosaurs > 0)
            {
                RoundCount += 1;
                Console.WriteLine($"Round {RoundCount}:");
                roboRound();
                dinoRound();
                Console.WriteLine($"Round {RoundCount} complete! Here is are the current teams' standings: ");

            }
        }
    }
}
