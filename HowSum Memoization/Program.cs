using Shared;
using static HowSumMethods;

HowSumMemo(7, [2, 3])!.WriteCollection();
HowSumMemo(7, [5, 3, 4, 7])!.WriteCollection();
HowSumMemo(7, [2, 4])!.WriteCollection();
HowSumMemo(8, [2, 3, 5])!.WriteCollection();
HowSumMemo(300, [7, 14])!.WriteCollection();

public static class HowSumMethods
{
    //time: O(n^m * m)
    //space: O(m)
    public static List<int>? HowSum(int targetSum, List<int> numbers)
    {
        if (targetSum == 0) return [];
        if (targetSum < 0) return null;

        foreach (int num in numbers)
        {
            int remainder = targetSum - num;
            var remainderResult = HowSum(remainder, numbers);
            if (remainderResult is not null)
            {
                remainderResult.Add(num);
                return remainderResult;
            }
        }
        return null;
    }

    //time: O(n*m^2)
    //space: O(m^2)
    public static List<int>? HowSumMemo(int targetSum, List<int> numbers, Dictionary<int,List<int>>? memo = null)
    {
        if(memo is null) memo = new Dictionary<int,List<int>>();
        if (memo.ContainsKey(targetSum)) return memo[targetSum];
        if (targetSum == 0) return [];
        if (targetSum < 0) return null;

        foreach (int num in numbers)
        {
            int remainder = targetSum - num;
            var remainderResult = HowSumMemo(remainder, numbers,memo);
            if (remainderResult is not null)
            {
                remainderResult.Add(num);
                memo[targetSum] = remainderResult;
                return memo[targetSum];
            }
        }
        memo[targetSum] = null;
        return memo[targetSum];
    }
}