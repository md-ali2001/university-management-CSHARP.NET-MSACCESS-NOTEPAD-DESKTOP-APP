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
    public partial class Form10 : Form
    {
        int total;
        
        public Form10()
        {
            InitializeComponent();
        }
        private void Form10_Load(object sender, EventArgs e)
        {
            using (StreamReader streamReader = new StreamReader("C:\\Users\\ma\\Desktop\\count.txt"))
            {
                total = Convert.ToInt32(streamReader.ReadToEnd());
            }



            string selectCommand = "SELECT * FROM ISSUED";


            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            string selectCommand2 = "SELECT * FROM RETURNED";


            OleDbDataAdapter adapter2 = new OleDbDataAdapter(selectCommand2, Program.con);
            OleDbCommandBuilder cmd3 = new OleDbCommandBuilder(adapter2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            total--;

            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "INSERT INTO ISSUED(ROLL,STUDENT_NAME,DEPT,BOOK_NAME,AUTHOR,PUBLISHER)VALUES('" + textBox2.Text + "','" + textBox1.Text + "','" + comboBox3.SelectedItem.ToString() + "','" + textBox3.Text + "','" + textBox4.Text + "','"+textBox7.Text+"')";

            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            MessageBox.Show("success");
            string selectCommand = "SELECT * FROM ISSUED";


            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            MessageBox.Show("REMAINING BOOK ARE "+total);
            using (StreamWriter sw = new StreamWriter("C:\\Users\\ma\\Desktop\\count.txt"))
            {
                sw.WriteLine(total);
                
            }

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.CommandText = "DELETE FROM ISSUED WHERE BOOK_NAME='" + textBox3.Text + "'";
                int i=cmd.ExecuteNonQuery();
                string selectCommand = "SELECT * FROM ISSUED";


                OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
                OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                if (i != 0)
                {
                    total++;
                    MessageBox.Show("REMAINING BOOK ARE " + total);
                    using (StreamWriter sw = new StreamWriter("C:\\Users\\ma\\Desktop\\count.txt"))
                    {
                        sw.WriteLine(total);
                        
                    }




                    cmd.CommandText = "INSERT INTO RETURNED(ROLL,STUDENT_NAME,DEPT,BOOK_NAME,AUTHOR,PUBLISHER)VALUES('" + textBox2.Text + "','" + textBox1.Text + "','" + comboBox3.SelectedItem.ToString() + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox7.Text + "')";
                    cmd.ExecuteNonQuery();
                }
                else
                    MessageBox.Show("NOT FOUND IN ISSUED LIST");
                string selectCommand2 = "SELECT * FROM RETURNED";


                OleDbDataAdapter adapter2 = new OleDbDataAdapter(selectCommand2, Program.con);
                OleDbCommandBuilder cmd3 = new OleDbCommandBuilder(adapter2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                dataGridView2.DataSource = table2;


                
               
            }
            catch(Exception )
            {
                
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
    }
}
