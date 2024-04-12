using Shared;
using static CanConstructMethods;

Console.WriteLine(CanConstructMemo("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd" }, new Dictionary<string, bool>()));  //true
Console.WriteLine(CanConstructMemo("skateboard", new List<string> { "bo", "rd", "ate", "t", "ska", "sk", "boar " }, new Dictionary<string, bool>())); //false
Console.WriteLine(CanConstructMemo("enterapotentpot", new List<string> { "a", "p", "ent", "enter", "ot", "o", "t" }, new Dictionary<string, bool>())); //true
Console.WriteLine(CanConstructMemo("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, new Dictionary<string, bool>()));  //true

static class CanConstructMethods
{
    //Brute force solution
    internal static bool CanConstruct(string target, List<string>? wordBank = null)
    {
        if (target == "") return true;

        foreach (var word in wordBank)
        {
            if (target.StartsWith(word))
            {
                string suffix = target.Substring(word.Length);
                if (CanConstruct(suffix, wordBank))
                {
                    return true;
                }
            }
        }
        return false;
    }

    internal static bool CanConstructMemo(string target, List<string> wordBank, Dictionary<string, bool> memo)
    {
        if (memo.ContainsKey(target)) return memo[target];
        if (target == "") return true;

        foreach (var word in wordBank)
        {
            if (target.StartsWith(word))
            {
                string suffix = target.Substring(word.Length);
                if (CanConstructMemo(suffix, wordBank, memo))
                {
                    memo[target] = true;
                    return true;
                }
            }
        }
        memo[target] = false;
        return false;
    }
}