﻿using trestleBridge;
using trestleBridge.Actions;
using trestleBridge.Models;

static void DisplayBanner()
{
    // Console.Clear();
    Console.WriteLine();
    Console.WriteLine(@"
        +-++-++-++-++-++-++-++-++-++-++-++-++-+
        |T||r||e||s||t||l||e||b||r||i||d||g||e|
        +-++-++-++-++-++-++-++-++-++-++-++-++-+
                    |F||a||r||m||s|
                    +-++-++-++-++-+");
    Console.WriteLine();
}

static void Start()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.DarkMagenta;
    Farm Trestlebridge = new Farm();
    while (true)
    {
        DisplayBanner();
        Console.WriteLine("1. Create Facility");
        Console.WriteLine("2. Purchase Animals");
        Console.WriteLine("3. Purchase Seeds");
        Console.WriteLine("4. Display Farm Status");
        Console.WriteLine("5. Processing Options");
        Console.WriteLine("6. Exit");
        Console.WriteLine();
        Console.WriteLine("Choose a FARMS option");
        Console.Write("> ");
        string option = Console.ReadLine();
        if (option == "1")
        {
            DisplayBanner();
            CreateFacility.CollectInput(Trestlebridge);
        }
        else if (option == "2")
        {
            DisplayBanner();
            PurchaseStock.CollectInput(Trestlebridge);
        }
        else if (option == "3")
        {
            DisplayBanner();
            PurchaseSeed.CollectInput(Trestlebridge);
        }
        else if (option == "4")
        {
            DisplayBanner();
            Console.WriteLine(Trestlebridge);
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Press return key to go back to main menu.");
            Console.ReadLine();
        }
        else if (option == "5")
        {
            DisplayBanner();
            ProcessingOptions.printOptions(Trestlebridge);
        }
        else if (option == "6")
        {
            Console.WriteLine("Today is a great day for farming");
            break;
        }
        else
        {
            Console.WriteLine($"Invalid option: {option}");
        }
    }
}

Start();