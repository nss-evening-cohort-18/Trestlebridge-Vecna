using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trestleBridge.Interfaces
{
    public interface IGrazing
    {
        double GrassPerDay { get; set; }
        string Type { get; }
        void Graze();
    }
}
