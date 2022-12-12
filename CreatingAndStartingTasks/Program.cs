// Task is a .NET way of grouping a unit of work together, and telling scheduler that this unit of work can be run on a seperate thread.

internal static class Progam
{
    public static void Write(char c)
    {
        int i = 1000;
        while(i-- > 0)
        {
            Console.Write(c);
        }
    }

    public static void Write(object o)
    {
        int i = 1000;
        while(i --> 0)
        {
            Console.Write(o);
        }
    }

    public static int TextLength(object o)
    {
        Console.WriteLine($"\nTask with id {Task.CurrentId} processing object {o}...");
        return o.ToString().Length;
    }

    public static void Main()
    {
        ////When you start a Task, you have to provide an action. An action can be an annonamous function, existing function or a lambda. 
        ////In other words, you need to tell the Task what it needs to do.
        //Task.Factory.StartNew(() => Write('.'));    //fig. A

        ////Another way, is to explicitly make an instance of the class Task
        //var t = new Task(() => Write('?'));    //fig. B
        //t.Start();
        ////Note: There is a difference between the above!
        ////Fig A Creates and Starts the Task, B only Creates it.

        //Write('-'); //On main thread

        ////Tasks with state
        //Task t = new Task(Write, "Hello");
        //t.Start();
        //Task.Factory.StartNew(Write, 123);

        //Returning values. Eg. a calculation
        //Use generic versions
        string text1 = "testing", text2 = "this";
        var task1 = new Task<int>(TextLength, text1);
        task1.Start();

        Task<int> task2 = Task.Factory.StartNew/*<int>*/(TextLength, text2);

        Console.WriteLine($"Length of '{text1}' is {task1.Result}");
        Console.WriteLine($"Length of '{text2}' is {task2.Result}");

        Console.WriteLine("Main program done.");
        Console.ReadKey();
    }
}