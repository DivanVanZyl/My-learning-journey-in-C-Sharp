//MemCanSum canSum = new MemCanSum();
Console.WriteLine(MemCanSum.Run(7, [2, 3],null));
Console.WriteLine(MemCanSum.Run(7, [5, 3, 4, 7], null));
Console.WriteLine(MemCanSum.Run(7, [2, 4], null));
Console.WriteLine(MemCanSum.Run(8, [2, 3, 5], null));
Console.WriteLine(MemCanSum.Run(300, [7, 14], null));


//O(n^m) time
//O(m) space
public class CanSum()
{
    public bool Run(int target, List<int> numbers)
    {
        if (target == 0) return true;
        if (target < 0) return false;

        foreach (int num in numbers)
        {
            if (Run(target - num, numbers)) return true;
        }
        return false;
    }
}

//O(m*n) time
//O(m) space
public class MemCanSum()
{
    public static bool Run(int target, List<int> numbers, Dictionary<int, bool>? memo)
    {
        //Base cases
        if (memo is null) memo = new Dictionary<int, bool>();
        if (memo.ContainsKey(target)) return memo[target];
        if (target == 0) return true;
        if (target < 0) return false;

        //Recursive calls
        foreach (int num in numbers)
        {
            if (Run(target - num, numbers, memo))
            {
                memo[target] = true;
                return true;
            }
        }
        memo[target] = false;
        return false;
    }
}