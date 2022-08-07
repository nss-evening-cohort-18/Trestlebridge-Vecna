using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Actions;
using trestleBridge.Models.Animals;

namespace trestleBridge.Models.Facilities
{
    public class DuckHouse
    {
        public static string Name { get; set; } = "duckhouse";

        private List<Duck> _ducks = new List<Duck>();
        public int _capacity { get; } = 12;

        public int currentCap { get => _ducks.Count; }

        public void AddResource(Duck animal, Farm farm)
        {
            if (_capacity - currentCap > 0)
            {
                _ducks.Add(animal);
            }
            else
            {
                Console.WriteLine("**** That facililty is not large enough ***** ***Please choose another one * ***");
                ChooseDuckHouse.CollectInput(farm, animal);
            }
        }
        public override string ToString()
        {
            Dictionary<string, int> animalCount = new Dictionary<string, int>();
            StringBuilder output = new StringBuilder();
            output.Append($"Duck House (");
            this._ducks.ForEach(a =>
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