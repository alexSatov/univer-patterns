namespace ChatWithDecorators.Decorators
{
    public class DecoratorBuilder
    {
        private IChat chat;

        public DecoratorBuilder(IChat chat)
        {
            this.chat = chat;
        }

        public DecoratorBuilder WithTextEncrypt()
        {
            chat = new TextEncryptDecorator(chat);
            return this;
        }

        public DecoratorBuilder WithUserHide()
        {
            chat = new UserHideDecorator(chat);
            return this;
        }

        public IChat Build()
        {
            return chat;
        }
    }
}