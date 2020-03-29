using System;
using WalkItLikeYouWagItConsole.Data;
using WalkItLikeYouWagItConsole.Models;

namespace WalkItLikeYouWagItConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // I
            var wrepo = new WalkerRepository();
            var walkers = wrepo.GetAllWalkers();
            Console.WriteLine("All Walkers: \n");
            foreach (var walker in walkers)
            {
                Console.WriteLine($"{walker.Name} is available to walk dogs in {walker.Neighborhood.Name}.");
            }
            Console.WriteLine("\n");

            // II

            var eastNashWalkers = wrepo.GetWalkerByNeighborhood("East Nashville");

            Console.WriteLine("This is a list of the walkers in East Nashville:\n");
            foreach (var walker in eastNashWalkers)
            {
                Console.WriteLine($"{walker.Name}\n");
            }

            // III

            Walker Ryan = new Walker
            {
                Name = "Ryan",
                NeighborhoodId = 2
            };

            wrepo.CreateNewWalker(Ryan);
            Console.WriteLine("----------------");
            Console.WriteLine("1 new walker added to database!\n");

            // IV

            var orepo = new OwnerRepository();
            var owners = orepo.GetAllOwners();

            foreach (var owner in owners)
            {
                Console.WriteLine($"{owner.Name} is an owner in {owner.Neighborhood.Name}.\n");
            }

            // V

            Owner Anna = new Owner
            {
                Name = "Anna",
                NeighborhoodId = 4,
                Phone = "678-447-9557",
                Address = "5605 Stoneway Trail"
            };

            orepo.CreateNewOwner(Anna);
            Console.WriteLine("----------------");
            Console.WriteLine("1 new owner added to database!\n");

            // VI

            Walker Johnny2 = new Walker
            {
                Name = "Johnny",
                NeighborhoodId = 3
            };

            wrepo.UpdateWalker(1, Johnny2);
        }
    }
}

