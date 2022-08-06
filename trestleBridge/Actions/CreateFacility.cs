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
            Console.WriteLine ("4. chicken house");
            Console.WriteLine ("5. duck house");
            Console.WriteLine ("Choose what you want to create");
            Console.Write ("> ");
            string input = Console.ReadLine ();
            switch (Int32.Parse(input))
            {
                case 1:
                    farm.AddField(GrazingField.Name);
                    break;
                case 2:
                    farm.AddField(PlowedField.Name);
                    break;
                case 3:
                    farm.AddField(NaturalField.Name);
                    break;
                case 4:
                    farm.AddField(ChickenHouse.Name);
                    break;
                case 5:
                    farm.AddField(DuckHouse.Name);
                    break;
                default:
                    break;
            }
        }
    }
}

