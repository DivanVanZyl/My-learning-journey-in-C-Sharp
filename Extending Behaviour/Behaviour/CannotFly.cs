using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extending_Behaviour
{
    internal class CannotFly : IFlyBehaviour
    {
        public void fly()
        {
            Console.WriteLine("cannot fly!");
        }
    }
}
