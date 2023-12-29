using Shared;
var intTypes  = new[] { typeof(int), typeof(short) };
var fpTypes  = new[] { typeof(float), typeof(double) };

var collection = intTypes.Concat(fpTypes).Prepend(typeof(bool));

collection.ForEach(x => Console.WriteLine(x));