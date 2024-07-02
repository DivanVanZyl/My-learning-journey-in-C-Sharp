using Shared;
using System.Numerics;
using static FibMethods;

Console.WriteLine(FibTabulation(6));
Console.WriteLine(FibTabulation(7));
Console.WriteLine(FibTabulation(8));
Console.WriteLine(FibTabulation(50));


FibTabulation(6);

static class FibMethods
{
    //Brute force solution
    internal static BigInteger FibTabulation(int n)
    {
        var table = new List<int>();   // { n + 1 };
        table.AddRange(Enumerable.Repeat(0, n + 1));    //Fill with zeros
        table[1] = 1; //Seed index 1 with value of 1.

        for (int i = 0; i < n; i++)
        {
            if(i+1 <= n) table[i + 1] += table[i];
            if (i + 2 <= n) table[i + 2] += table[i];
        }
        return table[n];
    }


}