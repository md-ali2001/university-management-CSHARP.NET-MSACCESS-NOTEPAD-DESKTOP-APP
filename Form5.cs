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
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            

            string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,DEPARTMENT,UNIVERSITY_EM,PW,GPA,TOTAL_SUBJECTS FROM registration";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            string selectCommand2 = "SELECT FEE,PRESENTPERCENT FROM registration";
            OleDbDataAdapter adapter2 = new OleDbDataAdapter(selectCommand2, Program.con);
            OleDbCommandBuilder cmd3 = new OleDbCommandBuilder(adapter2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;


        }

        private void m3(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                int C = dataGridView1.CurrentCell.RowIndex;
                
                dataGridView2.Rows[C].Selected = true;
                textBox9.Text = dataGridView2.SelectedRows[0].Cells[0].Value + string.Empty;
                textBox10.Text = dataGridView2.SelectedRows[0].Cells[1].Value + string.Empty;
                dataGridView2.Rows[C].Selected = false;
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
               


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "UPDATE registration SET GPA ='" + textBox5.Text + "',TOTAL_SUBJECTS='" + textBox2.Text + "' WHERE ROLL='" + textBox1.Text + "'";

            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            MessageBox.Show("success");
            string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,DEPARTMENT,UNIVERSITY_EM,PW,GPA,TOTAL_SUBJECTS FROM registration";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            string selectCommand2 = "SELECT FEE,PRESENTPERCENT FROM registration";
            OleDbDataAdapter adapter2 = new OleDbDataAdapter(selectCommand2, Program.con);
            OleDbCommandBuilder cmd3 = new OleDbCommandBuilder(adapter2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int fee= Convert.ToInt32(textBox9.Text);
            double present= Convert.ToDouble(textBox10.Text);
            double gpa= Convert.ToDouble(textBox5.Text);
            string semester = textBox8.Text.ToString();
            if(semester=="FIRST")
            {
                if(fee==(60000) && present>75 && gpa>2)
                {
                    textBox8.Text = "SECOND";
                    cmd.CommandText = "UPDATE registration SET SEMESTER ='" + textBox8.Text + "' WHERE ROLL='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PROMOTED");


                }
                else
                    MessageBox.Show("NOT PROMOTED");


            }
            else if (semester == "SECOND")
            {
                if (fee == (60000*2) && present > 75 && gpa > 2)
                {
                    textBox8.Text = "THIRD";
                    cmd.CommandText = "UPDATE registration SET SEMESTER ='" + textBox8.Text + "' WHERE ROLL='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PROMOTED");


                }
                else
                    MessageBox.Show("NOT PROMOTED");


            }
            else if (semester == "THIRD")
            {
                if (fee == (60000*3) && present > 75 && gpa > 2)
                {
                    textBox8.Text = "FOURTH";
                    cmd.CommandText = "UPDATE registration SET SEMESTER ='" + textBox8.Text + "' WHERE ROLL='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PROMOTED");


                }
                else
                    MessageBox.Show("NOT PROMOTED");


            }
            else if (semester == "FOURTH")
            {
                if (fee == (60000*4) && present > 75 && gpa > 2)
                {
                    textBox8.Text = "FIFTH";
                    cmd.CommandText = "UPDATE registration SET SEMESTER ='" + textBox8.Text + "' WHERE ROLL='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PROMOTED");


                }
                else
                    MessageBox.Show("NOT PROMOTED");


            }
            else if (semester == "FIFTH")
            {
                if (fee == (60000*5) && present > 75 && gpa > 2)
                {
                    textBox8.Text = "SIXTH";
                    cmd.CommandText = "UPDATE registration SET SEMESTER ='" + textBox8.Text + "' WHERE ROLL='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PROMOTED");


                }
                else
                    MessageBox.Show("NOT PROMOTED");


            }
            else if (semester == "SIXTH")
            {
                if (fee == (60000*6) && present > 75 && gpa > 2)
                {
                    textBox8.Text = "SEVENTH";
                    cmd.CommandText = "UPDATE registration SET SEMESTER ='" + textBox8.Text + "' WHERE ROLL='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PROMOTED");


                }
                else
                    MessageBox.Show("NOT PROMOTED");


            }
            else if (semester == "SEVENTH")
            {
                if (fee == (60000*7) && present > 75 && gpa > 2)
                {
                    textBox8.Text = "EIGHTH";
                    cmd.CommandText = "UPDATE registration SET SEMESTER ='" + textBox8.Text + "' WHERE ROLL='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PROMOTED");


                }
                else
                    MessageBox.Show("NOT PROMOTED");


            }
            else if (semester == "EIGHTH")
            {
                if (fee == (60000*8) && present > 75 && gpa > 2)
                {
                    textBox8.Text = "GRADUATED";
                    cmd.CommandText = "UPDATE registration SET SEMESTER ='" + textBox8.Text + "' WHERE ROLL='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PROMOTED");


                }
                else
                    MessageBox.Show("NOT PROMOTED");


            }
            MessageBox.Show("FEE : "  +textBox9.Text+" Present : "  +textBox10.Text+  "   gpa : "   +textBox5.Text);
            string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,DEPARTMENT,UNIVERSITY_EM,PW,GPA,TOTAL_SUBJECTS FROM registration";
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
