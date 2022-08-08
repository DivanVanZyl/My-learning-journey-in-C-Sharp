using System;
using System.Diagnostics;
using System.Threading;

namespace disp
{
    public class MyClass : IDisposable
    {
        public MyClass()
        {
            Console.WriteLine("Hello");
        }
        public void Dispose()
        {
            Console.WriteLine("Goodbye");
        }
    }
    public class Disposable : IDisposable
    {
        private readonly Action end;
        private Disposable (Action start, Action end)
        {
            this.end = end;
            start();
        }
        public void Dispose()
        {
            end();
        }
        public static Disposable Create(Action start, Action end)
        {
            return new Disposable (start, end);
        }
    }
    public class Program
    {
        public static void Main()
        {
            //Simple utilisation of IDisposable
            using (var mc = new MyClass())
            {

            }
            
            //Wrapped in Disposable class
            var st = new Stopwatch();
            using (Disposable.Create(
                () => st.Start(),
                () => st.Stop()
                ))
            {
                Console.WriteLine("...something here");
                Thread.Sleep(1000);
                Console.WriteLine(st.ElapsedMilliseconds);
            }
        }
    }
}

