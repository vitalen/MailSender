using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Service;
using MailSender.Models;



namespace MailSender.Data
{
    internal static class TestData
    {
        public static List<Server> Servers { get; } = Enumerable.Range(1, 10)
            .Select(i => new Server
            {
                Name = $"Server-{i}",
                Address = $"smtp.server{i}.de",
                Login = $"Login-{i}",
                Password = TextEncoder.Encode($"Password-{i}", 7),
                UseSSL = i % 2 == 0
            })
            .ToList();

        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender
            {
                Name = $"Absender {i}",
                Address = $"sender_{i}@server.de"
            })
            .ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
            .Select(i => new Recipient
            {
                Name = $"Empfänger {i}",
                Address = $"recipient_{i}@server.de"
            })
            .ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 100)
            .Select(i => new Message
            {
                Title = $"Nachricht {i}",
                Text = $"Inhalt der Nachricht {i}"
            })
            .ToList();


    }
}
