/*using System.Collections;

var list = new ArrayList();
list.Add(1);
list.Add(2);
list.Add(3);

Console.WriteLine(list.Cast<int>().Average());*/

//To enumerate
var numbers = Enumerable.Range(1, 10);
var list = numbers.ToList(); //Create some collection
var dict = numbers.ToDictionary(i  => (double)i/10, i => i%2 == 0);

foreach (var item in dict)
    Console.WriteLine(item);

IEnumerable<int> arr = new[] {1,2,3};    //This is by definition enumerable, but you lose the operations that you would have on an array.
//For example, you can't do arr.Length anymore! As it's not an array anymore!

var arr2 = new[] {1,2,3};
var myCollection = arr2.AsEnumerable(); //If you want an IEnumerable of <T> that you want to perform linq operations on.