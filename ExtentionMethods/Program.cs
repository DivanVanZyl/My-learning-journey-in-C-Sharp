namespace ExtentionMethods
{
    //Extention method's class and method must be static.
    //The special syntax that makes this an extention method is (this someType var)
    //You can even create extention methods for BCL classes.
    public static class ExtentionMethods
    {
        public static string ToBinary(this double n)
        {
            var bytes = BitConverter.GetBytes(n);
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            //Write to memory
            binaryWriter.Write(bytes);

            //Create reader using the memory stream as used with the writer.
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            memoryStream.Position = 0;

             //binaryReader.ReadString();
            int arraySize = (int)(memoryStream.Length - memoryStream.Position);
            char[] memoryData = new char[arraySize];
            binaryReader.Read(memoryData, 0, arraySize);
            return new string(memoryData);
        }

        //You can even make an extention method that is available for any object
        public static void Foo(this object o)
        {

        }
        //OR, you can do a similar thing with generics. But here you have type information as well. 
        public static void Bar<T>(this T o)
        {

        }

    }

    public class Demo
    {
        public static void Main()
        {
            double x = 0.1 + 0.2;
            Console.WriteLine(x.ToBinary());
            Console.ReadKey();
        }
    }
}