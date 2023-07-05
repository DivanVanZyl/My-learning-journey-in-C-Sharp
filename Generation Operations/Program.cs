var strings = Enumerable.Repeat("Hello", 3);
foreach (var s in strings)
    Console.WriteLine(s);

var ints  = Enumerable.Range(1, 10);
foreach (var i in ints)
    Console.WriteLine(i);

var chars = Enumerable.Range('a', 'z' - 'a').Select(c => (char)c);
foreach (var c in chars)
    Console.WriteLine(c);

var myString = Enumerable.Range(1,10).Select(i => new string('x',i));
foreach (var s in myString)
    Console.WriteLine(s);