using System;

namespace RobotsVSDinosaurs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Battlefield Battle = new Battlefield();
            Battle.getStatus();
            Battle.controlBattle();
        }
    }
}
