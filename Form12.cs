using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace universitymanagementsystem
{
    public partial class Form12 : Form
    {
        
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            

            
            OleDbCommand commandRowCount = new OleDbCommand("SELECT COUNT(*) FROM [registration]", Program.con);
            int countStart = System.Convert.ToInt32(commandRowCount.ExecuteScalar());


            label4.Text = countStart.ToString();
            OleDbCommand commandRowCount2 = new OleDbCommand("SELECT COUNT(*) FROM [department]", Program.con);
            int countStart2 = System.Convert.ToInt32(commandRowCount2.ExecuteScalar());


            label7.Text = countStart2.ToString();
            OleDbCommand commandRowCount3 = new OleDbCommand("SELECT COUNT(*) FROM [teach]", Program.con);
            int countStart3 = System.Convert.ToInt32(commandRowCount3.ExecuteScalar());


            label5.Text = countStart3.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
    }
}
