using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace CMS
{
    public partial class login : System.Web.UI.Page
    {
        public static string connectionString = "server=localhost;user id=root;password=1234;persistsecurityinfo=True;database=lab3";
        public static string userID = "";
        public static string userType = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (emailBox.Text.Length < 4 || passwordBox.Text.Length < 3)
                {
                    ErrorBox.Text = "Email or password incorrect.";
                    return;
                }
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Pass FROM user WHERE Email=\"" + emailBox.Text + "\"", con);
                if (passwordBox.Text == cmd.ExecuteScalar().ToString())
                {
                    cmd = new MySqlCommand("SELECT UserID FROM user WHERE Email=\"" + emailBox.Text + "\"", con);
                    userID = cmd.ExecuteScalar().ToString();
                    cmd = new MySqlCommand("SELECT UType FROM user WHERE Email=\"" + emailBox.Text + "\"", con);
                    userType = cmd.ExecuteScalar().ToString();
                    //Catalogue catalogue = new Catalogue();
                    //catalogue.Show();
                    //this.Close();
                    Response.Redirect("~/staff.aspx");
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

        protected void register_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (emailBox.Text.Length < 4 || passwordBox.Text.Length < 3)
                {
                    ErrorBox.Text = "Email or password too short";
                    return;
                }
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `user` (Email, Pass, UType) VALUES ('" +
                    emailBox.Text + "','" + passwordBox.Text + "','" + typeBox.SelectedValue + "')", con);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    cmd = new MySqlCommand("SELECT UserID FROM user WHERE Email=\"" + emailBox.Text + "\"", con);
                    userID = cmd.ExecuteScalar().ToString();
                    userType = typeBox.SelectedValue;
                    //Catalogue catalogue = new Catalogue();
                    //catalogue.Show();
                    //this.Close();
                    Response.Redirect("~/staff.aspx");
                }
                con.Close();
            }
            catch (Exception exp)
            {
                ErrorBox.Text = exp.Message;
            }
        }

        protected void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}