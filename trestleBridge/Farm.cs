using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;
using trestleBridge.Models.Facilities;

namespace trestleBridge
{
    public class Farm
    {
        public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
        public List<ChickenHouse> ChickenHouses { get; } = new List<ChickenHouse>();
        public List<DuckHouse> DuckHouses { get; } = new List<DuckHouse>();
        public List<NaturalField> NaturalFields { get; } = new List<NaturalField>();
        public List<PlowedField> PlowedFields { get; } = new List<PlowedField>();


        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */
        public void PurchaseResource<T>(IResource resource, int index)
        {
            Console.WriteLine(typeof(T).ToString());
            switch (typeof(T).ToString())
            {
                case "Cow":
                    GrazingFields[index].AddResource((IGrazing)resource);
                    break;
                default:
                    break;
            }
        }

        public void AddField(string name)
        {
            switch (name)
            {
                case "grazingfield":
                    GrazingFields.Add(new GrazingField());
                    Console.WriteLine("new grazing field added");
                    break;
                case "chickenhouse":
                    ChickenHouses.Add(new ChickenHouse());
                    Console.WriteLine("new chicken house added");
                    break;
                case "duckhouse":
                    DuckHouses.Add(new DuckHouse());
                    Console.WriteLine("new duck house added");
                    break;
                case "naturalfield":
                    NaturalFields.Add(new NaturalField());
                    Console.WriteLine("natural field added");
                    break;
                case "plowedfield":
                    PlowedFields.Add(new PlowedField());
                    Console.WriteLine("plowed field added");
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(gf => report.Append(gf));

            return report.ToString();
        }
    }
}
