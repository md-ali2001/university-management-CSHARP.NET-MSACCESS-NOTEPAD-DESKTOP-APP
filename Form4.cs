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
    public partial class Form4 : Form
    {
       
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {


                        OleDbCommand cmd = Program.con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO teach(IDT,TEACHER_NAME,BIRTH,GENDER,DEPT,SEMESTER,SUBJECT,ADDRESS,PHONE)VALUES('" + textBox1.Text + "','" + textBox6.Text + "','" + dateTimePicker2.Text + "','" + comboBox4.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "')";
                        cmd.ExecuteNonQuery();
                        string dept = comboBox3.SelectedItem.ToString();
                        string selectCommandt = "SELECT DEPT_NAME,TEACHERS FROM department WHERE DEPT_NAME='" + dept + "' ";
                        OleDbDataAdapter adaptert = new OleDbDataAdapter(selectCommandt, Program.con);
                        OleDbCommandBuilder cmdt = new OleDbCommandBuilder(adaptert);
                        DataTable tablet = new DataTable();
                        adaptert.Fill(tablet);
                        dataGridView2.DataSource = tablet;
                        string teachers2 = dataGridView2.Rows[0].Cells[1].Value + string.Empty;
                        int teachers = Convert.ToInt32(teachers2);
                        teachers++;
                        OleDbCommand cmdw = Program.con.CreateCommand();
                        cmdw.CommandType = CommandType.Text;


                        cmdw.CommandText = "UPDATE department SET TEACHERS ='" + teachers + "' WHERE DEPT_NAME='" + dept + "'";
                        cmdw.ExecuteNonQuery();
                        MessageBox.Show("success");
                    
            




            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            





            string selectCommand = "SELECT * FROM teach";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            

            string selectCommand = "SELECT * FROM teach";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string id = Microsoft.VisualBasic.Interaction.InputBox("ENTER ID");
                string selectCommandtdvf = "SELECT DEPT FROM teach WHERE IDT='" + id + "' ";
                OleDbDataAdapter adaptertdvf = new OleDbDataAdapter(selectCommandtdvf, Program.con);
                OleDbCommandBuilder cmdtdvf = new OleDbCommandBuilder(adaptertdvf);
                DataTable tabletdf = new DataTable();
                adaptertdvf.Fill(tabletdf);
                dataGridView2.DataSource = tabletdf;
                string deptofdeletingteacher = dataGridView2.Rows[0].Cells[0].Value + string.Empty;

                string selectCommandtdv = "SELECT TEACHERS FROM department WHERE DEPT_NAME='" + deptofdeletingteacher + "' ";
                OleDbDataAdapter adaptertdv = new OleDbDataAdapter(selectCommandtdv, Program.con);
                OleDbCommandBuilder cmdtdv = new OleDbCommandBuilder(adaptertdv);
                DataTable tabletd = new DataTable();
                adaptertdv.Fill(tabletd);
                dataGridView2.DataSource = tabletd;
                string teachers2 = dataGridView2.Rows[0].Cells[0].Value + string.Empty; 
               
                int teachers = Convert.ToInt32(teachers2);
                teachers--;
                OleDbCommand cmdw = Program.con.CreateCommand();
                cmdw.CommandType = CommandType.Text;


                cmdw.CommandText = "UPDATE department SET TEACHERS ='" + teachers + "' WHERE DEPT_NAME='" + deptofdeletingteacher + "'";
                cmdw.ExecuteNonQuery();
                OleDbCommand cmdq = Program.con.CreateCommand();

                cmdq.CommandType = CommandType.Text;
                cmdq.CommandText = "DELETE FROM teach WHERE IDT='" + id + "'";
                int i = cmdq.ExecuteNonQuery();













                if (i == 0)
                    MessageBox.Show("RECORD NOT FOUND");
                else
                    MessageBox.Show("SUCCESSFULLY DELETED THE RECORD OF THIS TEACHER");

                string selectCommand = "SELECT * FROM teach";
                OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
                OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;



            }
            catch (Exception cmd)
            {

            }

        }

        private void m2(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;

                comboBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;

                textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value + string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "UPDATE teach SET TEACHER_NAME ='" + textBox6.Text + "',BIRTH='" + dateTimePicker2.Text + "',GENDER='" + comboBox4.SelectedItem.ToString() + "',DEPT='" + comboBox3.SelectedItem.ToString() + "',SEMESTER='" + comboBox1.SelectedItem.ToString() + "',SUBJECT='" + textBox4.Text + "',ADDRESS='" + textBox5.Text + "',PHONE='" + textBox2.Text + "' WHERE IDT='" + textBox1.Text + "'";
           
            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            MessageBox.Show("success");
            string selectCommand = "SELECT * FROM teach";
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

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
