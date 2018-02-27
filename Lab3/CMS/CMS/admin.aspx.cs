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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (login.userType == "" || login.userType == "staff" || login.userType == "admin")
                Response.Redirect("~/login.aspx");
            Load_Tables();
        }
        void Load_Tables()
        {
            MySqlConnection con = new MySqlConnection(login.connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM orders;", con);
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
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}