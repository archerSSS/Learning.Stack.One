using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    public class Sphere
    {
        protected int diameter;

        public Sphere(int d)
        {
            diameter = d;
        }

        public virtual int GetDiameter()
        {
            return diameter;
        }
    }
}
