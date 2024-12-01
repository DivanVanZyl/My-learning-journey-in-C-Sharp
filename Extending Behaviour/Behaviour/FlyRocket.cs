using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extending_Behaviour.Behaviour
{
    internal class FlyRocket : IFlyBehaviour
    {
        public void fly()
        {
            Console.WriteLine("Wooosh!");
        }
    }
}
