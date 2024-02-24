/*NOTE: StringBuilder is SEALED. Therefore, we cannot inherit from it.*/
using System.Text;

namespace CustomStringBuilder
{
    internal class Program
    {
        public class CodeBuilder
        {
            private StringBuilder builder = new StringBuilder();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
