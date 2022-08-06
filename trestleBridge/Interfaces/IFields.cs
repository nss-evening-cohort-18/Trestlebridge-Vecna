using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trestleBridge.Interfaces
{
    public interface IFields
    {
        int currentCap { get; }
        string Name { get; }

        void AddResource(ISeed seed, Farm farm);
    }
}
