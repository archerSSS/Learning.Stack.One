using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    public class SphereGreen : Sphere
    {
        
        public SphereGreen(int d) : base(d)
        {
        }

        public override int GetDiameter()
        {
            return diameter + 100;
        }
    }
}
