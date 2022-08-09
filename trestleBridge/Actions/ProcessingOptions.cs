using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;
using trestleBridge.Models.Animals;
using trestleBridge.Models.NewFolder1;

namespace trestleBridge.Actions
{
    public class ProcessingOptions
    {
        static int num;
        static int nextnum;
        static int lastnum;

        //public static List<IMeatProducing> AllFacilities = new List<IMeatProducing>();
        public static void printMeatProcessorOptions(Farm f)
        {
           // AllFacilities.Clear();
             num = 0;
            for (int i = 0; i < f.DuckHouses.Count; i++)
            {
               // AllFacilities.Add(f.DuckHouses[i]);
                Console.WriteLine($"{num + 1}. {f.DuckHouses[i].FieldName} ({f.DuckHouses[i].currentCap})");
                num++;
            }
             nextnum = num;
            for (int i = 0; i < f.ChickenHouses.Count; i++)
            {
                //AllFacilities.Add(f.ChickenHouses[i]);
                Console.WriteLine($"{nextnum + 1}. {f.ChickenHouses[i].FieldName} ({f.ChickenHouses[i].currentCap})");
                nextnum++;
            }
             lastnum = nextnum;
            for (int i = 0; i < f.GrazingFields.Count; i++)
            {
                //AllFacilities.Add(f.GrazingFields[i]);
                Console.WriteLine($"{lastnum + 1}. {f.GrazingFields[i].FieldName} ({f.GrazingFields[i].currentCap})");
                lastnum++;
            }
            
        }
        public static void printOptions(Farm f)
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
                    printMeatProcessorOptions(f);
                    Console.WriteLine("Please pick facility");
                    string nextChoice = Console.ReadLine();
                    int newNum;
                    int.TryParse(nextChoice, out newNum);
                    if(newNum <= num)
                    {
                        int totalDucks =  f.DuckHouses[newNum - 1]._ducks.Count;
                        Console.WriteLine("You chose Duck House");
                        Console.WriteLine($"1. Ducks {totalDucks}");
                        Console.WriteLine();
                        Console.WriteLine("how many ducks should be procesed?");
                        string numberToBeProcessed = Console.ReadLine();
                        int numberProcessAsInt;
                        int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                        if((totalDucks - numberProcessAsInt >= 0) && (MeatProcessor.capacity >= numberProcessAsInt))
                        {
                            Console.WriteLine("Ready to process");
                            string readyToProcess = Console.ReadLine();
                            if(readyToProcess == "y")
                            {
                                for (int i = 0; i < numberProcessAsInt; i++)
                                {
                                    f.DuckHouses[newNum - 1]._ducks.RemoveRange(0, numberProcessAsInt);
                                   // Program.Start();
                                   break;
                                }
                            }else if(readyToProcess == "n")
                            {
                                printMeatProcessorOptions(f);
                            }
                            else
                            {
                                //refactor loop to be while
                                Console.WriteLine("invalid input, try again");
                                printMeatProcessorOptions(f);
                            }

                        }
                    } else if (newNum <= nextnum)
                    {
                        //int totalChickens = f.ChickenHouses[choiceAsNumber - 1]
                    } else if (newNum <= lastnum)
                    {

                    }


                    Console.ReadLine();
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
