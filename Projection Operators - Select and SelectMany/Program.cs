Console.WriteLine("Simple example with int");
var numbers = Enumerable.Range(1, 4);   //Get numbers 1 to 4
var squares = numbers.Select(x => x*x);  //Square each number
foreach (var square in squares)
    Console.WriteLine(square);

Console.WriteLine("Working with text");
//Can work with text as well
string sentence = "This is a sentence";
var wordLengths = sentence.Split().Select(w => w.Length);
foreach (var word in wordLengths)
    Console.WriteLine(word);

Console.WriteLine("Annonamous expression");
var wordsWithLength = sentence.Split()
    .Select(w => new { Word = w, Size = w.Length }); //Make new annonamous structure
foreach (var word in wordsWithLength)
    Console.WriteLine(word);

//Anoter example, this creates random numbers
Console.WriteLine("Random numbers");
Random rand = new Random();
var randomNumbers = Enumerable.Range(1, 10).Select(_ => rand.Next(10)); //The _ makes it clear that we don't care about what specifically the output is. Select does not have to give the input value in it's output, it can have anything in it's output.
foreach (var number in randomNumbers)
    Console.WriteLine(number);

Console.WriteLine("SelectMany");    //This "Flattens a collection
var sequences = new[] { "red,green,blue", "orange", "while,pink" };
var allWords = sequences.SelectMany(s => s.Split(','));
foreach (var word in allWords)
    Console.WriteLine(word);

Console.WriteLine("Cross Product: Cartesian product of two collections");
string[] objects = { "house", "car", "bicycle" };
string[] colors = { "red", "green", "gray" };

//To get all combinations of these, you could use a nested for loop (noob way!)
//But you can also it using linq as well as selectMany. SelectMany has a special overload:
var pairs = colors.SelectMany(_ => objects, 
    (c, o) => $"{c} {o}");
foreach (var pair in pairs)
    Console.WriteLine(pair);

//Of course it could be anything other than string as well.