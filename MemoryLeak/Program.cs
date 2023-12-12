using Shared;
using System;


Random random = new Random();
List<x> people = new List<x>();

while (true)
{
    var p = new x();
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    p.a = new string(Enumerable.Repeat(chars, 100)
        .Select(s => s[random.Next(s.Length)]).ToArray());
    p.b = "This is a test string.";
    p.c = random.Next(1,100);
    people.Add(p);
}
class x
{
    public string a {  get; set; }
    public string b { get; set; }
    public int c { get; set; }
}
//Running this boi eats up more and more RAM.
//The process memory shown in VS is NOT consistant with what is shown in task manager for VS though

//Debug mode with debugging result: Same as above. My PC is a bit slow but there seems to be some GC magic going on. Massive disk usage on VS process, this might indicate swapping!! I don't see mire disk usage even after 10min, this might mean that swap space is a set amount alreadt catered for. YES!! when i stopped the program, it freed up amount 9GB of disk space!

//Release mode without debugging result: Same