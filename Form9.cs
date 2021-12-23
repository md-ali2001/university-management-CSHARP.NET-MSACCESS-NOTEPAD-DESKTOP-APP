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
    public partial class Form9 : Form
    {
       
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            

            string selectCommand = "SELECT * FROM department";

            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void m10(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;

                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;

                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                

            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "UPDATE department SET STUDENTS='" + textBox3.Text + "',TEACHERS='" + textBox4.Text + "',STAFF_MEMBERS='" + textBox2.Text + "',COMPUTER_LABS='" + comboBox3.SelectedItem.ToString() + "',DURATION='" + comboBox1.SelectedItem.ToString() + "',SECTIONS_IN_EACH_YEAR='" + comboBox2.SelectedItem.ToString() + "'WHERE DEPT_NAME='"+textBox1.Text+"'";

            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            MessageBox.Show("success");
            string selectCommand = "SELECT * FROM department";
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
    }
}
