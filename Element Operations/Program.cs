//In Linq termenology, "element operations" are operations that return a single value
var numbers = new List<int> { 1,2,3 };
Console.WriteLine(numbers.First());
try
{
    Console.WriteLine(numbers.First(x => x > 10));  //Invalid operation exception
}
catch(Exception e)
{
    Console.WriteLine($"{e.Message}");
}

Console.WriteLine(numbers.FirstOrDefault(x => x > 10));    //First element satisfying predicate, or default value of type

Console.WriteLine(numbers.Last());

try
{
    //Expects one element. Always exception when more than one.
    //Expect one or zero with Single() or SingleOrDefault()
    Console.WriteLine(numbers.Single());

}
catch (Exception e)
{
    Console.WriteLine($"{e.Message}");
}
