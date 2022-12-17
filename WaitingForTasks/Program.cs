var cts = new CancellationTokenSource();
var token = cts.Token;
var t = new Task(() =>
{
    Console.WriteLine("I take 5 seconds.");
    for(int i = 0; i < 5; i++)
    {
        token.ThrowIfCancellationRequested();
        Thread.Sleep(1000);
    }
    Console.WriteLine("I'm done.";
},token);
t.Start();

Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

//Task.WaitAll(t, t2); //Wait until both of the tasks are finished.
//Task.WaitAny(t, t2); //Wait until either of the tasks are finished. 
//Task.WaitAny(new[] { t, t2 }, 4000); //You can specify a timeout as well.
Task.WaitAll(new[] { t, t2 }, 4000,token); //NOTE: Cancelling on the token, fires and exception.
//Console.ReadKey();
//cts.Cancel(); //Demonstrates the exception. App will crash due to the unhandled exception.

//You have these status flags, that will show you the status of each task!
Console.WriteLine($"Task t status is {t.Status}");
Console.WriteLine($"Task t2 status is {t2.Status}");

Console.WriteLine("Main program done.");
Console.ReadKey();
