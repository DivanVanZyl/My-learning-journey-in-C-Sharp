var builder = new HtmlBuilder("ul");
builder.AddChild("li", "Hello")
    .AddChild("li", "Computer");
Console.WriteLine(builder.ToString());