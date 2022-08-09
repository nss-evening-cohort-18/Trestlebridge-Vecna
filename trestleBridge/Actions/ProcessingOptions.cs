using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trestleBridge.Actions
{
    public class ProcessingOptions
    {

        public static void printOptions()
        {
            Console.WriteLine(@"
                        1. Seed Harvester
                        2. Meat Processor
                        3. Egg Gatherer
                        4. Composter
                        5. Feather Harvester

                        Choose equipment to use.
                        >");
            string choice = Console.ReadLine();
            int choiceAsNumber;
            int.TryParse(choice, out choiceAsNumber);
            switch (choiceAsNumber)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;

                default:
                    break;
            }
        }
    }
}
