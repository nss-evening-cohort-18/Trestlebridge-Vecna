using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Models.Seeds;

namespace trestleBridge.Actions
{
    internal class PurchaseSeed
    {
            public static void CollectInput(Farm farm)
            {
                Console.WriteLine("1. Sesame");
                Console.WriteLine("2. Sunflower");
                Console.WriteLine("3. Wildflower");

                Console.WriteLine();
                Console.WriteLine("Choose seed to purchase");

                Console.Write("> ");
                string choice = Console.ReadLine();
                int choiceAsNumber;
                int.TryParse(choice, out choiceAsNumber);
                switch (choiceAsNumber)
                {
                    case 1:
                        ChoosePlowedField.CollectInput(farm, new Sesame());
                        break;
                    case 2:
                        ChooseNaturalField.CollectInput(farm, new Sunflower());
                        break;
                    case 3:
                        ChooseNaturalField.CollectInput(farm, new Wildflower());
                        break;
                    default:
                        break;
                }
            }
    }
}
