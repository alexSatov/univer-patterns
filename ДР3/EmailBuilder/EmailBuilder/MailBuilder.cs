using System.Collections.Generic;

namespace EmailBuilder
{
    public class EmailBuilder
    {
        private readonly List<string> recipients = new List<string>();
        private string body = "";
        private string theme;

        public EmailBuilder(string recipient, string body)
        {
            AddRecipient(recipient);
            AddBody(body);
        }

        public EmailBuilder AddBody(string extraBody)
        {
            body += extraBody;
            return this;
        }

        public EmailBuilder AddRecipient(string extraRecipient)
        {
            recipients.Add(extraRecipient);
            return this;
        }

        public EntitledEmailBuilder SetTheme(string theme)
        {
            this.theme = theme;
            return new EntitledEmailBuilder(this);
        }

        public Email ToEmail()
        {
            return new Email(body, theme, recipients.ToArray());
        } 
    }

    public class EntitledEmailBuilder
    {
        private readonly EmailBuilder builder;

        public EntitledEmailBuilder(EmailBuilder builder)
        {
            this.builder = builder;
        }

        public EntitledEmailBuilder AddBody(string extraBody)
        {
            builder.AddBody(extraBody);
            return this;
        }

        public EntitledEmailBuilder AddRecipient(string extraRecipient)
        {
            builder.AddRecipient(extraRecipient);
            return this;
        }

        public Email ToEmail()
        {
            return builder.ToEmail();
        }
    }

    public class Email
    {
        public string[] Recipients { get; }
        public string Body { get; }
        public string Theme { get; }

        public Email(string body, string theme, params string[] recipients)
        {
            Recipients = recipients;
            Theme = theme;
            Body = body;
        }
    }
}
