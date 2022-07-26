//Extention methods and tuples, a nice combonation, can make for some clean syntax.

static class Extentions
{
    public static DateTime dmy(this (int day, int month, int year) when)
    {
        return new (when.year, when.month, when.day);
    }

    /// <summary>
    /// Merge two lists via 'AddRange'
    /// </summary>
    /// <typeparam name="T">Type of list</typeparam>
    /// <param name="lists">tuple of lists to merge</param>
    /// <returns></returns>
    public static List<T> merge<T>(this (IList<T> first, IList<T> second) lists)
    {
        var result = new List<T>();
        result.AddRange(lists.first);
        result.AddRange(lists.second);
        return result;
    }

    public static string AsSingleString<T>(this List<T> list)
    {
        string s = "";
        foreach (T item in list)
            s += item;
        return s;

    }
}

public class Demo
{
    public static void Main()
    {
        //Instead of this: new DateTime(2001, 5, 2);
        //We can do this:
        var when = (2, 5, 2001).dmy();
        Console.WriteLine(when);

        //Merge list getting a new instance
        var list1 = new List<int> { 1,2,3,4 };
        var list2 = new List<int> { 5,6,7,8};
        var merged = (list1, list2).merge();

        Console.WriteLine(merged.AsSingleString());

        Console.ReadKey();
    }

}
