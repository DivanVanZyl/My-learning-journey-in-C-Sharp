using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extending_Behaviour
{
    internal class Duck
    {
        //THis method is the same accross all ducks
        public string getTypeOfAnimal()
        {
            return "I'm a duck.";
        }

        public void fly()
        {
            Console.WriteLine("flap flap fly like a normal duck");
        }
    }
}
