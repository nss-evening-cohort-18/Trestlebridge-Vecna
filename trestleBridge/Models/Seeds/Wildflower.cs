using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Interfaces;

namespace trestleBridge.Models.Seeds
{
    public class Wildflower : INaturalSeed, ISeed
    {
        public string Name { get;} = "Wildflower";
    }
}
