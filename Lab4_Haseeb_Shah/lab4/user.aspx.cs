using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace lab4
{
    public partial class user : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (login.userType == "")
                Response.Redirect("~/login.aspx");
        }

        //SUBMIT CLICK HANDLER
        protected void submit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (fnameBox.Text.Length < 2 || lnameBox.Text.Length < 2)
                {
                    ErrorBox.Text = "Names are too short";
                    return;
                }
                MySqlConnection con = new MySqlConnection(login.connectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `info` (FName, LName, BankBalance) VALUES ('" +
                    fnameBox.Text + "','" + lnameBox.Text + "'," + bankBox.Text + ")", con);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    ErrorBox.Text = "SUCESS!!";
                    Response.Redirect("~/login.aspx");
                }
                con.Close();
            }
            catch (Exception exp)
            {
                ErrorBox.Text = exp.Message;
            }
        }
    }
}