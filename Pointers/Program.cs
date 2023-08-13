namespace Pointers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int i = 5;
                int *myPtr = & i;

                Console.WriteLine($"This is my memory address: {(int)myPtr}");
                Console.WriteLine($"The value in my memory address is: {*myPtr}");

                Console.WriteLine($"Lets see what is at another memory address...");
                for(int cnt = 0;cnt < 5;cnt++)
                {
                    myPtr += 1;
                    Console.WriteLine($"This is my new memory address: {(int)myPtr}");
                    Console.WriteLine($"The value in my new memory address is: {*myPtr}");
                }
            }
        }
    }
}