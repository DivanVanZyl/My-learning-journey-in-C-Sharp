
//In this form, you will run the program, but you will be unaware of any exceptoin. So, how do we keep track of this?
/*Task.Factory.StartNew(() =>
{
    throw new InvalidOperationException();
});
*/
//In both the below cases, I want to have some message.
var t = Task.Factory.StartNew(() =>
{
    throw new InvalidOperationException("Can't do this!") { Source = "t" };
});
var t2 = Task.Factory.StartNew(() =>
{
    throw new AccessViolationException("Can't access this!") { Source = "t2" };
});

try
{
    Task.WaitAll(t, t2);
}
catch (AggregateException ae)
{
    foreach (var e in ae.InnerExceptions)
        Console.WriteLine($"Exception {e.GetType()} from {e.Source}");
}

Console.WriteLine("Main program done.");
Console.ReadKey();
