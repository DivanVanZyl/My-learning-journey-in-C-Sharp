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
                    /*
                     * In C# an int is 4 bytes. This is why, with the pointer incrementation (myPtr++;), the pointers address is incremented by 4:
                     * Pointer addition is a logic and not a numeric operation. Because, otherwise incrementing it by 1 would produce a pointer that is pointing to the middle of an object, which is invalid.
                     */
                    myPtr++;
                    Console.WriteLine($"This is my new memory address: {(int)myPtr}");
                    Console.WriteLine($"The value in my new memory address is: {*myPtr}");
                }
            }
        }
    }
}