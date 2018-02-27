using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CMS
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(WebForm1.connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM food"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            da.SelectCommand = cmd;
                            using (DataTable dt1 = new DataTable())
                            {
                                da.Fill(dt1);
                                da.Dispose();
                                cmd.Dispose();
                                GridView1.DataSource = dt1;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

            }

            catch (Exception exp)
            {

                //Err.Text = "No artifact of this author exists!";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fName = GridView1.SelectedRow.Cells[1].Text;
            Label1.Text = "<b>Item:  &nbsp;:&nbsp;&nbsp;   " + fName + "</b>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Order.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}