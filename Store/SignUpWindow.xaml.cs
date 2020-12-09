using DatabaseConnection;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        
        public SignUpWindow()
        {
            InitializeComponent();
        }

        // Här gör man sitt konto
        // den kollar så att ingen av fälten är tomma förutom Telefonnummer
        public void WindowSignUp_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new Context())
            {

                string namebytext = NameSignUP.Text;
                string usernamebytext = UserNameSignUP.Text;
                string passwordbytext = PasswordSignUP.Password;
                string phonenumberbytext = PhonenumberSignup.Text;
                string emailbytext = EmailSignup.Text;
                string adressbytext = AdressSignnup.Text;

                ctx.AddRange(new List<Customer> {
                    new Customer {Name = namebytext,
                                 Username = usernamebytext,
                                 Password = passwordbytext,
                                 Phonenumber = phonenumberbytext,
                                 Email = emailbytext,
                                 Adress = adressbytext } });

                ctx.SaveChanges();
            }

            MessageBox.Show("Registration complete");
            var LoginWindow = new LoginWindow();
            LoginWindow.Show();
            this.Close();
        }

        // en knapt som skickar tillbaka en till LoginWindow
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var Back = new LoginWindow();
            Back.Show();
            this.Close();
        }
    }
}
