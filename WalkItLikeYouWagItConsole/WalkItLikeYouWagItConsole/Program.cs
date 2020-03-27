using System;
using WalkItLikeYouWagItConsole.Data;

namespace WalkItLikeYouWagItConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new WalkRepository();
            var walks = repo.GetAllWalks();

            foreach (var walk in walks)
            {
                Console.WriteLine($"On {walk.Date}: {walk.Walker.Name} walked {walk.Dog.Name} ");
            }

            var nrepo = new NeighborhoodRepository();
            var nieghborhoods = nrepo.GetAllNeighborhoods();

            foreach (var neighborhood in nieghborhoods)
            {
                Console.WriteLine($"{neighborhood.Name}");
            }
        }
    }
}

