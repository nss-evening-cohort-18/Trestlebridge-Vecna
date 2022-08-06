using System;
using trestleBridge.Models.Animals;

namespace trestleBridge.Actions
{
	public class ChooseChickenHouse
	{
        public static void CollectInput(Farm farm, Chicken chicken)
        {
            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                int totalAnimals = farm.ChickenHouses[i].currentCap;
                Console.WriteLine($"{i + 1}. Chicken House ({totalAnimals} animals)");
            }
            Console.WriteLine();

            Console.WriteLine($"Place chicken where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.ChickenHouses[choice - 1].AddResource(chicken, farm);

        }
    }
}

