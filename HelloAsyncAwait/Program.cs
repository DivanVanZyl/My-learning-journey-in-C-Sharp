namespace program
{
    public static class Program
    {
        static async void Main(string[] args)
        {
            var worker = new Worker();
            Console.WriteLine("Beginning of main program.");

            await worker.DoSomeWork();

            Console.WriteLine("End of main program.");
            Console.ReadKey();
            Console.WriteLine("Main program terminated.");

        }

    }
    internal class Worker
    {
        public async Task DoSomeWork()
        {
            Console.WriteLine("Work started");
            await Task.Delay(5000);
            Console.WriteLine("Work ended");
        }
    }
}

