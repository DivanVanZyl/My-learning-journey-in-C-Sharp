https://www.youtube.com/watch?v=DSxjciDUBdw&ab_channel=CODELLIGENT

List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 9 };

//Func<int,bool> oddCheck = x => x % 2 != 0;
/*Action<int> print = x =>
{
    Console.WriteLine(x);
};*/

numbers.Where(x => x % 2 != 0).ToList().ForEach(x => Console.WriteLine(x));

