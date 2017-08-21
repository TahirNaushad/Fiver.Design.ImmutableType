using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiver.Design.ImmutableType
{
    public sealed class Email
    {
        private readonly List<string> to;
        private readonly List<string> cc;
        private readonly List<string> bcc;
        private readonly List<string> attachments;

        public Email(string subject, string from, string body, string to)
        {
            if (string.IsNullOrEmpty(subject))
                throw new ArgumentException("Subject must be set");

            if (string.IsNullOrEmpty(from))
                throw new ArgumentException("From must be set");

            if (string.IsNullOrEmpty(body))
                throw new ArgumentException("Body must be set");

            if (string.IsNullOrEmpty(to))
                throw new ArgumentException("To must be set");

            this.Subject = subject;
            this.From = from;
            this.Body = body;
            this.to = new List<string> { to };
            this.cc = new List<string>();
            this.bcc = new List<string>();
            this.attachments = new List<string>();
        }

        private Email(string subject, string from, string body,
            List<string> to, List<string> cc, List<string> bcc,
            List<string> attachments)
        {
            this.Subject = subject;
            this.From = from;
            this.Body = body;
            this.to = to;
            this.cc = cc;
            this.bcc = bcc;
            this.attachments = attachments;
        }

        public string Subject { get; }
        public string From { get; }
        public string Body { get; }
        public IReadOnlyList<string> To => to;
        public IReadOnlyList<string> CC => cc;
        public IReadOnlyList<string> BCC => bcc;
        public IReadOnlyList<string> Attachments => attachments;

        public Email ChangeSubject(string subject)
        {
            return new Email(
                subject: subject,
                from: this.From,
                to: this.to,
                body: this.Body,
                cc: this.cc,
                bcc: this.bcc,
                attachments: this.attachments);
        }

        public Email ChangeFrom(string from)
        {
            return new Email(
                subject: this.Subject,
                from: from,
                to: this.to,
                body: this.Body,
                cc: this.cc,
                bcc: this.bcc,
                attachments: this.attachments);
        }

        public Email ChangeBody(string body)
        {
            return new Email(
                subject: this.Subject,
                from: this.From,
                to: this.to,
                body: body,
                cc: this.cc,
                bcc: this.bcc,
                attachments: this.attachments);
        }

        public Email AddTo(string to)
        {
            return new Email(
                subject: this.Subject,
                from: this.From,
                to: new List<string>().Concat(this.to).Append(to).ToList(),
                body: this.Body,
                cc: this.cc,
                bcc: this.bcc,
                attachments: this.attachments);
        }

        public Email AddCC(string cc)
        {
            return new Email(
                subject: this.Subject,
                from: this.From,
                to: this.to,
                body: this.Body,
                cc: new List<string>().Concat(this.cc).Append(cc).ToList(),
                bcc: this.bcc,
                attachments: this.attachments);
        }

        public Email AddBCC(string bcc)
        {
            return new Email(
                subject: this.Subject,
                from: this.From,
                to: this.to,
                body: this.Body,
                cc: this.cc,
                bcc: new List<string>().Concat(this.bcc).Append(bcc).ToList(),
                attachments: this.attachments);
        }

        public Email AddAttachment(string attachment)
        {
            return new Email(
                subject: this.Subject,
                from: this.From,
                to: this.to,
                body: this.Body,
                cc: this.cc,
                bcc: this.bcc,
                attachments: new List<string>().Concat(this.attachments).Append(attachment).ToList());
        }
    }
}
