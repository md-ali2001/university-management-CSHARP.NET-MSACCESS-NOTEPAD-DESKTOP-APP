using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace universitymanagementsystem
{
  
    static class Program
    {
        public static string email;
        public static string pass;
        public static string dept;
        //public static string con;
        public static OleDbConnection  con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ma\source\repos\university-management-CSHARP.NET-MSACCESS-NOTEPAD-DESKTOP-APP\connection.accdb");
        //public static OleDbConnection con2 = new OleDbConnection(universitymanagementsystem.Properties.Settings.Default.TestSetting);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            con.Open();
            //con2.Open();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
