using System;
using trestleBridge.Models.Animals;
using trestleBridge.Models.Facilities;

namespace trestleBridge.Actions
{
	public class ChooseDuckHouse
	{
            public static void CollectInput(Farm farm, Duck duck)
            {
            List<DuckHouse> temp = farm.DuckHouses.Where(x => x.currentCap < x._capacity).ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    int totalAnimals = temp[i].currentCap;
                    Console.WriteLine($"{i + 1}. Duck House ({totalAnimals} animals)");
                }
                Console.WriteLine();

                Console.WriteLine($"Place duck where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                temp[choice - 1].AddResource(duck, farm);

            }
	}
}

