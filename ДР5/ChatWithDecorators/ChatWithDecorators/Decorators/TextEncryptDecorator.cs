namespace ChatWithDecorators.Decorators
{
    public class TextEncryptDecorator : BaseChatDecorator
    {
        public TextEncryptDecorator(IChat chat) : base(chat)
        {
        }

        protected override Message ProcessBeforeSending(Message message)
        {
            message.Text = Encrypt(message.Text);
            return base.ProcessBeforeSending(message);
        }

        protected override Message ProcessAfterSending(Message message)
        {
            message.Text = Decrypt(message.Text);
            return base.ProcessAfterSending(message);
        }

        private static string Encrypt(string text)
        {
            return "<enc>" + text + "</enc>";
        }

        private static string Decrypt(string text)
        {
            return text.Substring(5, text.Length - 11);
        }
    }
}