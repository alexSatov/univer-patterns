namespace ChatWithDecorators
{
    public class Message
    {
        public string Author { get; set; }
        public string Addressee { get; set; }
        public string Text { get; set; }

        public Message(string author, string addressee, string text)
        {
            Author = author;
            Addressee = addressee;
            Text = text;
        }
    }
}
