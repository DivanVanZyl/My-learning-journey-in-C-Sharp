namespace ConsoleDemo
{
    public static class ExtentionMethods
    {
        public struct BoolMarker<T>
        {
            public bool Result;
            public T Self;
            public enum Operation
            {
                None,
                And,
                Or
            };

            internal Operation PendingOp;

            internal BoolMarker(bool result, T self, BoolMarker<T>.Operation pendingOp)
            {
                Result = result;
                Self = self;
                PendingOp = pendingOp;
            }
            public BoolMarker(bool result, T self)
                :this( result, self, Operation.None)
            {

            }
            public BoolMarker<T> And => new BoolMarker<T>(Result, Self, Operation.And);
            public static implicit operator bool(BoolMarker<T> marker)
            {
                return marker.Result;
            }
        }

        public static T AddTo<T>(this T self, ICollection<T> coll)
        {
            coll.Add(self);
            return self;
        }
        //For nice and clean comparison syntax, replacing what typically would be a if statement, or a switch statement. 
        public static bool IsOneOf<T>(this T self, params T[] values)
        {
            return values.Contains(self);
        }
        //public static bool HasNo<TSubject, T>(this TSubject self, Func<TSubject, IEnumerable<T>> props)
        //{
        //    return !props(self).Any();
        //}
        public static BoolMarker<TSubject> HasNo<TSubject, T>(this TSubject self, Func<TSubject, IEnumerable<T>> props)
        {
            return new BoolMarker<TSubject>(!props(self).Any(), self);
        }
        /*public static bool HasSome<TSubject, T>(this TSubject self, Func<TSubject, IEnumerable<T>> props)
        {
            return props(self).Any();
        }*/
        public static BoolMarker<TSubject> HasSome<TSubject, T>(this TSubject self, Func<TSubject, IEnumerable<T>> props)
        {
            return new BoolMarker<TSubject>(props(self).Any(), self);
        }
        //Gives us the ability to write: if (person.HasSome(p => p.Names).And.HasNo(p => p.Children)) { }
        public static BoolMarker<T> HasNo<T, U>(this BoolMarker<T> marker,
            Func<T, IEnumerable<U>> props)
        {
            if (marker.PendingOp == BoolMarker<T>.Operation.And && !marker.Result)
                return marker;
            return new BoolMarker<T>(!props(marker.Self).Any(), marker.Self);
        }
    }
    public class Person
    {
        public List<string> Names = new List<string>();
        public List<Person> Children = new List<Person>();
    }

    public class MyClass
    {
        public void AddingNumbers()
        {
            var list = new List<int>();
            var list2 = new List<int>();
            //list.Add(24);
            24.AddTo(list); //Instead of "list being in control" it is the "value being added that is in control"
        }
        public void ProcessCommand(string opcode)
        {
            //if (opcode == "AND" || opcode == "OR" || opcode == "XOR") { }
            //if (new[] { "AND", "OR", "XOR" }.Contains(opcode)) { }  //Better, but still not great syntax (particularly the constructor)
            //if ("AND OR XOR".Split(' ').Contains(opcode)) { }
            if (opcode.IsOneOf("AND", "OR", "XOR")) { } //Clean syntax and readable from left to right.
        }
        public void Process(Person person)
        {
            //if (person.Names.Count == 0) { }    //Problem here is that it's not as readable from left to right (in english terms)
            //if (!person.Names.Any()) { }    //I don't like this one, as it has the NOT in the expression

            //These can be used with the boolean version:
            //if (person.HasNo(p => p.Names)) { }
            //if (person.HasSome(p => p.Names)) { }
            if (person.HasSome(p => p.Names).And.HasNo(p => p.Children)) { }    //Very fluent and readible construct to check the presense or absense of properties.

        }
    }
}
