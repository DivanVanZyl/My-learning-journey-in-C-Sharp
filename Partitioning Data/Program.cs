using Shared;
//Given a stream of data, you might want to ignore some of the data.

var numbers = new[] { 3,3,2,2,1,1,2,2,3,3 };


numbers.Skip(2).ForEach(n => Console.WriteLine(n));
Console.WriteLine("-----------------------------------------------");

numbers.Skip(2).Take(6).ForEach(n => Console.WriteLine(n));
Console.WriteLine("-----------------------------------------------");

//Note that it only affects the skipping from the start of the list!
//Similar to "exiting" a while loop
numbers.SkipWhile(i => i == 3).ForEach(n => Console.WriteLine(n));
Console.WriteLine("-----------------------------------------------");

//This will stop processign the sequence when the condition is false.
numbers.TakeWhile(i => i > 1).ForEach(n => Console.WriteLine(n));
Console.WriteLine("-----------------------------------------------");