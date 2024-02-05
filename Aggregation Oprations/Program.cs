using System.Drawing;
//Important: Aggregation is defined as a operator that yields a single value from a sequence.

var numbers = Enumerable.Range(0, 10);

//1 2 3 4 5 ...
//Aggrigate performs an operations on a PAIR of elements eg. 1 and 2 from above

//p is for "partial result" 
// p = 1 x = 2 -> 3 (3 is the "partial sum")
// p = 3 x = 3 ... until you run out of elements, and then gives you the result!
Console.WriteLine(numbers.Aggregate((p, x) => p + x));

//How to use seed value like this:
//seed 1 => partial value
//1 1 -> 1
//1 2 -> 2
//2 3 -> 6

Console.WriteLine(numbers.Aggregate(1,(p, x) => p + x));

//Can use other opertaions as well:
Console.WriteLine(numbers.Sum());
Console.WriteLine(numbers.Average());

var words = new[] { "one", "two", "three" };

Console.WriteLine(words.Aggregate("Hello ",(p, x) => p + "," + x));

//Count() is also an aggregation operation!
//Count is dangerous in the sense that you are iterating the entire sequence!
Console.WriteLine("We have " + numbers.Count() + " elements.");

// Recrangle.Union(r1,r2)

var rectangles = new[]
{
    new Rectangle(0,0,20,20),
    new Rectangle(20,20,60,60),
    new Rectangle(80,80,20,20)
};

Console.WriteLine(rectangles.Aggregate(Rectangle.Union));