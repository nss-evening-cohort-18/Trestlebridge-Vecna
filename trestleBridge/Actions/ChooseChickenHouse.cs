using System;
using trestleBridge.Models.Animals;
using trestleBridge.Models.Facilities;

namespace trestleBridge.Actions
{
	public class ChooseChickenHouse
	{
        public static void CollectInput(Farm farm, Chicken chicken)
        {
            List<ChickenHouse> temp = farm.ChickenHouses.Where(x => x.currentCap < x._capacity).ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                int totalAnimals = temp[i].currentCap;
                Console.WriteLine($"{i + 1}. Chicken House ({totalAnimals} animals)");
            }
            Console.WriteLine();

            Console.WriteLine($"Place chicken where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            temp[choice - 1].AddResource(chicken, farm);

        }
    }
}

