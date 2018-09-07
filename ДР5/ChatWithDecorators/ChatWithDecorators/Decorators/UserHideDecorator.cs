namespace ChatWithDecorators.Decorators
{
    public class UserHideDecorator : BaseChatDecorator
    {
        public UserHideDecorator(IChat chat) : base(chat)
        {
        }

        protected override Message ProcessBeforeSending(Message message)
        {
            message.Addressee = Hide(message.Addressee);
            message.Author = Hide(message.Author);
            return base.ProcessBeforeSending(message);
        }

        protected override string ProcessBeforeSearchUser(string user)
        {
            return base.ProcessBeforeSearchUser(Hide(user));
        }

        private static string Hide(string user)
        {
            return user.GetHashCode().ToString();
        }
    }
}