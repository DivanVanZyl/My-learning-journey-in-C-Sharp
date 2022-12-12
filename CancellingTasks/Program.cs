var cts = new CancellationTokenSource();
var token = cts.Token;

//If you want to be notified when a task is cancelled
token.Register(() =>
{
    Console.WriteLine("Cancelation has been requested.");
});

var t = new Task(() =>
{
    int i = 0;
    while (true)
    {
        /*if (token.IsCancellationRequested)
        {
            //break;
            //throw new OperationCanceledException();
        }
        else*/
        token.ThrowIfCancellationRequested();
        Console.WriteLine($"{i++}\t");
    }
}, token);
t.Start();

//Another way to monitor that someone wants to cancel the task
Task.Factory.StartNew(() =>
{
    token.WaitHandle.WaitOne();
    Console.WriteLine("Wait handle released, cancelation was requested.");
});

Console.ReadKey();
cts.Cancel();

Console.WriteLine("Main program done.");