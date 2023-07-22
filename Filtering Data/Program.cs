var numbers = Enumerable.Range(1, 10);
var evenNumbers  = numbers.Where(n => n%2 == 0);
foreach(var number in evenNumbers)
    Console.WriteLine(number);

//Can combine projection (Select) and Filtering (Where)
Console.WriteLine("Combination");
var oddNumbers = numbers.Select(x => x*x).Where(y => y%2 == 1);
foreach(var number in oddNumbers)
    Console.WriteLine(number);

//We can even filter different data types!
Console.WriteLine("Different data types");
object[] values = { 1, 1.5, 3, 4.5};    //This contains both ints and doubles
Console.WriteLine("These are the ints: ");
foreach (var obj in values.OfType<int>())   //I create a new collection here, with only the specified types!
    Console.WriteLine(obj);