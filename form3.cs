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
    public partial class form3 : Form
    {
        
        




        public form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;




           
                        


                        cmd.CommandText = "INSERT INTO registration(STUDENT_NAME,SEMESTER,ROLL,BIRTH,GENDER,DEPARTMENT,UNIVERSITY_EM,  PW, PHONE)VALUES('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + textBox4.Text + "','" + textBox7.Text + "','" + textBox2.Text + "')";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("SUCCESSFULLY ADDED ONE STUDENT");
                        string dept = comboBox3.SelectedItem.ToString();
                        string selectCommandt = "SELECT DEPT_NAME,STUDENTS FROM department WHERE DEPT_NAME='" + dept + "' ";
                        OleDbDataAdapter adaptert = new OleDbDataAdapter(selectCommandt, Program.con);
                        OleDbCommandBuilder cmdt = new OleDbCommandBuilder(adaptert);
                        DataTable tablet = new DataTable();
                        adaptert.Fill(tablet);
                        dataGridView2.DataSource = tablet;
                        
                        string students2 = dataGridView2.Rows[0].Cells[1].Value+string.Empty;
                        int students = Convert.ToInt32(students2);
                        students++;
                        OleDbCommand cmdw = Program.con.CreateCommand();
                        cmdw.CommandType = CommandType.Text;


                        cmdw.CommandText = "UPDATE department SET STUDENTS ='" + students + "' WHERE DEPT_NAME='" + dept + "'";
                        cmdw.ExecuteNonQuery();
                  
            
           














            
            






                string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,BIRTH,GENDER,DEPARTMENT,UNIVERSITY_EM,PW,PHONE FROM registration";
                OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
                OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                

            
            
            
        }

        private void form3_Load(object sender, EventArgs e)
        {
            
            

            string selectCommand = "SELECT ROLL,STUDENT_NAME,SEMESTER,BIRTH,GENDER,DEPARTMENT,UNIVERSITY_EM,PW,PHONE FROM registration";
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
                
                string roll = Microsoft.VisualBasic.Interaction.InputBox("ENTER ROLL NUMBER");
                string selectCommandtdvf = "SELECT DEPARTMENT FROM registration WHERE ROLL='" + roll + "' ";
                OleDbDataAdapter adaptertdvf = new OleDbDataAdapter(selectCommandtdvf, Program.con);
                OleDbCommandBuilder cmdtdvf = new OleDbCommandBuilder(adaptertdvf);
                DataTable tabletdf = new DataTable();
                adaptertdvf.Fill(tabletdf);
                dataGridView2.DataSource = tabletdf;
                string deptofdeletingstudent = dataGridView2.Rows[0].Cells[0].Value + string.Empty;
                string selectCommandtdv = "SELECT STUDENTS FROM department WHERE DEPT_NAME='" + deptofdeletingstudent + "' ";
                OleDbDataAdapter adaptertdv = new OleDbDataAdapter(selectCommandtdv, Program.con);
                OleDbCommandBuilder cmdtdv = new OleDbCommandBuilder(adaptertdv);
                DataTable tabletd = new DataTable();
                adaptertdv.Fill(tabletd);
                dataGridView2.DataSource = tabletd;
                string students2 = dataGridView2.Rows[0].Cells[0].Value + string.Empty;
                
                int students = Convert.ToInt32(students2);
                students--;
                OleDbCommand cmdw = Program.con.CreateCommand();
                cmdw.CommandType = CommandType.Text;


                cmdw.CommandText = "UPDATE department SET STUDENTS ='" + students + "' WHERE DEPT_NAME='" + deptofdeletingstudent + "'";
                cmdw.ExecuteNonQuery();
                OleDbCommand cmdq = Program.con.CreateCommand();

                cmdq.CommandType = CommandType.Text;
                cmdq.CommandText = "DELETE FROM registration WHERE ROLL='" + roll + "'";
                int i = cmdq.ExecuteNonQuery();




               
               

                
            


                
               
                if (i == 0)
                    MessageBox.Show("RECORD NOT FOUND");
                else
                    MessageBox.Show("SUCCESSFULLY DELETED THE RECORD OF THIS STUDENT");
                    
                    string selectCommand = "SELECT * FROM registration";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
                    OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;



            }
            catch(Exception cmd)
            {
               
            }






        }
        //done above code
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = Program.con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "UPDATE registration SET STUDENT_NAME ='"+textBox1.Text+"',SEMESTER='"+comboBox1.SelectedItem.ToString()+"',BIRTH='"+dateTimePicker1.Text+"',GENDER='"+comboBox2.SelectedItem.ToString()+"',DEPARTMENT='"+comboBox3.SelectedItem.ToString()+"',UNIVERSITY_EM='"+textBox4.Text+"',PW='"+textBox7.Text+"',PHONE='"+textBox2.Text+"' WHERE ROLL='"+textBox3.Text+"'";
               
            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);+
            cmd.ExecuteNonQuery();
            MessageBox.Show("success");
            string selectCommand = "SELECT * FROM registration";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            MessageBox.Show("SUCCESSFULLY EDITED THE RECORD OF THIS STUDENT");



            


        }

        private void m(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
               // dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value + string.Empty;
                // string userId = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;

                //textBox1.Text = jobId;
                //textBox.Text = userId;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
    }
}
//
//