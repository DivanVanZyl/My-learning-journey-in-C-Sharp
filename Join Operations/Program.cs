using Shared;

//Join
var people = new Employee[]
{
    new Employee("Divan", "divan@mail.com"),
    new Employee("John", "john@mail.com"),
    new Employee("Doe", "doe@mail.com")
};

var records = new Record[]
{
    new Record("divan@mail.com","divansskype"),
    new Record("divan@mail.com","divansotherskype"),
    new Record("divan@mail.com","divansskype1234")
};

var query = people.Join(records,
    x => x.Email,   //Match on there two records
    y => y.Mail,
    (person, record) => new { Name = person.Name, SkypeId = record.SkypeId });   //Specify lambda to create return object. Here we create a new annonamous object.

query.ForEach(x => Console.WriteLine(x));

//Group Join
//Instead of taking single records, we do a grouping.
var grouping = people.GroupJoin(
    records,
    x => x.Email,
    y => y.Mail,
    (person, recs) => new
    {
        Name = person.Name,
        SkypeIds = recs.Select(r => r.SkypeId).ToArray(),   //Grouping happens here!
    });

//Each of the people, has an array of their SkypeIds!
grouping.ForEach(x => Console.WriteLine(x));