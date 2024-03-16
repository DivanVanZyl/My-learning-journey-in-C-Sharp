using Shared;
using static BestSumMethods;

BestSum(7, [5, 3, 4, 7])!.WriteCollection();

static class BestSumMethods
{
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
                combination.Add(remainder);
                if (shortestCombination is null || combination.Count < shortestCombination.Count)
                {
                    shortestCombination = combination;
                }
            }
        }

        return shortestCombination;
    }
}