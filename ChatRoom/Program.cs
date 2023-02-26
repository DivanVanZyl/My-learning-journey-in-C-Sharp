using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace ChatRoom
{

    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }

        public void  Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            chatLog.Add(s);
            Console.WriteLine($"[{Name}'s chat session] {s}");
        }
    }
    public class ChatRoom
    {
        private List<Person> people = new List<Person>();

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);

            p.Room = this;
            people.Add(p);
        }

        public void Broadcast(string source, string message)
        {
            foreach(var p in people)
            {
                if(p.Name != source)
                {
                    p.Receive(source, message);
                }
            }
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)
                ?.Receive(source, message);
        }   
    }

    internal class Demo
    {
        static void Main(string[] args)
        {
            var room = new ChatRoom();

            var divan = new Person("Divan");
            var jean = new Person("Jean");

            room.Join(divan);
            room.Join(jean);

            divan.Say("Hi");
            jean.Say("oh, hey divan");

            var michèle = new Person("Michèle");
            room.Join(michèle);

            michèle.PrivateMessage("Jean", "Glad you can join us");

        }
    }
}