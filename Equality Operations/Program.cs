var arr1 = new[] { 1,2,3 };
var arr2 = new[] { 1,2,3 };

Console.WriteLine(arr1 == arr2);    //FALSE!
//How to compare by value instead of reference

Console.WriteLine(arr1.SequenceEqual(arr2));

var list1 = new List<int> { 1,2,3 };

Console.WriteLine(list1.SequenceEqual(arr2));   //Also true.