using System;
using System.Linq;

namespace ChatWithDecorators.Decorators
{
    public class BaseChatDecorator : IChat
    {
        private readonly IChat chat;

        public BaseChatDecorator(IChat chat)
        {
            this.chat = chat;
        }

        public void SendMessage(Message message)
        {
            message = ProcessBeforeSending(message);
            chat.SendMessage(message);
        }

        public Message[] GetMessages(string reciepient)
        {
            reciepient = ProcessBeforeSearchUser(reciepient);
            var messages = chat.GetMessages(reciepient)
                .Select(ProcessAfterSending)
                .ToArray();
            return messages;
        }

        protected virtual string ProcessBeforeSearchUser(string user)
        {
            return user;
        }

        protected virtual Message ProcessBeforeSending(Message message)
        {
            return message;
        }

        protected virtual Message ProcessAfterSending(Message message)
        {
            return message;
        }
    }
}
