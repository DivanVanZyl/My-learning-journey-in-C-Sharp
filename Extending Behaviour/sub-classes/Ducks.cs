using Extending_Behaviour.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extending_Behaviour
{
    internal class RubberDuckSimpleExample : Duck, IQuackable, IFlyable
    {
        public void fly()
        {
            Console.WriteLine("cannot fly");
        }

        public void quack()
        {
            Console.WriteLine("Squieeck!");
        }
    }

    internal class RubberDuckEncapsulatedBehavioursExample : Duck, IFlyable
    {
        IFlyBehaviour _flyBehaviour;

        public RubberDuckEncapsulatedBehavioursExample()
        {
            _flyBehaviour = new CannotFly();
        }

        public void fly()
        {   
            _flyBehaviour.fly();
        }

        public void setFlyBehaviour(IFlyBehaviour flyBehaviour) //With this, we can define the fly behaviour at runtime!
        {
            _flyBehaviour = flyBehaviour;
        }

    }
}
