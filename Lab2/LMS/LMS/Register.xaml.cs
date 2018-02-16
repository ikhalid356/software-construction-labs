using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LMS
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (emailBox.Text.Length < 4 || passwordBox.Password.Length < 3)
                {
                    ErrorBox.Text = "Email or password too short";
                    return;
                }
                MySqlConnection con = new MySqlConnection(App.connectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `user` (Email, Password, FineDue,"
                    + "FineCollected) VALUES ('" + emailBox.Text + "','" + passwordBox.Password + "',0,0)", con);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    cmd = new MySqlCommand("SELECT UserID FROM user WHERE Email=\"" + emailBox.Text + "\"", con);
                    App.userID = cmd.ExecuteScalar().ToString();
                    Catalogue catalogue = new Catalogue();
                    catalogue.Show();
                    this.Close();
                }
                con.Close();
            }
            catch (Exception exp)
            {
                ErrorBox.Text = exp.Message;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (emailBox.Text.Length < 4 || passwordBox.ToString().Length < 3)
                {
                    ErrorBox.Text = "Email or password incorrect.";
                    return;
                }
                MySqlConnection con = new MySqlConnection(App.connectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Password FROM user WHERE Email=\"" + emailBox.Text + "\"", con);
                if (passwordBox.Password.ToString() == cmd.ExecuteScalar().ToString())
                {
                    cmd = new MySqlCommand("SELECT UserID FROM user WHERE Email=\"" + emailBox.Text + "\"", con);
                    App.userID = cmd.ExecuteScalar().ToString();
                    Catalogue catalogue = new Catalogue();
                    catalogue.Show();
                    this.Close();
                }
                else
                    ErrorBox.Text = "Incorrect email or password";
                con.Close();
            }
            catch (Exception exp)
            {

                ErrorBox.Text = "Email Does not exist";
            }
        }
    }
}
