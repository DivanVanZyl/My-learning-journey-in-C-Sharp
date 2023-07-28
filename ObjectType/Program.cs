int myInt = 32;
int myOtherInt = 2;
string myString = "This is a string";

List<object> list = new List<object>
{
    32,
    2,
    "This is a string."
};

int product = 1;
foreach(object obj in list)
{
    if(obj is string)
        Console.WriteLine($"String value: {obj}");

    if(obj is int)
        product *= (int)obj;
}

Console.WriteLine($"Sum is: {product}");