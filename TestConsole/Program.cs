using System;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = new MailAddress("koenig.vitalij@web.de", "Vitalij");
            var to = new MailAddress("koenig.vitalij@web.de", "Vitalij");

            var message = new MailMessage(from, to);
            message.Subject = "subject";
            message.Body = "body";
            var client = new SmtpClient("smtp.gmx.de", 465);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential
            {
                UserName = "***",
                //SecurePassword = ""
                Password = ""
            };
            client.Send(message);
        }
    }
}
