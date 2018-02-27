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
    public partial class staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (login.userType == "" || login.userType == "owner")
                Response.Redirect("~/login.aspx");
            Load_Tables();
        }
        void Load_Tables()
        {
            MySqlConnection con = new MySqlConnection(login.connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM food;", con);
            using (MySqlDataAdapter adp = new MySqlDataAdapter())
            {
                adp.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    adp.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            cmd = new MySqlCommand("SELECT * FROM orders WHERE IsComplete='NO';", con);
            using (MySqlDataAdapter adp = new MySqlDataAdapter())
            {
                adp.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    adp.Fill(dt);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
            con.Close();
        }

        protected void delete_food_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(login.connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM food WHERE foodID=" + deleteBox.Text + ";", con);
            if (cmd.ExecuteNonQuery() != 0)
                Load_Tables();
            con.Close();
        }

        protected void add_food_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(login.connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `food` (FName, Price) VALUES ('" +
                    foodnameBox.Text + "','" + priceBox.Text + "');", con);

            if (cmd.ExecuteNonQuery() != 0)
                Load_Tables();
            con.Close();
        }

        protected void complete_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(login.connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE orders SET IsComplete='YES' WHERE OrderID=" +
                    orderBox.Text + ";", con);

            if (cmd.ExecuteNonQuery() != 0)
                Load_Tables();
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}