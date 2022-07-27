//FP calcs do not cause exceptions:
//Div of 0 is allowed!
//FP types define the idea of infinity:
var di = double.PositiveInfinity;
var fi = float.PositiveInfinity;
//only thing you can do with infinity is flip the sign. Once you have it, you are stuck with that state
//eg -1.0 * fi

//NaN is: Not a Number, any operation on it yields a NaN eg. double.Nan == (1.0/0.0) //false

//Presentation problems:
Console.WriteLine("FP numbers are stored in binary, for eg. 0.1 is stored as repeating bin numbers: 0.000110011001100110011....");
Console.Write("This can lead to surprising results. \nFor eg. 0.1 + 0.2 = ");
double d = 0.1 + 0.2;
Console.Write(d + "\n\n");

Console.WriteLine($"Comparing using direct floating point arithmatic (0.1 + 0.2) == 0.3");
if ((0.1 + 0.2) == 0.3)
{
    Console.WriteLine("Success!");
}
else
{
    Console.WriteLine("Failure");
}

Console.Write(Environment.NewLine);

//Comparisons need to use tolerance value:
//if(Math.Abs(x - y) < 1e-8)
//You will have to find the tolerance values.
double toleranceValue = 1e-8;
Console.WriteLine($"Comparing using tolerance value {toleranceValue}");
if (Math.Abs(d - 0.3) < toleranceValue)
{
    Console.WriteLine("Success!");
}
else
{
    Console.WriteLine("Failure, incorrect tolerance value");
}


