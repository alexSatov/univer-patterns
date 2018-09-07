using System;
using System.Linq;
using ChatWithDecorators.Decorators;

namespace ChatWithDecorators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IChat chat = new Chat();
            chat = new DecoratorBuilder(chat)
                .WithTextEncrypt()
                .WithUserHide()
                .Build();
            chat.SendMessage(new Message("Alex", "Ivan", "Hi"));
            chat.SendMessage(new Message("Alex", "Ivan", "How are you?"));
            chat.SendMessage(new Message("Ivan", "Alex", "Fine"));
            Console.WriteLine();
            var messages = chat.GetMessages("Ivan");
            Console.WriteLine(string.Join("\n", messages.Select(m => m.Text)));
            Console.ReadKey();
        }
    }
}
