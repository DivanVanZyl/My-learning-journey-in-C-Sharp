IGridTraveler gridTraveler = new MemGridTraveler();

Console.WriteLine(gridTraveler.Run(1,1));
Console.WriteLine(gridTraveler.Run(2,3));
Console.WriteLine(gridTraveler.Run(3,2));
Console.WriteLine(gridTraveler.Run(3,3));
Console.WriteLine(gridTraveler.Run(18,18));

public class GridTraveler : IGridTraveler
{
    public ulong Run(int m, int n)
    {
        if (m == 1 && n == 1) return 1;
        if (m == 0 || n == 0) return 0;
        return Run(m - 1, n) + Run(m,n - 1);
    }    
}

public class MemGridTraveler : IGridTraveler
{
    private Dictionary<string, ulong> _memo = new Dictionary<string, ulong>();
    public ulong Run(int m, int n)
    {
        string key = m + "," + n;
        // Are the arguments in the memo?
        if (_memo.ContainsKey(key)) return _memo[key];
        if (m == 1 && n == 1) return 1;
        if (m == 0 || n == 0) return 0;

        _memo[key] = Run(m - 1, n) + Run(m, n - 1);
        return _memo[key];
    }
}

public interface IGridTraveler
{
    ulong Run(int m, int n);
}
