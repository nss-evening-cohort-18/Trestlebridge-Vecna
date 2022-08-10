using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;
using trestleBridge.Models.Facilities;

namespace trestleBridge.Actions
{
    public class ChooseNaturalField
    {
        public static void CollectInput(Farm farm, ISeed seed)
        {

            if (seed.Name == "SunFlower") {
                List<IFields> listofFields = new List<IFields>();
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    listofFields.Add(farm.NaturalFields[i]);   
                }
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    listofFields.Add(farm.PlowedFields[i]);
                }
                List<IFields> temp = listofFields.Where(x => x.currentCap < x._capacity).ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    int totalRows = temp[i].currentCap;
                    Console.WriteLine($"{i + 1}. {temp[i].Name} ({totalRows} number of rows)");
                }
                Console.WriteLine();

                Console.WriteLine($"Place {seed.Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                temp[choice - 1].AddResource(seed, farm);
            }
            else
            {
                List<NaturalField> temp = farm.NaturalFields.Where(x => x.currentCap < x._capacity).ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    int totalRows = temp[i].currentCap;
                    Console.WriteLine($"{i + 1}. Natural field ({totalRows} number of rows)");
                }
                Console.WriteLine();

                Console.WriteLine($"Place {seed.Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                temp[choice - 1].AddResource(seed, farm);
            }
        }
    }
}
