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
        string connectioString = @"Data Source = .\SQLEXPRESS; Initial Catalog = SaleDatabase; Trusted_Connection=True;";
        public SignUpWindow()
        {
            InitializeComponent();
        }

        // Här gör man sitt konto
        // den kollar så att ingen av fälten är tomma förutom Telefonnummer
        private void WindowSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameSignUP.Text == "" || PasswordSignUP.Password == "" || NameSignUP.Text == "" || EmailSignup.Text == "" || AdressSignnup.Text == "")
                MessageBox.Show("Please fill the requiered forms");
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectioString))
                {
                    try
                    {
                        //En Stored Procedure som tar info vad man skriver i alla fields och kopplar de till databasen.
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("AddUser", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue(@"Name", NameSignUP.Text);
                        sqlCmd.Parameters.AddWithValue(@"Username", UserNameSignUP.Text);
                        sqlCmd.Parameters.AddWithValue(@"Password", PasswordSignUP.Password);
                        sqlCmd.Parameters.AddWithValue(@"Phonenumber", PhonenumberSignup.Text);
                        sqlCmd.Parameters.AddWithValue(@"Email", EmailSignup.Text);
                        sqlCmd.Parameters.AddWithValue(@"Adress", AdressSignnup.Text);

                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Registration complete");
                        var LoginWindow = new LoginWindow();
                        LoginWindow.Show();
                        this.Close();

                        
                    }
                    //satte phonenumber till 10 totala siffror om man skriver mer så crashar de egentiligen men satte en catch så tar skriver felmeddelandet.
                    catch(Microsoft.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Your are only allowed 10 numbers in your phonenumber", "Error");
                    }
                }
            }

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
