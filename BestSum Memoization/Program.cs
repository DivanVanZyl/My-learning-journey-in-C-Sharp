using Shared;
using static BestSumMethods;

BestSumMemo(7, [5, 3, 4, 7])!.WriteCollection();
BestSumMemo(8, [2, 3, 5])!.WriteCollection();
BestSumMemo(8, [1, 4, 5])!.WriteCollection();
BestSumMemo(100, [1, 2, 5, 25])!.WriteCollection();

static class BestSumMethods
{
    //m = target sum
    //n = numbers.length

    //Brute force tree 
    //time O(n^m * m)
    //space O(m^2)
    internal static List<int>? BestSum(int targetSum, List<int> numbers)
    {
        if (targetSum == 0) return [];
        if (targetSum < 0) return null;

        //Variable to track length of combinations
        List<int>? shortestCombination = null;

        foreach (var num in numbers)
        {
            int remainder = targetSum - num;
            var remainderCombination = BestSum(remainder, numbers);
            if (remainderCombination is not null)
            {
                var combination = new List<int>(remainderCombination);
                combination.Add(num);
                if (shortestCombination is null || combination.Count < shortestCombination.Count)
                {
                    shortestCombination = combination;
                }
            }
        }

        return shortestCombination;
    }

    //Memoized tree 
    //time O(m^2*n )
    //space O(m^2)
    internal static List<int>? BestSumMemo(int targetSum, List<int> numbers, Dictionary<int, List<int>?>? memo = null)
    {
        if (targetSum == 0) return [];
        if (targetSum < 0) return null;
        if (memo is not null && memo.ContainsKey(targetSum))
        {
            return memo[targetSum];
        }

        //Variable to track length of combinations
        List<int>? shortestCombination = null;

        foreach (var num in numbers)
        {
            int remainder = targetSum - num;
            var remainderCombination = BestSumMemo(remainder, numbers, memo);
            if(memo is null)
            {
                memo = new Dictionary<int, List<int>?> { { remainder, remainderCombination } };
            }
            else if(!memo.ContainsKey(remainder))
            {
                memo.Add(remainder,remainderCombination);
            }
            if (remainderCombination is not null)
            {
                var combination = new List<int>(remainderCombination);
                combination.Add(num);
                if (shortestCombination is null || combination.Count < shortestCombination.Count)
                {
                    shortestCombination = combination;
                }
            }
        }

        return shortestCombination;
    }
}