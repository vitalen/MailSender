using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var from = new MailAddress("***", "Vitalij");
            var to = new MailAddress("***", "Vitalij");

            var message = new MailMessage(from, to);
            message.Subject = "subject";
            message.Body = "body";
            var client = new SmtpClient("smtp.web.de", 25)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential {UserName = LoginName.Text, Password = Password.Password}
            };

            try
            {
                client.Send(message);
                MessageBox.Show("Alles korrekt angekommen", "Information", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (SmtpException exception)
            {
                MessageBox.Show("Smtp Problem","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (TimeoutException exception)
            {
                MessageBox.Show("TimeOut", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}
