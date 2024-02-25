using System.Numerics;

Fib fib = new Fib();
MemFib memFib = new MemFib();

Console.WriteLine(memFib.Run(1024));
public class Fib
{
    //O(n^2)
    public int Run(int n)
    {
        if(n ==  0)
            return 0;
        if(n <= 2)
            return 1;

        return Run(n - 1) + Run(n-2);
    }
}

//Fib with memoization
public class MemFib
{
    private Dictionary<int,BigInteger> memo = new Dictionary<int, BigInteger>();
    //O(n)
    public BigInteger Run(int n)
    {
        ulong x;
        if(memo.ContainsKey(n))
            return memo[n];
        if (n == 0)
            return 0;
        if (n <= 2)
            return 1;

        memo.Add(n,Run(n - 1) + Run(n - 2));
        return memo[n];
    }
}
