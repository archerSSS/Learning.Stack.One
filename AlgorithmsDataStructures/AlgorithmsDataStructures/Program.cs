using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program
    {
        public static void Main(String[] args)
        {
            Sphere s1 = new Sphere(1);
            Sphere s2 = new SphereGreen(2);

            Console.WriteLine(s2.GetDiameter());


            
            Console.ReadLine();
        }
    }
}
