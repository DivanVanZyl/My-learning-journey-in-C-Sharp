using System.Numerics;

public class QuadtraticEquationSolver
{
    public enum WorkFlowResult
    {
        Success, Failure
    }
    //ax^2+bx+c == 0
    //Here we moved the return value from public Tuple<Complex, Complex> Start(double a, double b, double c), into an 'out' parameter:
    public WorkFlowResult Start(double a, double b, double c, out Tuple<Complex, Complex> result)
    {
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            result = null;
            return WorkFlowResult.Failure;
        }
            //return SolveComplex(a, b, c, discriminant);
        else
        {
            return SolveSimple(a, b, /*c,*/ discriminant, out result);
        }
    }

    private WorkFlowResult SolveSimple(double a, double b, /*double c,*/ double discriminant, out Tuple<Complex, Complex> result)
    {
        var rootDisc = Math.Sqrt(discriminant);
        result = Tuple.Create(
            new Complex((-b + rootDisc) / (2 * a), 0),
            new Complex((-b - rootDisc) / (2 * a), 0)
            );
        return WorkFlowResult.Success;
    }

    private Tuple<Complex, Complex> SolveComplex(double a, double b, /*double c,*/ double discriminant)
    {
        var rootDisc = Complex.Sqrt(new Complex(discriminant, 0));
        return Tuple.Create(
            (-b + rootDisc) / (2 * a),
            (-b - rootDisc) / (2 * b)
            );
    }

    public class ContinuationPassingStyleDemo
    {
        static void Main()
        {
            var solver = new QuadtraticEquationSolver();
            Tuple<Complex, Complex> solution;
            var flag = solver.Start(1,10,16, out solution);
            if(flag == WorkFlowResult.Success)
                Console.WriteLine($"{solution.Item1}, {solution.Item2}");
        }
    }
}