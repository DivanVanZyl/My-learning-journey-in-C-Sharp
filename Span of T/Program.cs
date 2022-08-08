using System.Runtime.InteropServices;

unsafe
{
    //Managed memory
    byte* ptr = stackalloc byte[4];
    Span<byte> memory = new Span<byte> (ptr, 4);

    //Unmanaged
    IntPtr unmanagedPtr = Marshal.AllocHGlobal (123);
    Span<byte> unmanagedMemory = new Span<byte>(unmanagedPtr.ToPointer (), 123);
    Marshal.FreeHGlobal (unmanagedPtr);
}

char[] stuff = "hello".ToCharArray();
Span<char> arraymemory = stuff; //automatically init a Span which refers to the acual letters inside "hello"

ReadOnlySpan<char> more = "hi there!".AsSpan();

Console.WriteLine($"Out span has {more.Length} elements");

//Some operations on Span
arraymemory.Fill('x');  //MODIFY array
Console.WriteLine(stuff);
arraymemory.Clear();
Console.WriteLine(stuff);