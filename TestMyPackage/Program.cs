using FileAbstraction;

256.ToFile();
FileAbstract.DisplayFile();

var list = new List<string> 
{
    "This",
    "is",
    "a",
    "collection"
};

list.ToFile();
FileAbstract.DisplayFile();