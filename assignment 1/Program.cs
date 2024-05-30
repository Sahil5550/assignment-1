using System;

namespace VirtualPetSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            VirtualPet pet = CreatePet();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        pet.Feed();
                        break;
                    case "2":
                        pet.Play();
                        break;
                    case "3":
                        pet.Rest();
                        break;
                    case "4":
                        pet.DisplayStatus();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting the application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                pet.TimePasses();
            }
        }

        static VirtualPet CreatePet()
        {
            Console.WriteLine("Welcome to the Virtual Pet Simulator!");
            Console.Write("Choose your pet type (cat, dog, horse): ");
            string type = Console.ReadLine();
            Console.Write("Give your pet a name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Welcome, {name} the {type}!");
            return new VirtualPet(name, type);
        }
        
        static void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Feed the pet");
            Console.WriteLine("2. Play with the pet");
            Console.WriteLine("3. Let the pet rest");
            Console.WriteLine("4. Check pet status");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }
    }

    class VirtualPet
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        private int hunger;
        private int happiness;
        private int health;

        public VirtualPet(string name, string type)
        {
            Name = name;
            Type = type;
            hunger = 5;
            happiness = 5;
            health = 5;
        }

        public void Feed()
        {
            hunger = Math.Max(1, hunger - 2);
            health = Math.Min(10, health + 1);
            Console.WriteLine($"{Name} has been fed. Hunger decreased, Health increased.");
        }

        public void Play()
        {
            happiness = Math.Min(10, happiness + 2);
            hunger = Math.Min(10, hunger + 1);
            Console.WriteLine($"{Name} played and is happier now. Happiness increased, Hunger increased.");
        }

        public void Rest()
        {
            health = Math.Min(10, health + 2);
            happiness = Math.Max(1, happiness - 1);
            Console.WriteLine($"{Name} rested. Health increased, Happiness decreased slightly.");
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"\n{Name}'s current status:");
            Console.WriteLine($"Hunger: {hunger}/10");
            Console.WriteLine($"Happiness: {happiness}/10");
            Console.WriteLine($"Health: {health}/10");
            CheckCriticalStatus();
        }

        public void TimePasses()
        {
            hunger = Math.Min(10, hunger + 1);
            happiness = Math.Max(1, happiness - 1);
            Console.WriteLine("\nTime passes...");
            CheckCriticalStatus();
        }

        private void CheckCriticalStatus()
        {
            if (hunger >= 8)
            {
                Console.WriteLine($"{Name} is very hungry! Please feed them.");
            }
            if (happiness <= 2)
            {
                Console.WriteLine($"{Name} is very unhappy! Please play with them.");
            }
            if (health <= 2)
            {
                Console.WriteLine($"{Name} is in poor health! Please take better care of them.");
            }
        }
    }
}
