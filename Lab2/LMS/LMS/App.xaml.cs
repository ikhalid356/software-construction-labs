using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string connectionString = "server=localhost;user id=root;password=1234;persistsecurityinfo=True;database=lms";
        public static string userID = "";
    }
}
