using Shared;

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

//Note that the below is a Linq-specific grouping (IGrouping)
IEnumerable<IGrouping<string,Person>> byName = people.GroupBy(p => p.Name);
//byName.ForEach(p => Console.WriteLine(p.Key + p.ToList()[1]));

//Create two groups, one with key of > 30 and another of =< 30
people.GroupBy(p => p.Age > 30);

//When you don't care about the entire object, but rather specific fields
var byAgename = people.GroupBy(p => p.Age, p => p.Name);    //Second param is what is acually kept

foreach (var group in byAgename)
{
    Console.WriteLine(group);
    group.ForEach(p => Console.WriteLine(p));
}