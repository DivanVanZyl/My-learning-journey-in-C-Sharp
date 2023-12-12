using Shared;

var rand = new Random();
var randomvalues = Enumerable.Range(0, 10)
    .Select(_ => rand.Next(10) - 5);

randomvalues.ForEach(v => Console.WriteLine(v));    //This is done by my extension method and not part of Linq itself

var csvString = new Func<IEnumerable<int>, string>(values =>
{
    return string.Join(",", values.Select(v => v.ToString()).ToArray());
});

Console.WriteLine(csvString(randomvalues));

Console.WriteLine(csvString(randomvalues.OrderBy(x => x)));
Console.WriteLine(csvString(randomvalues.OrderByDescending(x => x)));

var people = new List<Person>
        {
            new Person { Name = "Max Payne", Age = 45 },
            new Person { Name = "Mona Sax", Age = 32 },
            new Person { Name = "Vladimir Lem", Age = 50 },
            new Person { Name = "Jim Bravura", Age = 55 },
            new Person { Name = "Vinnie Gognitti", Age = 38 },
            new Person { Name = "Alfred Woden", Age = 60 },
            new Person { Name = "Michelle Payne", Age = 28 },
            new Person { Name = "Alex Balder", Age = 40 },
            new Person { Name = "Nicole Horne", Age = 50 },
            new Person { Name = "Jack Lupino", Age = 36 }
        };

//NOTE that the type of any OrderBy operation is IOrderedEnumerable.
IOrderedEnumerable<Person> sortedPeople = people.OrderBy(p => p.Age);

//This is because linq allows you to sort by sequence.
people.OrderBy(p => p.Name).ThenBy(p => p.Age).ForEach(sp =>  Console.WriteLine(sp.Name + " " + sp.Age));

//Reversing a collection. Very neat for coding challenges. 
string s = "This is a test";
Console.WriteLine(new string(s.Reverse().ToArray()));

//Remember that the string constructor has an overload!
var test = new string(new char[] { 'a','b','c' });
Console.WriteLine(test);