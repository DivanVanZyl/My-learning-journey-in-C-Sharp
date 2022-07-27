// How to do dynamic programming with ExpandoObject
// An object whose members can be dynamically added and removed at run

using System.Dynamic;

dynamic person = new ExpandoObject();
person.Name = "Divan";
person.Age = 29;

Console.WriteLine(person.GetType());
Console.WriteLine($"{person.Name.GetType()}:  {person.Name}");
Console.WriteLine($"{person.Age.GetType()}:  {person.Age}");
