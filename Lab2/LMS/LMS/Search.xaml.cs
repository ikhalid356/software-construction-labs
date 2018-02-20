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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }


        private void textBoxA_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(App.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM artifacts WHERE Author LIKE\"" + textBoxA.Text + "%" + "\"";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                        da.Fill(dt);
                }
                StableA.ItemsSource = dt.DefaultView;
            }

            catch (Exception exp)
            {

                Err.Text = "No artifact of this author exists!";
            }
        }

        
        private void textBoxT_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(App.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM artifacts WHERE Name LIKE\"" + textBoxT.Text + "%" + "\"";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                        da.Fill(dt);
                }
                StableT.ItemsSource = dt.DefaultView;
            }

            catch (Exception exp)
            {

                Err.Text = "No artifact of this title exists!";
            }
        }


        private void textBoxG_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(App.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM artifacts WHERE Genre LIKE\"" + textBoxG.Text + "%" + "\"";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                        da.Fill(dt);
                }
                StableG.ItemsSource = dt.DefaultView;
            }

            catch (Exception exp)
            {

                Err.Text = "No artifact of this genre exists!";
            }
        }

       
    }
}
