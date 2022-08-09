using System.Collections;

namespace Demo
{
    public class Demo
    {
        //ref structs cannot implement interfaces, but you can have the Dispose method.
        ref struct Foo
        {
            public void Dispose()
            {
                Console.WriteLine("Disposing Foo");
            }
        }

        //Suppose you want some action in dispose:
        interface IMyDisposable<T> :IDisposable
        {
            void IDisposable.Dispose()
            {
                Console.WriteLine($"Disposing {typeof(T).Name}");
            }
        }
        public class MyClass : IMyDisposable<MyClass>
        {

        }
        interface IScalar<T> : IEnumerable<T>
        {
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                yield return (T)this;
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public class MyOtherClass : IScalar<MyOtherClass>
        {
            public override string ToString()
            {
                return "MyOtherClass";
            }            
        }

        public static void Main()
        {
            //duck typing

            //eg. GetEnumerator() - when a class has this method, foreach can be called, even if the class does not implement IEnumerable<T>
            //eg. Dispose() - you can use IDisposable, but you don't have to. In some cases you can't:
            using (Foo foo = new Foo())
            {

            }

            //Mixins are ways of adding fuctionality to a class. eg. extention methods. 
            //You can have mixin implementations of interfaces (IEnumerable, IDisposable...) that can be added to a class.

            //Because of duck typing:
            using var mc = new MyClass();

            var moc = new MyOtherClass();
            foreach (var x in moc)
                Console.WriteLine(x);
        }
    }
}