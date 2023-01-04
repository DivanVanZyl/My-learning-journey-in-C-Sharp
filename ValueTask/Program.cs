namespace ValueTask
{
    //Chrnology
    //.NET Framework 4 introduced Task
    //Task and Task<T> used extensively with C# 5 async/await
    //ValueTask and ValueTask<T> introduced to help improce async performance with decreased allocation overhead.
    //
    //What is a Task -> It is a "promise" that a task will complete.
    //Task will complete, then the operation completes
    //Tasks can be syncronously (part of initiating operation) or, asyncronously (will complete at some point after you're holding a Task object)
    //
    //Since ops might complete asynctonously, you can:
    // 1. Block and wait on the results (defeats the purpose of asyncrony)
    // 2. Supply a callback (ContinueWith)
    //
    // In .NET Framework 4.5/C# 5, Tasks can simply be awaited:
    //var result = await SomeAsyncOp();
    //UserResult(result);
    //Easier to consume: correctly handles both sync and async completion!
    //Task is very flexible:
    // - can wait multuple time, by any number of consumers concurrently
    // - Store it in a dictionary for consumers to await in the future
    // - Task combinators (eg. "when any")
    //
    //NOTE: When many tasks are created, we get additional GC pressure because Task is a class, allocated on the heap.
    //.NET Core 2.0 introduced a new type: ValueTask<TResult>
    //A *struct* capable of wrapping either a TResult or Task<TResult>
    //Essentially, only on heap if completed asyncronously.
    //
    //Important, ValueTask/ValueTask<T> are good choices when:
    //You expect Api consumers to only await then directly, and
    //You want to avoid allocation-related overhead; and
    //Either you expect sync completion to be a common case or you're able to effectively pool objects for the use of asynchronous completion.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("No demo here.");
        }
    }
}