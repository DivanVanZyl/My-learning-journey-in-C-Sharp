using Shared;
using static BestSumMethods;

BestSum(7, [5, 3, 4, 7])!.WriteCollection();
BestSum(8, [2, 3, 5])!.WriteCollection();
BestSum(8, [1, 4, 5])!.WriteCollection();
BestSum(100, [1, 2, 5, 25])!.WriteCollection();

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
}