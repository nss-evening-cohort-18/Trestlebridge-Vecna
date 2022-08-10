using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Actions;
using trestleBridge.Interfaces;
using trestleBridge.Models.Animals;

namespace trestleBridge.Models.Facilities
{
    public class ChickenHouse : IFacility<Chicken>, IMeatProducing
    {
        public string FieldName { get; } = "chicken house";
        public static string Name { get; set; } = "chickenhouse";
        public int currentCap { get => _chickens.Count; }

        public int _capacity { get; } = 10;
        public List<Chicken> _chickens = new List<Chicken>();
        // can only hold 15 chickens max

        public void AddResource(Chicken animal, Farm farm)
        {
            if (_capacity - currentCap > 0)
            {
                _chickens.Add(animal);
            }
            else
            {
               Console.WriteLine("**** That facililty is not large enough ***** ***Please choose another one * ***");
               ChooseChickenHouse.CollectInput(farm, animal);
            }
        }
        public override string ToString()
        {
            Dictionary<string, int> animalCount = new Dictionary<string, int>();
            StringBuilder output = new StringBuilder();
            output.Append($"Chicken House (");
            this._chickens.ForEach(a =>
            {
                if (animalCount.ContainsKey(a.Type))
                {
                    animalCount[a.Type] += 1;
                }
                else
                {
                    animalCount[a.Type] = 1;
                }
            });
            foreach (KeyValuePair<string, int> kvp in animalCount.OrderByDescending(x => x.Value))
            {
                output.Append($" {kvp.Value.ToString()} {kvp.Key}s, ");
            }
            output.Remove(output.Length - 2, 1);
            output.Append(")");
            return output.ToString();
        }
    }
}
