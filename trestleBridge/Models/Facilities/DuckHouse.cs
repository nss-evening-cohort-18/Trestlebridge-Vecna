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
        private int _capacity { get; } = 12;

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
    }
}