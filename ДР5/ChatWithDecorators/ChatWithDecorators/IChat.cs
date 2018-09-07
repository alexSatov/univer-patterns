namespace ChatWithDecorators
{
    public interface IChat
    {
        void SendMessage(Message message);
        Message[] GetMessages(string reciepient);
    }
}