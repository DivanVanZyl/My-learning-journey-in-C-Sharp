var builder  = new HtmlBuilder("ul");
builder.AddChild("li", "Hello");
builder.AddChild("li", "Computer");
Console.WriteLine(builder.ToString());