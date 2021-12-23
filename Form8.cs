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
    public partial class Form8 : Form
    {
        
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            

            string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,DEPARTMENT,PRESENTS,ABSENTS,PRESENTPERCENT FROM registration";

            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void m6(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "UPDATE registration SET PRESENTS ='" + textBox2.Text + "',ABSENTS='" + textBox4.Text + "' WHERE ROLL='" + textBox1.Text + "'";
            textBox7.Text = dataGridView1.Rows[0].Cells[6].Value + string.Empty;


            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            //textBox7.Text = dataGridView1.Rows[0].Cells[6].Value + string.Empty;
            MessageBox.Show("success");

            string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,DEPARTMENT,PRESENTS,ABSENTS,PRESENTPERCENT FROM registration";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            textBox7.Text = dataGridView1.Rows[0].Cells[6].Value + string.Empty;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n=Convert.ToInt32(textBox2.Text);
            
            n++;
            textBox2.Text = n.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox4.Text);

            n++;
            textBox4.Text = n.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
    }
}
