using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;

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
                for (int i = 0; i < listofFields.Count; i++)
                {
                    int totalRows = listofFields[i].currentCap;
                    Console.WriteLine($"{i + 1}. {listofFields[i].Name} ({totalRows} number of rows)");
                }
                Console.WriteLine();

                Console.WriteLine($"Place {seed.Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                listofFields[choice - 1].AddResource(seed, farm);
            }
            else
            {
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    int totalRows = farm.NaturalFields[i].currentCap;
                    Console.WriteLine($"{i + 1}. Natural field ({totalRows} number of rows)");
                }
                Console.WriteLine();

                Console.WriteLine($"Place {seed.Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                farm.NaturalFields[choice - 1].AddResource(seed, farm);
            }
        }
    }
}
