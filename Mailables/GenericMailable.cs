using Coravel.Mailer.Mail;

namespace OikosPortal.Mailables
{
    public class GenericMailable : Mailable<string>
    {
        private string _to;
        private string _from;
        private string _html;

        private string _subject;

        public GenericMailable(string to, string from, string subject, string html)
        {
            _to = to;
            _html = html;
            _from = from;
            _subject = subject;
        }

        public override void Build()
        {
            this.To(_to)
                .From(new MailRecipient(_from, "Oikos Portal"))
                .Subject(_subject)
                .Html(_html);
        }
    }
}
