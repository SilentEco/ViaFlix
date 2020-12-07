using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatabaseConnection;
using Microsoft.Data.SqlClient;

namespace Store
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // Här tar den Username och password och lägger in de till State.User och State.Password den får info från metoden GetCustomerBy, och sen kopplat till 
        // WPF window med två Fields.
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
                State.User = API.GetCustomerByUsername(NameField.Text.Trim());
                State.Password = API.GetCustomerByPassword(PasswordField.Password.Trim());

            // Sålänge ingen av dom är null så kan man komma in
            if (State.User != null && State.Password != null)
            {
                var next_window = new MainWindow();
                next_window.Show();
                this.Close();
            }

            //Annars är de fel
            else
            {
                MessageBox.Show("Wrong username or password", "Error");
            }
        }
        //Är byter man window till Signup.
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            var signUp = new SignUpWindow();
            signUp.Show();
            this.Close();
        }
    }
}
