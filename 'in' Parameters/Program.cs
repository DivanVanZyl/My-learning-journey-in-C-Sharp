struct Point
{
    public double X, Y;
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }    
    private static Point origin = new Point();
    //Property that does not return a copy of the origin, but a reference to the origin.
    public static ref readonly Point Origin => ref origin;  //We can create a refence to a value type, with 'ref readonly'. Pointer / memory adress of where it is stored, that way we can access the same object on every single invocation
    public void Reset()
    {
        X = 0;
        Y = 0;
    }
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Program
{
    //In this way, copies of those entire objects will be passed.
    //This would mean, that you would pass 4 double values.
    //double MeasureDistance(Point p1, Point p2)
    //{
    //    var dx = p1.X - p2.X;
    //    var dy = p1.Y - p2.Y;
    //    return Math.Sqrt(dx * dx + dy * dy);
    //}
    //The above is commented out, as: you cannot make overloads, that only differ in the 'in' parameter, passing as reference. Uncomment to see.

    //'In' keyword here, states that the structure will be passed by reference, not value, hence not creating and passing an entire copy of the structure.
    //But rather passed as a memory location (pointer). This can save you al lot of memory.
    //ALSO, the 'in' keyword makes the structure READ ONLY
    //The object will be passed as immutable
    double MeasureDistance(in Point p1,in Point p2)
    {
        //p1.Reset(); //This only modified a copy.
        var dx = p1.X - p2.X;
        var dy = p1.Y - p2.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public Program()
    {
        var p1 = new Point(1, 1);
        var p2 = new Point(4, 5);

        var distance = MeasureDistance(p1, p2);

        Console.WriteLine($"Distance between {p1} and {p2} is {distance}");

        var distanceFromOrigin = MeasureDistance(p1, new Point(1,2));

        //value type symantics
        Point copyOfOrigin = Point.Origin;  //by-value copy

        //ref var messWithOrigin = ref Point.Origin; //Cant do this, as it's read-only

        //You can have a ref readonly variable:
        ref readonly var origonRef = ref Point.Origin;
    }
    static void Main(string[] args)
    {
        new Program();
    }
}