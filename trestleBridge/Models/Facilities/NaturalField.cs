using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Actions;
using trestleBridge.Interfaces;

namespace trestleBridge.Models.Facilities
{
    public class NaturalField  : IFields
    {
        public string Name { get; set; } = "naturalfield";
        public static string Names { get; set; } = "naturalfield";
        private List<ISeed> _seeds = new List<ISeed>();
        private int _capacity { get; } = 10;

        public int currentCap { get => _seeds.Count; }

        public void AddResource(ISeed seed, Farm farm)
        {
            if (_capacity - currentCap > 0)
            {
                _seeds.Add(seed);
            }
            else
            {
                Console.WriteLine("**** That facililty is not large enough ***** ***Please choose another one * ***");
                ChooseNaturalField.CollectInput(farm, seed);
            }
        }
    }
}