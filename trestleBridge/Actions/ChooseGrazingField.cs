using System;
using trestleBridge.Interfaces;
using trestleBridge.Models.Facilities;

namespace trestleBridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            // Console.Clear();
            List<GrazingField> temp = farm.GrazingFields.Where(x => x.currentCap < x._capacity).ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                int totalAnimals = temp[i].currentCap;
                Console.WriteLine($"{i + 1}. Grazing Field ({totalAnimals} animals)");
            }
            Console.WriteLine();
            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place {animal.Type.ToLower()} where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            temp[choice -1].AddResource(animal, farm);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);
        }
    }
}

