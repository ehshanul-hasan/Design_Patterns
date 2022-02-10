using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    //  The Mediator Design Pattern is used to reduce the communication complexity between
    //  multiple objects. This design pattern provides a mediator object and that mediator
    //  object normally handles all the communication complexities between different objects.
    public class MediatorPattern
    {
        public string GetChatHistory()
        {
            var room = new ChatHistory();

            var john = new User("1");
            var jane = new User("2");

            room.Join(john);
            room.Join(jane);

            john.Say("hi bot");
            jane.Say("oh, hey");

            var simon = new User("3");
            room.Join(simon);
            simon.Say("hi everyone!");

            jane.PrivateMessage("3", "welocome!");

            return $"{john.GetChatLog()} \n {jane.GetChatLog()} \n {simon.GetChatLog()}";
        }


    }

    public class User
    {
        public string Id;
        public ChatHistory Room;
        private List<string> chatLog = new List<string>();

        public User(string id)
        {
            Id = id;
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            chatLog.Add(s);
        }

        public void Say(string message)
        {
            Room.Broadcast(Id, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Id, who, message);
        }

        public string GetChatLog()
        {
            return string.Join(" \n ", chatLog);
        }
    }

    public class ChatHistory
    {
        private List<User> people = new List<User>();

        public void Broadcast(string source, string message)
        {
            foreach (var p in people)
                if (p.Id != source)
                    p.Receive(source, message);
        }

        public void Join(User p)
        {
            string joinMsg = $"{p.Id} joins the chat";
            Broadcast("room", joinMsg);

            p.Room = this;
            people.Add(p);
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Id == destination)?.Receive(source, message);
        }
    }

}
