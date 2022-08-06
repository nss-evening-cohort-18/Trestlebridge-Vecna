using System;
using trestleBridge.Models.Facilities;

namespace trestleBridge.Actions
{
    public class CreateFacility
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine ("1. Grazing field");
            Console.WriteLine ("2. Plowed field");
            Console.WriteLine ("3. Natural field");
            Console.WriteLine("4. chicken house");
            Console.WriteLine("5. duck house");
            Console.WriteLine ("Choose what you want to create");
            Console.Write ("> ");
            string input = Console.ReadLine ();
            switch (Int32.Parse(input))
            {
                case 1:
                    farm.AddGrazingField(new GrazingField());
                    break;
                case 2: 
                   
                default:
                    break;
            }
        }
    }
}

