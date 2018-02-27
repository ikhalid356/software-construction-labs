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
            SetInitialRow();
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

        private void SetInitialRow()

        {
            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("ID", typeof(string)));

            dt.Columns.Add(new DataColumn("Item", typeof(string)));

            dt.Columns.Add(new DataColumn("Price", typeof(string)));

            dr = dt.NewRow();

            dr["ID"] = 1;

            dr["Item"] = string.Empty;

            dr["Price"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();

            //Store the DataTable in ViewState

            ViewState["CurrentTable"] = dt;

            GridView2.DataSource = dt;

            GridView2.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fID = GridView1.SelectedRow.Cells[0].Text;
            string fName = GridView1.SelectedRow.Cells[1].Text;
            string fPrice = GridView1.SelectedRow.Cells[2].Text;
            //Label1.Text = "<b>Item:  &nbsp;:&nbsp;&nbsp;   " + fName + "</b>";
            /* DataTable dt = new DataTable();

             DataRow dr = null;

             dt.Columns.Add(new DataColumn("ID", typeof(string)));

             dt.Columns.Add(new DataColumn("Item", typeof(string)));

             dt.Columns.Add(new DataColumn("Price", typeof(string)));

             dr = dt.NewRow();

             dr["ID"] = fID;

             dr["Item"] = fName;

             dr["Price"] = fPrice;

             dt.Rows.Add(dr);

             //dr = dt.NewRow();

             //Store the DataTable in ViewState

             ViewState["CurrentTable"] = dt;

             GridView2.DataSource = dt;

             GridView2.DataBind();*/

            int rowIndex = 0;



           
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)

                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)

                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("TextBox2");
   
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["ID"] = i + 1;


                        dtCurrentTable.Rows[i - 1]["Item"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Price"] = box2.Text;
                    
                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;



                    GridView2.DataSource = dtCurrentTable;

                    GridView2.DataBind();

                }

            

            
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}