using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;
using trestleBridge.Models.Animals;
using trestleBridge.Models.NewFolder1;
using trestleBridge.Models.Processors;

namespace trestleBridge.Actions
{
    public class ProcessingOptions
    {
        static int num;
        static int nextnum;
        static int lastnum;

        public static void printCompostProcessorOptions(Farm f)
        {
            num = 0;
            for (int i = 0; i < f.NaturalFields.Count; i++)
            {
                Console.WriteLine($"{num + 1}. {f.NaturalFields[i].Name} ({f.NaturalFields[i].currentCap})");
                num++;
            }
            nextnum = num;
            for (int i = 0; i < f.PlowedFields.Count; i++)
            {
                Console.WriteLine($"{nextnum + 1}. {f.PlowedFields[i].Name} ({f.PlowedFields[i].currentCap})");
                nextnum++;
            }
            lastnum = nextnum;
            for (int i = 0; i < f.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{lastnum + 1}. {f.GrazingFields[i].FieldName} ({f.GrazingFields[i].currentCap})");
                lastnum++;
            }
        }

        public static void printSeedProcessorOptions(Farm f)
        {
            nextnum = 0;
            for (int i = 0; i < f.NaturalFields.Count; i++)
            {
                Console.WriteLine($"{nextnum + 1}. {f.NaturalFields[i].Name} ({f.NaturalFields[i].currentCap})");
                nextnum++;
            }
            lastnum = nextnum;
            for (int i = 0; i < f.PlowedFields.Count; i++)
            {
                Console.WriteLine($"{lastnum + 1}. {f.PlowedFields[i].Name} ({f.PlowedFields[i].currentCap})");
                lastnum++;
            }
        }

            public static void printEggProcessorOptions(Farm f)
        {
            num = 0;
            for (int i = 0; i < f.ChickenHouses.Count; i++)
            {
                Console.WriteLine($"{num + 1}. {f.ChickenHouses[i].FieldName} ({f.ChickenHouses[i].currentCap})");
                num++;
            }
            nextnum = num;
            for (int i = 0; i < f.DuckHouses.Count; i++)
            {
                Console.WriteLine($"{nextnum + 1}. {f.DuckHouses[i].FieldName} ({f.DuckHouses[i].currentCap})");
                nextnum++;
            }
            lastnum = nextnum;
            for (int i = 0; i < f.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{lastnum + 1}. {f.GrazingFields[i].FieldName} ({f.GrazingFields[i].currentCap})");
                lastnum++;
            }
        }

        public static void printMeatProcessorOptions(Farm f)
        {
            nextnum = 0;
            for (int i = 0; i < f.ChickenHouses.Count; i++)
            {
                Console.WriteLine($"{nextnum + 1}. {f.ChickenHouses[i].FieldName} ({f.ChickenHouses[i].currentCap})");
                nextnum++;
            }
             lastnum = nextnum;
            for (int i = 0; i < f.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{lastnum + 1}. {f.GrazingFields[i].FieldName} ({f.GrazingFields[i].currentCap})");
                lastnum++;
            }
            
        }

        public static void printFeatherProcessingOptions(Farm f)
        {
            nextnum = 0;
            for (int i = 0; i < f.ChickenHouses.Count; i++)
            {
                Console.WriteLine($"{nextnum + 1}. {f.ChickenHouses[i].FieldName} ({f.ChickenHouses[i].currentCap})");
                nextnum++;
            }
            lastnum = nextnum;
            for (int i = 0; i < f.DuckHouses.Count; i++)
            {
                Console.WriteLine($"{lastnum + 1}. {f.DuckHouses[i].FieldName} ({f.DuckHouses[i].currentCap})");
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
                    printSeedProcessorOptions(f);
                    Console.WriteLine("Please pick facility");
                    string nextChoice = Console.ReadLine();
                    int newNum;
                    int.TryParse(nextChoice, out newNum);
                    if (newNum <= nextnum)
                    {
                        int totalSeeds = f.NaturalFields[newNum - 1]._seeds.Count;
                        Console.WriteLine("You chose Natural Field");
                        Dictionary<string, int> newSeeds = f.NaturalFields[newNum - 1].returnList();
                        // print shit out in order by seed name
                        for (int i = 0; i < newSeeds.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {newSeeds.ElementAt(i).Value}  {newSeeds.ElementAt(i).Key}");
                        }

                        Console.WriteLine();

                        Console.WriteLine("which seed should be processed?");
                        string animalProcessing = Console.ReadLine();
                        int seedChoiceAsInt;
                        int.TryParse(animalProcessing, out seedChoiceAsInt);

                        //////ewrqewreqwr qwrpewqrqew98o ryueqw9reqwghuqr
                        string seedType = newSeeds.ElementAt(seedChoiceAsInt - 1).Key;
                        if (seedType == "SunFlower")
                        {
                            Console.WriteLine("how many Sunflowers would you like to process");
                            string numberToBeProcessed = Console.ReadLine();
                            int numberProcessAsInt;
                            int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                            if ((totalSeeds - numberProcessAsInt >= 0) && (SeedProcessor.capacity >= numberProcessAsInt))
                            {
                                Console.WriteLine("Ready to process");
                                string readyToProcess = Console.ReadLine();
                                if (readyToProcess == "y")
                                {
                                    f.NaturalFields[newNum - 1]._seeds = f.NaturalFields[newNum - 1]._seeds.OrderByDescending(x => x.Name).ToList();
                                    for (int x = 0; x < f.NaturalFields[newNum - 1]._seeds.Count; x++)
                                    {
                                        if (f.NaturalFields[newNum - 1]._seeds[x].Name == seedType)
                                        {
                                            f.NaturalFields[newNum - 1]._seeds.RemoveRange(x, numberProcessAsInt);
                                            break;
                                        }
                                    }
                                }
                                else if (readyToProcess == "n")
                                {
                                    printSeedProcessorOptions(f);
                                }
                                else
                                {
                                    //refactor loop to be while
                                    Console.WriteLine("invalid input, try again");
                                    printSeedProcessorOptions(f);
                                }
                            }
                            else { break; }
                        }
                        else { break; }
                        }
                        else if (newNum <= lastnum)
                        {
                        int totalSeeds = f.PlowedFields[newNum - nextnum - 1]._seeds.Count;
                        Console.WriteLine("You chose Plowed Field");
                        Dictionary<string, int> newSeeds = f.PlowedFields[newNum - nextnum - 1].returnList();
                        // print shit out in order by seed name
                        for (int i = 0; i < newSeeds.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {newSeeds.ElementAt(i).Value}  {newSeeds.ElementAt(i).Key}");
                        }

                        Console.WriteLine();

                        Console.WriteLine("which seed should be processed?");
                        string animalProcessing = Console.ReadLine();
                        int seedChoiceAsInt;
                        int.TryParse(animalProcessing, out seedChoiceAsInt);

                        //////ewrqewreqwr qwrpewqrqew98o ryueqw9reqwghuqr
                        string seedType = newSeeds.ElementAt(seedChoiceAsInt - 1).Key;
                            Console.WriteLine("how many Sunflowers would you like to process");
                            string numberToBeProcessed = Console.ReadLine();
                            int numberProcessAsInt;
                            int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                            if ((totalSeeds - numberProcessAsInt >= 0) && (SeedProcessor.capacity >= numberProcessAsInt))
                            {
                                Console.WriteLine("Ready to process");
                                string readyToProcess = Console.ReadLine();
                                if (readyToProcess == "y")
                                {
                                    f.PlowedFields[newNum - nextnum - 1]._seeds = f.PlowedFields[newNum - nextnum - 1]._seeds.OrderByDescending(x => x.Name).ToList();
                                    for (int x = 0; x < f.PlowedFields[newNum - nextnum - 1]._seeds.Count; x++)
                                    {
                                        if (f.PlowedFields[newNum - nextnum - 1]._seeds[x].Name == seedType)
                                        {
                                            f.PlowedFields[newNum - nextnum - 1]._seeds.RemoveRange(x, numberProcessAsInt);
                                            break;
                                        }
                                    }
                                }
                                else if (readyToProcess == "n")
                                {
                                    printSeedProcessorOptions(f);
                                }
                                else
                                {
                                    //refactor loop to be while
                                    Console.WriteLine("invalid input, try again");
                                    printSeedProcessorOptions(f);
                                }
                            }
                        else { break; }
                    }
                    

                    Console.ReadLine();
                    break;
                case 2:
                    printFeatherProcessingOptions(f);
                    Console.WriteLine("Please pick facility");
                    nextChoice = Console.ReadLine();
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
                        if (animalType != "Goat")
                        {
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
                        } else { break; }
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    printEggProcessorOptions(f);
                    Console.WriteLine("Please pick facility");
                    nextChoice = Console.ReadLine();
                    int.TryParse(nextChoice, out newNum);
                    if (newNum <= num)
                    {
                        int totalChickens = f.ChickenHouses[newNum - 1]._chickens.Count;
                        Console.WriteLine("You chose Chicken House");
                        Console.WriteLine($"1. Chickens {totalChickens}");
                        Console.WriteLine();
                        Console.WriteLine("how many chickens should be procesed?");
                        string numberToBeProcessed = Console.ReadLine();
                        int numberProcessAsInt;
                        int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                        if ((totalChickens - numberProcessAsInt >= 0) && (EggProcessor.capacity >= numberProcessAsInt))
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
                                printEggProcessorOptions(f);
                            }
                            else
                            {
                                //refactor loop to be while
                                Console.WriteLine("invalid input, try again");
                                printEggProcessorOptions(f);
                            }
                        }
                        else { break; }
                    }
                    else if (newNum <= nextnum)
                    {
                        Console.WriteLine("You chose Duck house");
                        int totalDucks = f.DuckHouses[newNum - num - 1]._ducks.Count;
                        Console.WriteLine("You chose Duck House");
                        Console.WriteLine($"1. Ducks {totalDucks}");
                        Console.WriteLine();
                        Console.WriteLine("how many ducks should be procesed?");
                        string numberToBeProcessed = Console.ReadLine();
                        int numberProcessAsInt;
                        int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                        if ((totalDucks - numberProcessAsInt >= 0) && (EggProcessor.capacity >= numberProcessAsInt))
                        {
                            Console.WriteLine("Ready to process");
                            string readyToProcess = Console.ReadLine();
                            if (readyToProcess == "y")
                            {
                                f.DuckHouses[newNum - num - 1]._ducks.RemoveRange(0, numberProcessAsInt);
                                break;
                            }
                            else if (readyToProcess == "n")
                            {
                                printEggProcessorOptions(f);
                            }
                            else
                            {
                                //refactor loop to be while
                                Console.WriteLine("invalid input, try again");
                                printEggProcessorOptions(f);
                            }
                        }
                        else { break; }
                    }
                    else if (newNum <= lastnum)
                    {
                        Console.WriteLine("You chose Grazing Field");
                        Dictionary<string, int> newAnimals = f.GrazingFields[newNum - nextnum - 1].returnList();
                        for (int i = 0; i < newAnimals.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {newAnimals.ElementAt(i).Value}  {newAnimals.ElementAt(i).Key}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("which animal should be processed?");
                        string animalProcessing = Console.ReadLine();
                        int animalChoiceAsInt;
                        int.TryParse(animalProcessing, out animalChoiceAsInt);

                        string animalType = newAnimals.ElementAt(animalChoiceAsInt - 1).Key;
                        if (animalType == "Ostrich")
                        {
                            Console.WriteLine($"how many {animalType} do you want to process?");

                            string numberToBeProcessed = Console.ReadLine();
                            int numberProcessAsInt;
                            int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                            if ((newAnimals.ElementAt(animalChoiceAsInt - 1).Value - numberProcessAsInt >= 0) && (EggProcessor.capacity >= numberProcessAsInt))
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
                                    printEggProcessorOptions(f);
                                }
                                else
                                {
                                    //refactor loop to be while
                                    Console.WriteLine("invalid input, try again");
                                    printEggProcessorOptions(f);
                                }
                            }
                            else { break; }
                        }
                        else { break; }
                    }
                        Console.ReadLine();
                    break;
                case 4:
                    printCompostProcessorOptions(f);
                    Console.WriteLine("Please pick facility");
                    nextChoice = Console.ReadLine();
                    int.TryParse(nextChoice, out newNum);
                    if (newNum <= num)
                    {
                        int totalSeeds = f.NaturalFields[newNum - 1]._seeds.Count;
                        Console.WriteLine("You chose Natural Field");
                        Dictionary<string, int> newSeeds = f.NaturalFields[newNum - 1].returnList();
                        for (int i = 0; i < newSeeds.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {newSeeds.ElementAt(i).Value}  {newSeeds.ElementAt(i).Key}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("which seed should be processed?");
                        string seedToProcess = Console.ReadLine();
                        int seedProcessNumber;
                        int.TryParse(seedToProcess, out seedProcessNumber);
                        string chosenSeed = newSeeds.ElementAt(seedProcessNumber - 1).Key;

                        Console.WriteLine($"how many {chosenSeed} do you want to process");
                        string numberToBeProcessed = Console.ReadLine();
                        int numberProcessAsInt;
                        int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                        if ((totalSeeds - numberProcessAsInt >= 0) && (CompostProcessor.capacity >= numberProcessAsInt))
                        {
                            Console.WriteLine("Ready to process");
                            string readyToProcess = Console.ReadLine();
                            if (readyToProcess == "y")
                            {
                                f.NaturalFields[newNum - 1]._seeds = f.NaturalFields[newNum - 1]._seeds.OrderBy(x => x.Name).ToList();
                                for (int i = 0; i < f.NaturalFields[newNum - 1]._seeds.Count; i++)
                                {
                                    if(f.NaturalFields[newNum - 1]._seeds[i].Name == chosenSeed) {
                                        f.NaturalFields[newNum - 1]._seeds.RemoveRange(i, numberProcessAsInt);
                                        break;
                                    }
                                }
                                break;
                            }
                            else if (readyToProcess == "n")
                            {
                                printCompostProcessorOptions(f);
                            }
                            else
                            {
                                //refactor loop to be while
                                Console.WriteLine("invalid input, try again");
                                printCompostProcessorOptions(f);
                            }
                        }
                        else { break; }
                    }
                    else if (newNum <= nextnum)
                    {
                        Console.WriteLine("You chose Plowed Field");
                        int totalSeeds = f.PlowedFields[newNum - num - 1]._seeds.Count;;
                        Dictionary<string, int> seedDictionary = f.PlowedFields[newNum - num - 1].returnList();
                        for (int i = 0; i < seedDictionary.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {seedDictionary.ElementAt(i).Value} {seedDictionary.ElementAt(i).Key}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("which seed do you want to process");
                        string seedToProcess = Console.ReadLine();
                        int seedToProcessInt;
                        int.TryParse(seedToProcess,out seedToProcessInt);
                        string chosenSeed = seedDictionary.ElementAt(seedToProcessInt - 1).Key;
                        if (chosenSeed == "SunFlower")
                        {
                            Console.WriteLine("how many sunflowers do you want to process");
                            string numberToBeProcessed = Console.ReadLine();
                            int numberProcessAsInt;
                            int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                            if ((totalSeeds - numberProcessAsInt >= 0) && (CompostProcessor.capacity >= numberProcessAsInt))
                            {
                                Console.WriteLine("Ready to process");
                                string readyToProcess = Console.ReadLine();
                                if (readyToProcess == "y")
                                {
                                    f.PlowedFields[newNum - num - 1]._seeds = f.PlowedFields[newNum- num - 1]._seeds.OrderBy(x => x.Name).ToList();
                                    for (int i = 0; i < f.PlowedFields[newNum - 1]._seeds.Count; i++)
                                    {
                                        if (f.PlowedFields[newNum - num - 1]._seeds[i].Name == chosenSeed)
                                        {
                                            f.PlowedFields[newNum - num - 1]._seeds.RemoveRange(i, numberProcessAsInt);
                                            break;
                                        }
                                    }
                                    break;
                                }
                                else if (readyToProcess == "n")
                                {
                                    printCompostProcessorOptions(f);
                                }
                                else
                                {
                                    //refactor loop to be while
                                    Console.WriteLine("invalid input, try again");
                                    printCompostProcessorOptions(f);
                                }
                            }
                            else { break; }
                        }else { break; }
                    }
                    else if (newNum <= lastnum)
                    {
                        Console.WriteLine("You chose Grazing Field");
                        Dictionary<string, int> newAnimals = f.GrazingFields[newNum - nextnum - 1].returnList();
                        for (int i = 0; i < newAnimals.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {newAnimals.ElementAt(i).Value}  {newAnimals.ElementAt(i).Key}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("which animal should be processed?");
                        string animalProcessing = Console.ReadLine();
                        int animalChoiceAsInt;
                        int.TryParse(animalProcessing, out animalChoiceAsInt);

                        string animalType = newAnimals.ElementAt(animalChoiceAsInt - 1).Key;
                        if (animalType == "Goat")
                        {
                            Console.WriteLine($"how many {animalType} do you want to process?");

                            string numberToBeProcessed = Console.ReadLine();
                            int numberProcessAsInt;
                            int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                            if ((newAnimals.ElementAt(animalChoiceAsInt - 1).Value - numberProcessAsInt >= 0) && (CompostProcessor.capacity >= numberProcessAsInt))
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
                                    printCompostProcessorOptions(f);
                                }
                                else
                                {
                                    //refactor loop to be while
                                    Console.WriteLine("invalid input, try again");
                                    printCompostProcessorOptions(f);
                                }
                            }
                            else { break; }
                        }
                        else { break; }
                    }
                    Console.ReadLine();
                    break;
                case 5:
                    printFeatherProcessingOptions(f);
                    Console.WriteLine("Please pick facility");
                    nextChoice = Console.ReadLine();
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
                        if ((totalChickens - numberProcessAsInt >= 0) && (FeatherProcessor.capacity >= numberProcessAsInt))
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
                                printFeatherProcessingOptions(f);
                            }
                            else
                            {
                                //refactor loop to be while
                                Console.WriteLine("invalid input, try again");
                                printFeatherProcessingOptions(f);
                            }
                        }
                        else { break; }
                    }
                    else if (newNum <= lastnum)
                    {
                        int totalDucks = f.DuckHouses[newNum - nextnum - 1]._ducks.Count;
                        Console.WriteLine("You chose Duck House");
                        Console.WriteLine($"1. Ducks {totalDucks}");
                        Console.WriteLine();
                        Console.WriteLine("how many ducks should be procesed?");
                        string numberToBeProcessed = Console.ReadLine();
                        int numberProcessAsInt;
                        int.TryParse(numberToBeProcessed, out numberProcessAsInt);
                        if ((totalDucks - numberProcessAsInt >= 0) && (FeatherProcessor.capacity >= numberProcessAsInt))
                        {
                            Console.WriteLine("Ready to process");
                            string readyToProcess = Console.ReadLine();
                            if (readyToProcess == "y")
                            {
                                f.DuckHouses[newNum - nextnum - 1]._ducks.RemoveRange(0, numberProcessAsInt);
                                break;
                            }
                            else if (readyToProcess == "n")
                            {
                                printFeatherProcessingOptions(f);
                            }
                            else
                            {
                                //refactor loop to be while
                                Console.WriteLine("invalid input, try again");
                                printFeatherProcessingOptions(f);
                            }
                        }
                        else { break; }
                    }
                    Console.ReadLine();
                    break;

                default:
                    break;
            }
        }
    }
}
