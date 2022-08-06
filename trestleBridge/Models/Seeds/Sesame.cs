using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;

namespace trestleBridge.Models.Seeds
{
    public class Sesame : IPlowedSeed, ISeed
    {
        public string Name { get;} = "Sesame";
    }
}
