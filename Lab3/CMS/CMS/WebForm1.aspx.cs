using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace CMS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }
        public static string connectionString = "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=lab2new";
        public static string userID = ""; 
    }
}
