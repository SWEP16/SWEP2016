using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.Test;

namespace model
{
    class Program
    {
        static void Main(string[] args) {
            ModelTestSuite modelTestSuide = new ModelTestSuite();
            if (modelTestSuide.test()) {
                Console.WriteLine("Alle Tests bestanden!");
            }

            Console.ReadLine();
        }
    }
}
