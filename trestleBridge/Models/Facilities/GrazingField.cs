using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Actions;
using trestleBridge.Interfaces;

namespace trestleBridge.Models.Facilities
{
    public class GrazingField : IFacility<IGrazing>
    {
        public static string Name { get; set; } = "grazingfield";
        public int _capacity = 3;
        private Guid _id = Guid.NewGuid();
        public int currentCap { get => _animals.Count; }
        private List<IGrazing> _animals = new List<IGrazing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public void AddResource(IGrazing animal, Farm farm)
        {
            if (_capacity - currentCap > 0)
            {
                _animals.Add(animal);
            }
            else
            {
                Console.WriteLine("**** That facililty is not large enough ***** ***Please choose another one * ***");
                ChooseGrazingField.CollectInput(farm, animal);
            }
        }

        public void AddResource(List<IGrazing> animals)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            Dictionary<string, int> animalCount = new Dictionary<string, int>();
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
            output.Append($"Grazing field {shortId} (");
            this._animals.ForEach(a =>
            {
                if (animalCount.ContainsKey(a.Type))
                {
                    animalCount[a.Type] += 1;
                } else
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
