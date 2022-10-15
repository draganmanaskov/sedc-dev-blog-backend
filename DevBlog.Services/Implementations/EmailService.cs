using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace DevBlog.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public void SendEmail(string postTitle, int postId)
        {
            List<Email> emails = _emailRepository.GetAll();

            emails.ForEach(emailAddress =>
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("triston.cartwright79@ethereal.email"));
                email.To.Add(MailboxAddress.Parse(emailAddress.Address));
                email.Subject = "New Post Created";
                email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>Post:{postTitle} with id:{postId} Created</h1>" };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("triston.cartwright79@ethereal.email", "49t6P9KGXer8nREme2");
                smtp.Send(email);
                smtp.Disconnect(true);
            });

        }

        public void Subscribe(string emailAddress)
        {
            var email = _emailRepository.GetByEmail(emailAddress);
            if (email != null)
            {
                throw new EmailDataException("Email already subscribed");
            }

            Email newEmail = new Email()
            {
                Address = emailAddress,
            };

            _emailRepository.Add(newEmail);
        }

        public void Unsubscribe(string emailAddress)
        {
            var email = _emailRepository.GetByEmail(emailAddress);
            if (email == null)
            {
                throw new EmailNotFoundException($"Email {emailAddress} is not subscribed");
            }
            _emailRepository.Delete(email);
        }
    }
}
