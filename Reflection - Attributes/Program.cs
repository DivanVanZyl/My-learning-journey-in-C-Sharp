using System;

namespace Reflection
{
    public class RepeatAttribute : Attribute
    {
        //Specify how many times we want to repeat an operation.
        public int Times { get; }

        public RepeatAttribute(int times)
        {
            Times = times;
        }
    }

    public class AttributeDemo
    {
        [Repeat(3)]
        public void SomeMethod()
        {

        }

        public static void Main(string[] args)
        {
            var sm = typeof(AttributeDemo).GetMethod("SomeMethod"); //Determanistically get some method
            //Go through all of the arrtibutes for this method
            foreach(var att in sm.GetCustomAttributes(true))
            {
                Console.WriteLine("Found an arrtibute: " + att.GetType());
                if(att is RepeatAttribute ra)
                {
                    Console.WriteLine($"Need to repeat {ra.Times} times");
                }
            }
            Console.ReadLine();
            //NOTE: Attributes do not add behaviour, they only add metadata.
        }
    }
}