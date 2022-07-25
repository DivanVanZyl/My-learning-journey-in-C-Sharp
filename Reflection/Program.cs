using System;
//************************System.Type***************************************************************************************
Type t = typeof(int);

Console.WriteLine("The type is: " + t + "\n");

Console.WriteLine("It's method info is: ");
foreach(var info in t.GetMethods())
    Console.WriteLine(info);


Console.WriteLine("It's property info is: ");
foreach (var info in t.GetProperties())
    Console.WriteLine(info);


Console.WriteLine("It's field info is: ");
foreach (var info in t.GetFields())
    Console.WriteLine(info);

Console.WriteLine();
//// .GetType() is method, that is available on every single object in .NET,
//// there are methods that are available on all objects in .NET!
//// eg. ToString(), equals
//Hence, you can do the same as above, like: Type t2 = "hello".GetType();


Console.WriteLine();
//Assembly has info on every single type it contains:
var a = typeof(string).Assembly;

Console.WriteLine($"There are {a.GetTypes().Length } types in assembly {a.FullName}" + Environment.NewLine);

//Get type by name
var t3 = Type.GetType("System.Int64");

Console.WriteLine($"There are {t3.GetMethods().Count()} methods in {t3.FullName}" + Environment.NewLine);

//Get type info for List<T>
//WHen you have a generic, to het the fully qualified name,
//you put a backtick after the name of the type,
//then the number of type parameters that this type has.
//For eg. `1 for lists and `2 for doctionaries (they have a key and value)
var t4 = Type.GetType("System.Collections.Generic.List`1");
Console.WriteLine($"A List<T> ({t4.FullName}) has {t4.GetMethods().Length } methods.");


//************************Inspection***************************************************************************************
//Guid is a struct, not a type, but we can still het type info
var t5 = typeof(Guid);
/*t5.FullName;
t5.Name;*/
var ctors = t5.GetConstructors();
foreach(var ctor in ctors)
    {
    Console.Write(" - Guid(");
    var pars = ctor.GetParameters();
    for(var i = 0; i < pars.Length; ++i)
    {
        var par = pars[i];
        Console.Write($"{par.ParameterType.Name} {par.Name}");
        if(i+1 != pars.Length)
        {
            Console.Write(",");
        }
    }
        Console.WriteLine(")");
}
Console.WriteLine();
//You can do the same as above for methods with eg. t.GetMethods();


//************************Construction***************************************************************************************
var t6 = typeof(bool);
//How to make a new instance of type bool, without the usual "new"?
//Use activator class:
var b = Activator.CreateInstance(t6);
Console.WriteLine($"The default value of an isntance of type {t6.FullName} is: {b}");

//Also possible to invoke CreateInstance using a generic parameter:
var b2 = Activator.CreateInstance<bool>();

//Remoting wrappers:
var wc = Activator.CreateInstance("System", "System.Timers.Timer");

Console.WriteLine("Wraped object: " + wc);
Console.WriteLine("Unwraped object: " + wc.Unwrap());

//Can get constructor and invoke it, in the way demonstrated earlier
var ctor1 = typeof(string).GetConstructor(new[] { typeof(char[]) });
var myString = ctor1.Invoke(new object[] {
new char[] { 'h', 'e', 'l', 'l', 'o' }
});

Console.WriteLine("This string's constructor was found, and then invoked: " + myString);

//Now the same for Generics
var listType = Type.GetType("System.Collections.Generic.List`1");
//[System.Collections.Generic.List`1[T]]
var listOfIntType = listType.MakeGenericType(typeof(int));
//[System.Collections.Generic.List`1[System.Int32]]

var listOfIntCtor = listOfIntType.GetConstructor(Array.Empty<Type>());
//[Void .ctor()]
var theList = listOfIntCtor.Invoke(Array.Empty<Type>());
//theList: List<int>(0) { }

//IMPORTANT: When you call Invoke() on something, you return an object, NOT a typed value. 
//You have to cast it into a type, to be able to perform an operation.
//Demonstrated below:
var charArrayCtor  = typeof(char[]).GetConstructor(new[] {typeof(int)});
var arr = charArrayCtor.Invoke(new object[] { 20 });
Console.WriteLine($"{ arr }is empty array here");
//arr[0] = 'A'; //NOT VALID. Cannot apply indexing to 'object'

//But now, after a cast:
var newArr = (char[])arr;
newArr[0] = 'a';    //Now we can do this.
var newStr = new string(newArr);
Console.WriteLine("The new content is: " + newStr);


Console.ReadKey();
