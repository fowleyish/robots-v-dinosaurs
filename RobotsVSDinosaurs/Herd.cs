using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVSDinosaurs
{
    class Herd
    {
        public List<Dinosaur> Dinosaurs;

        public Herd()
        {
            Dinosaurs = getDinosaurs();
        }

        public List<Dinosaur> getDinosaurs()
        {
            List<Dinosaur> Dinosaurs = new List<Dinosaur>();
            while (Dinosaurs.Count < 3)
            {
                Console.Write("Enter a name for your dinosaur: ");
                string dinosaurName = Console.ReadLine();
                Console.Write("Select a job type for your dinosaur (healer or wizard): ");
                string job = Console.ReadLine();
                Dinosaur dinosaur = new Dinosaur(dinosaurName, job);
                Dinosaurs.Add(dinosaur);
            }
            return Dinosaurs;
        }
    }
}
