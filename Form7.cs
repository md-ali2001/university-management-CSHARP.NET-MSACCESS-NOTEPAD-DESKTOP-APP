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
    public partial class Form7 : Form
    {
        
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            

            string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,DEPARTMENT,FEE FROM registration";

            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void m5(object sender, MouseEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox2.Text);
            n=n+60000;
            textBox2.Text = n.ToString();
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "UPDATE registration SET FEE ='" + textBox2.Text + "' WHERE ROLL='" + textBox1.Text + "'";

            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            MessageBox.Show("success");
            string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,DEPARTMENT,FEE FROM registration";

            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
