//These determine if one or more elements in a collection satisfy the predicate
int[] numbers = { 1, 2, 3, 4, 5 };

Console.WriteLine("Are all numbers > 0? " +
    numbers.All(n => n >0));

Console.WriteLine("Is any number < 2? " +
    numbers.Any(n => n < 2));

Console.WriteLine(new int[] { }.Any()); //Can check if a collection is empty like this

Console.WriteLine("Contains 5? " +
    numbers.Contains(5));
