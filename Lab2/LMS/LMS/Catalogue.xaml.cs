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
    /// Interaction logic for Catalogue.xaml
    /// </summary>
    public partial class Catalogue : Window
    {
        public Catalogue()
        {
            InitializeComponent();
            Loaded += window_loaded;
        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
            load_catalogue();
            load_issued();
        }

        private void load_catalogue()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(App.connectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM artifacts", con);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "LoadData");
                table.DataContext = dataset;
                con.Close();
            }
            catch (Exception exp)
            {
                InfoBox.Text = exp.Message;
            }
        }

        private void load_issued()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(App.connectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT ArtifactsID, Name, Author, PublicationDate, DateIssued," +
                    "Genre, issued.Quantity, Type, isOwned from artifacts INNER JOIN issued ON issued.ArtifactID=" + 
                    "artifacts.ArtifactsID AND issued.UserID=" + App.userID.ToString(), con);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "LoadDataIssued");
                issuedTable.DataContext = dataset;
                con.Close();
            }
            catch (Exception exp)
            {
                InfoBox.Text = exp.Message;
            }
        }

        bool can_issue()
        {
            //Get artifact id from IdBox.Text
            //Also check and increment fines
            //Get user id from App.userID
            return true;
        }

        private void IssueButton_Click(object sender, RoutedEventArgs e)
        {
            InfoBox.Text = "Enter Artifact ID below to issue an artifact";
            if (can_issue())
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                try
                {
                    MySqlConnection con = new MySqlConnection(App.connectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO issued VALUES (" + IdBox.Text + "," + App.userID +
                        ",\"" + date + "\",1,\"No\") ON DUPLICATE KEY UPDATE `Quantity` = `Quantity` + 1", con);
                    cmd.ExecuteNonQuery();

                    cmd = new MySqlCommand("UPDATE artifacts SET Quantity = Quantity - 1 WHERE ArtifactsID ="
                        + IdBox.Text + " AND Quantity > 0", con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    load_catalogue();
                    load_issued();

                }
                catch (Exception exp)
                {
                    InfoBox.Text = "Wrong Artifact ID entered";
                }
            }
            else
            {
                InfoBox.Text = "Cannot Issue, Limit Reached!";
            }
        }

        private void Sbutton_Click(object sender, RoutedEventArgs e)
        {
            Search search1 = new Search();
            search1.Show();
            this.Close();
        }
    }
}
