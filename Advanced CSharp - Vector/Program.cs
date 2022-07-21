//Vector<T> is generalisation over VecrorXxx<T>
//T can be a built-in numeric value type (integral, float, double)

//Check size
using System.Numerics;

Console.WriteLine("Size of Vector<T> on this machine is " + Vector<int>.Count);

//Vector<T> CAN be hardware accelerated
if(Vector.IsHardwareAccelerated)
{
    Console.WriteLine("Vector is harware accelerated on this machine!");
}
else
{
    Console.WriteLine("Vector is not harware accelerated on this machine.");
}

//Use of intrinsics
//Add and sub always uses intrinsics
//Multiplication for short, int, float, double
//Division for float and double

Console.WriteLine("Adding two byte arrays, using Vector<T> to do SIMD operations.");
///Add two arrays of bytes
//Create and initialise arrays. Seq of nums from 1 to 128 and turning it into byte array.
byte[] array1 = Enumerable.Range(1,128)
    .Select(x => (byte)x).ToArray();
byte[] array2 = Enumerable.Range(4, 128)
    .Select(x => (byte)x).ToArray();
byte[] result = new byte[128];

//Check size of SIMD register
int size = Vector<byte>.Count;

//Loop register size
for(int i = 0;i < array1.Length;i += size)
{
    var va = new Vector<byte>(array1,i);
    var vb = new Vector<byte>(array2, i);
    var vresult = va + vb;  //Operator support, unlike intrinsics (in the "Intrinsics" project). va+vb here, is a SIMD accelerated addition (several bytes at a time).
    vresult.CopyTo(result, i);
}
Console.Write("[");
foreach(var b in result)
    Console.Write(b + ",");
Console.Write("]");

Console.ReadKey();