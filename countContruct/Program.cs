using Shared;
using static CountConstructMethods;

//Console.WriteLine(CountConstruct("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd" }));  //true
//Console.WriteLine(CountConstruct("skateboard", new List<string> { "bo", "rd", "ate", "t", "ska", "sk", "boar " })); //false
//Console.WriteLine(CountConstruct("enterapotentpot", new List<string> { "a", "p", "ent", "enter", "ot", "o", "t" })); //true
//Console.WriteLine(CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }));  //true

Console.WriteLine(CountConstructMemo("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd" }, new Dictionary<string, int>()));  //true
Console.WriteLine(CountConstructMemo("skateboard", new List<string> { "bo", "rd", "ate", "t", "ska", "sk", "boar " }, new Dictionary<string, int>())); //false
Console.WriteLine(CountConstructMemo("enterapotentpot", new List<string> { "a", "p", "ent", "enter", "ot", "o", "t" }, new Dictionary<string, int>())); //true
Console.WriteLine(CountConstructMemo("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, new Dictionary<string, int>()));  //true

static class CountConstructMethods
{
    //Brute force solution
    internal static int CountConstruct(string target, List<string>? wordBank = null)
    {
        if (target == "") return 1;

        int totalCount = 0;

        foreach (var word in wordBank)
        {
            if (target.StartsWith(word))
            {
                string suffix = target.Substring(word.Length);
                int numWaysForTheRest = CountConstruct(suffix, wordBank);
                totalCount += numWaysForTheRest;
            }
        }
        return totalCount;
    }

    internal static int CountConstructMemo(string target, List<string> wordBank, Dictionary<string, int> memo)
    {
        if (memo.ContainsKey(target)) return memo[target];
        
        if (target == "") return 1;

        int totalCount = 0;

        foreach (var word in wordBank)
        {
            if (target.StartsWith(word))
            {
                string suffix = target.Substring(word.Length);
                int numWaysForTheRest = CountConstructMemo(suffix, wordBank, memo);
                totalCount += numWaysForTheRest;
            }
        }
        memo[target] = totalCount;
        return totalCount;
    }
}