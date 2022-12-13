var planned = new CancellationTokenSource();
var preventative = new CancellationTokenSource();
var emergency = new CancellationTokenSource();

//We can can specify a token that reacts to any of those 3 tokens being triggered.
//This is a linked token source. In this example, if any one of planned, preventative or emergency tokens are called, paranoid will be called.
var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
    planned.Token, preventative.Token, emergency.Token);

Task.Factory.StartNew(() =>
{
    int i = 0;
    while(true)
    {
        paranoid.Token.ThrowIfCancellationRequested();
        Console.WriteLine($"{i++}\t");
        Thread.Sleep(1000);
    }
}, paranoid.Token);

Console.ReadKey();
emergency.Cancel();

Console.WriteLine("Main program done.");
