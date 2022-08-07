using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;
using trestleBridge.Models.Facilities;

namespace trestleBridge.Actions
{
    internal class ChoosePlowedField
    {
        public static void CollectInput(Farm farm, ISeed seed)
        {
            List<PlowedField> temp = farm.PlowedFields.Where(x => x.currentCap < x._capacity).ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                int totalRows = temp[i].currentCap;
                Console.WriteLine($"{i + 1}. Plowed field ({totalRows} number of rows)");
            }
            Console.WriteLine();

            Console.WriteLine($"Place {seed.Name} where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            temp[choice - 1].AddResource(seed, farm);

        }
    }
}
