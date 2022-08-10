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
        static int nextnum;
        static int lastnum;

        //public static List<IMeatProducing> AllFacilities = new List<IMeatProducing>();
        public static void printMeatProcessorOptions(Farm f)
        {
           // AllFacilities.Clear();

            nextnum = 0;
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
                    if (newNum <= nextnum)
                    {
                        int totalChickens = f.ChickenHouses[newNum - 1]._chickens.Count;
                        Console.WriteLine("You chose Chicken House");
                        Console.WriteLine($"1. Chickens {totalChickens}");
                        Console.WriteLine();
                        Console.WriteLine("how many chickens should be procesed?");
                        string numberToBeProcessed = Console.ReadLine();
                        int numberProcessAsInt;
                        int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                        if ((totalChickens - numberProcessAsInt >= 0) && (MeatProcessor.capacity >= numberProcessAsInt))
                        {
                            Console.WriteLine("Ready to process");
                            string readyToProcess = Console.ReadLine();
                            if (readyToProcess == "y")
                            {
                                    f.ChickenHouses[newNum - 1]._chickens.RemoveRange(0, numberProcessAsInt);
                                    break;
                            }
                            else if (readyToProcess == "n")
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
                        else { break; }
                    } else if (newNum <= lastnum)
                        {
                        Console.WriteLine("You chose Grazing Field");
                        Dictionary<string, int> newAnimals = f.GrazingFields[newNum - nextnum - 1].returnList();
                        for (int i =0; i < newAnimals.Count; i++){
                            Console.WriteLine($"{i + 1}. {newAnimals.ElementAt(i).Value}  {newAnimals.ElementAt(i).Key}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("which animal should be processed?");
                        string animalProcessing = Console.ReadLine();
                        int animalChoiceAsInt;
                        int.TryParse(animalProcessing, out animalChoiceAsInt);

                        string animalType = newAnimals.ElementAt(animalChoiceAsInt - 1).Key;
                        Console.WriteLine($"how many {animalType} do you want to process?");

                        string numberToBeProcessed = Console.ReadLine();
                        int numberProcessAsInt;
                        int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                        if ((newAnimals.ElementAt(animalChoiceAsInt - 1).Value - numberProcessAsInt >= 0) && (MeatProcessor.capacity >= numberProcessAsInt))
                        {
                            Console.WriteLine("Ready to process y/n?");
                            string readyToProcess = Console.ReadLine();
                            if (readyToProcess == "y")
                            {
                                f.GrazingFields[newNum - nextnum - 1]._animals = f.GrazingFields[newNum - nextnum - 1]._animals.OrderByDescending(x => x.Type).ToList();
                                for (int x = 0; x < f.GrazingFields[newNum - nextnum - 1]._animals.Count; x++)
                                {
                                    if (f.GrazingFields[newNum - nextnum - 1]._animals[x].Type == animalType)
                                    {
                                        f.GrazingFields[newNum - nextnum - 1]._animals.RemoveRange(x, numberProcessAsInt);
                                        break;
                                    }
                                }
                            }
                            else if (readyToProcess == "n")
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
                        else { break; }
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
