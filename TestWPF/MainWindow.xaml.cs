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
            var email = new EmailSendServiceClass(LoginName.Text, Password.Password, Subject.Text, Body.Text, LoginName.Text, LoginName.Text,null, null);
            SendEndWindow sew = new SendEndWindow();
            email.SendEmail();
            sew.ShowDialog();
            SetEmpty();
        }

        private void SetEmpty()
        {
            LoginName.Text = "";
            Password.Password = "";
            Subject.Text = "";
            Body.Text = "";
        }
    }
}
