namespace Async_Factory_Method
{
    using System.Threading.Tasks;
    using static System.Console;

    /*Asyncronous invocation cannot happen everywhere: 
     * Asyncronous invocation can happen in methods, but it cannot happen in constructors
     * But sometimes, you want to do async initialisation.
     * Simplest way, is to use a factory method that does the async call for you.
     */

    public class Foo
    {
        //CANNOT await in constructor:
        //public Foo()
        //{
        //  Task.Delay(1000);   //Cannot do this.
        //}

        //Introduce async work as part of the init. process.
        //Drawback of this, is that you have to remember to call this each time, after the contructor.
        //See ex. 1 
        /*public async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }*/

        //Better method, make constructor and "initAsync private
        private Foo()
        {
            //something in here
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        //Make factory method. This is where you would construct the object. Check ex. 2 in Main method of Demo class.
        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }

    public class Demo
    {
        static async void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /*//ex 1 begin
            var foo = new Foo();
            await foo.InitAsync();
            //ex 1 end (not best option)*/


            //ex 2 begin
            var x = await Foo.CreateAsync();
            //ex 2 end
        }
    }
}