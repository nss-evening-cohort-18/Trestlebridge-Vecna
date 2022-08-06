using System;
using trestleBridge.Models.Animals;

namespace trestleBridge.Actions
{
	public class ChooseDuckHouse
	{
            public static void CollectInput(Farm farm, Duck duck)
            {
                for (int i = 0; i < farm.DuckHouses.Count; i++)
                {
                    int totalAnimals = farm.DuckHouses[i].currentCap;
                    Console.WriteLine($"{i + 1}. Duck House ({totalAnimals} animals)");
                }
                Console.WriteLine();

                Console.WriteLine($"Place duck where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                farm.DuckHouses[choice - 1].AddResource(duck, farm);

            }
	}
}

