using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;

namespace trestleBridge.Actions
{
    internal class ChoosePlowedField
    {
        public static void CollectInput(Farm farm, ISeed seed)
        {
            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                int totalRows = farm.PlowedFields[i].currentCap;
                Console.WriteLine($"{i + 1}. Plowed field ({totalRows} number of rows)");
            }
            Console.WriteLine();

            Console.WriteLine($"Place {seed.Name} where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.PlowedFields[choice - 1].AddResource(seed, farm);

        }
    }
}
