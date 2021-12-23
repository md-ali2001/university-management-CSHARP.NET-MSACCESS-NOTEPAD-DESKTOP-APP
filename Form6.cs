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
using System.IO; 

namespace universitymanagementsystem
{
    public partial class Form6 : Form
    {
        
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            

            string selectCommand = "SELECT IDT,Yr,DEPT,EVENT_NAME,EVENT_DATE,DURATION FROM events";
            
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "INSERT INTO events(IDT,Yr,DEPT,EVENT_NAME,EVENT_DATE,DURATION)VALUES('"+textBox1.Text+"','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','"+comboBox1.SelectedItem.ToString()+"')";

            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            MessageBox.Show("success");
            string selectCommand = "SELECT IDT,Yr,DEPT,EVENT_NAME,EVENT_DATE,DURATION FROM events";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "UPDATE events SET Yr ='" + comboBox2.SelectedItem.ToString() + "',DEPT='" + comboBox3.SelectedItem.ToString() + "',EVENT_NAME='" + textBox4.Text + "',EVENT_DATE='" + dateTimePicker1.Text + "',DURATION='" + comboBox1.SelectedItem.ToString() + "'WHERE IDT='"+textBox1.Text+"'";

            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            MessageBox.Show("success");
            string selectCommand = "SELECT IDT,Yr,DEPT,EVENT_NAME,EVENT_DATE,DURATION FROM events";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void m4(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = Microsoft.VisualBasic.Interaction.InputBox("ENTER ID");
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM events WHERE IDT='" + id + "'";
            int i=cmd.ExecuteNonQuery();
            if (i == 0)
                MessageBox.Show("RECORD NOT FOUND");
            else
                MessageBox.Show("SUCCESSFULLY DELETED THE RECORD OF THIS EVENT");
           
            string selectCommand = "SELECT IDT,Yr,DEPT,EVENT_NAME,EVENT_DATE,DURATION FROM events";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\masood\\Desktop\\this.txt"))
            {
                sw.WriteLine(textBox2.Text);
                MessageBox.Show("NOTICE HAS BEEN SAVED");
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (StreamReader streamReader = new StreamReader("C:\\Users\\masood\\Desktop\\this.txt"))
            {
                textBox2.Text = streamReader.ReadToEnd();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

      
    }
}
