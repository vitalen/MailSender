using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace TestWPF
{
    public class EmailSendServiceClass
    {
        private string From { get; set; }
        private string To { get; set; }
        private string Cc { get; set; }
        private string Bcc { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Body { get; set; }
        private string Subject { get; set; }

        public EmailSendServiceClass( string _username, string _password, string _subject, string _body, string _from, string _to, string _cc, string _bcc)
        {
            From = _from;
            To = _to;
            Cc = _cc;
            Bcc = _bcc;
            Username = _username;
            Password = _password;
            Subject = _subject;
            Body = _body;
        }

        public void SendEmail()
        {
            var message = new MailMessage(new MailAddress(From, From), new MailAddress(To, To));

            if (Cc != null) message.CC.Add(new MailAddress(Cc, Cc));
            if (Bcc != null) message.Bcc.Add(new MailAddress(Bcc, Bcc));

            message.Subject = Subject;
            message.Body = Body;
            message.IsBodyHtml = true;
            var client = new SmtpClient(AppConfigClass.host, AppConfigClass.port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential { UserName = Username, Password = Password }
            };

            try
            {
                client.Send(message);
                MessageBox.Show("Email wurde erfolgreich versendet","Erfolgreiches Versand",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (SmtpException)
            {
                MessageBox.Show("Smtp Problem", "Error beim Versenden", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (TimeoutException)
            {
                MessageBox.Show("TimeOut", "Error beim Versenden", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    }
}
