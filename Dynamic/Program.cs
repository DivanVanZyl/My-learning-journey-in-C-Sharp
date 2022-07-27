//Coding in the dynamic paradigm is possible in C#
//This was introduced to support late binding. (Deffered to runtime)
//"dynamic" keyword is same as "object", but with late binding

using Microsoft.CSharp.RuntimeBinder;

dynamic Person = "";
Console.WriteLine(Person.GetType());
Console.WriteLine(Person.Length);
try
{
    Person.Name = "Divan";
}
catch(RuntimeBinderException e)
{
    Console.WriteLine(e.Message);
}

//Can change type dynamically
Person = 123;
Console.WriteLine(Person.GetType());
Console.WriteLine(Person);
