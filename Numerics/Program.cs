using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// Tells you if your CPU supports Advanced Vector Extensions.
/// This determines what intrinsics your can call. 
/// If AVX is supported, you can call it's static members eg. Avx2.Add()
/// And, you can operate on special Vector types eg. Vector64.Create()
/// 
/// </summary>

if (Avx.IsSupported)
{
    Console.WriteLine("AVX is supported!");
    var x = Vector128.Create(1.0f); //Allocate 128 bit registers full of floating point numbers. IOW packs as many floats of that value in the register as possible
    var y = Vector128.Create(1.0f);
    var f = Sse.Add(x, y);  //NOTE: No operator support, intrintic calls map onto CPU intsuctions!

    //Adding 4 pairs of floats. Single Instruction Multiple Data calculation
    var v1 = Vector128.Create(1.0f,2.0f,3.0f,4.0f); //Allocate 128 bit registers full of floating point numbers. IOW packs as many floats of that value in the register as possible
    var v2 = Vector128.Create(1.0f, 2.0f, 4.0f, 8.0f);
    var sum = Sse.Add(v1, v2);
    Console.WriteLine(sum);
}
else
{
    Console.WriteLine("AVX is not supported.");
}

Console.ReadKey();