using Fluent_Interface;

var boat = Boat.BuildBoat()
    .WithSails()
    .WithName("Blu boi");

Console.WriteLine("I have a boat");

if(boat.HasSails)
{
    Console.WriteLine("It has sails.");
}
else
{
    Console.WriteLine("It does not have sails.");
}

Console.WriteLine($"And it's name is: {boat.Name}");
