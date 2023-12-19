//Linq has set operations, as in Set Theory.

using Shared;

string word1 = "helloooo";
string word2 = "help😲";

var distinctLetters = word1.Distinct();

Console.WriteLine();
foreach (var  word in distinctLetters)
{
    Console.WriteLine(word);
}

//Intersections
//Distinct letters in both words
var lettersInBoth = word1.Intersect(word2);

Console.WriteLine();
foreach (var word in distinctLetters)
{
    Console.WriteLine(word);
}

//Union
//Get unique letters to create unique collection
var uniqueletters = word1.Union(word2);

Console.WriteLine();
foreach (var word in uniqueletters)
{
    Console.WriteLine(word);
}

//Except
//All elements in one collection that is not in another collection

var onlyInWordOne = word1.Except(word2);

Console.WriteLine();
foreach (var word in onlyInWordOne)
{
    Console.WriteLine(word);
}