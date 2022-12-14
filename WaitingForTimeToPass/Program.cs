var t1 = new Task(() =>
{
    //Note that sleep does not only pause execution,
    //but also tells the scheduler that we don't need that processing time anymore.
    //The processor can execute another thread in that time.
    Thread.Sleep(1000);
});

var t2 = new Task(() =>
{
    //SpinWait also pauses execution. But, you don't give up that execution time.
    //You will waste execution cycles, but you are not giving up your turn, thus AVAOIDING CONTEXT SWITCHES
    //SpinWait.SpinUntil();
});

//Bomb disarming game to illustrate the timed wait.
var cts = new CancellationTokenSource();
var token = cts.Token;
int seconds = 5;
var t3 = new Task(() =>
{
    Console.WriteLine($"Press any key to disarm. You have{seconds} seconds.");
    bool cancelled = token.WaitHandle.WaitOne(seconds * 1000);  //The boolean return value of the WaitOne method, tells us if the task was cancelled.
    Console.WriteLine(cancelled ? "Disarmed." : "Boom");
});
t3.Start();
Console.ReadKey();
cts.Cancel();

Console.WriteLine("Main program done.");
Console.ReadKey();