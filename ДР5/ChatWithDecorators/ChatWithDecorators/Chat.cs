using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatWithDecorators
{
    public class Chat : IChat
    {
        private List<Message> messages = new List<Message>();

        public void SendMessage(Message message)
        {
            messages.Add(message);
            Console.WriteLine($"Sended message:\n" +
                              $"Author: { message.Author }\n" +
                              $"Addressee: { message.Addressee }\n" +
                              $"Text: { message.Text }\n");
        }

        public Message[] GetMessages(string reciepient)
        {
            var messagesForReciepient = messages
                .Where(m => m.Addressee == reciepient)
                .ToArray();
            return messagesForReciepient;
        }
    }
}