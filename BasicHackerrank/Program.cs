using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        int[] values = new int[t];

        for (int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            values[a0] = n;
        }

        for (int i = 0; i < t; i++)
        {
            Console.WriteLine(
                Enumerable.Range(1, values[i])
                    .Where(x => ((x % 3 == 0) || (x % 5 == 0) && x != values[i]))
                    .Sum()
            );
        }

    }
}
