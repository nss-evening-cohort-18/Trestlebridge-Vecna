using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Actions;
using trestleBridge.Models.Animals;

namespace trestleBridge.Models.Facilities
{
    public class ChickenHouse
    {
        public static string Name { get; set; } = "chickenhouse";
        public int currentCap { get => _chickens.Count; }

        private int _capacity { get; } = 15;
        private List<Chicken> _chickens = new List<Chicken>();
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
    }
}
