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

    public partial class Form13 : Form
    {


       
        public Form13()
        {











            InitializeComponent();

        }

        private void Form13_Load(object sender, EventArgs e)
        {

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void Form13_Load_1(object sender, EventArgs e)
        {


            
            




            string selectCommand2 = "select * from registration where UNIVERSITY_EM='" + Program.email + "'  and PW='" + Program.pass + "'    ";
            OleDbDataAdapter adapter2 = new OleDbDataAdapter(selectCommand2, Program.con);
            OleDbCommandBuilder cmd3 = new OleDbCommandBuilder(adapter2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView4.DataSource = table2;
            textBox1.Text = dataGridView4.Rows[0].Cells[1].Value + string.Empty;
            textBox7.Text = dataGridView4.Rows[0].Cells[0].Value + string.Empty;
            textBox5.Text = dataGridView4.Rows[0].Cells[5].Value + string.Empty;
            textBox6.Text = dataGridView4.Rows[0].Cells[2].Value + string.Empty;
            textBox3.Text = dataGridView4.Rows[0].Cells[14].Value + string.Empty;
            textBox4.Text = dataGridView4.Rows[0].Cells[9].Value + string.Empty;
            textBox8.Text = dataGridView4.Rows[0].Cells[11].Value + string.Empty;
            textBox9.Text = dataGridView4.Rows[0].Cells[8].Value + string.Empty;
            textBox11.Text = dataGridView4.Rows[0].Cells[3].Value + string.Empty;


            string selectCommand = "SELECT IDT,Yr,DEPT,EVENT_NAME,EVENT_DATE,DURATION FROM events";

            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, Program.con);
            OleDbCommandBuilder cmd2 = new OleDbCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            using (StreamReader streamReader = new StreamReader("C:\\Users\\ma\\Desktop\\this.txt"))
            {
                textBox2.Text = streamReader.ReadToEnd();

            }
            double gpa = Convert.ToDouble(textBox4.Text);
            double present = Convert.ToDouble(textBox3.Text);
            int fee = Convert.ToInt32(textBox8.Text);
            string semester = textBox6.Text;


            if (semester == "FIRST")
            {
                if (fee == (60000) && present > 75 && gpa > 2)
                {
                    textBox10.Text = "AVAILABLE FOR UPCOMING EXAMS";



                }
                else
                    textBox10.Text = "NOT AVAILABLE FOR UPCOMING EXAMS";


            }
            else if (semester == "SECOND")
            {
                if (fee == (60000 * 2) && present > 75 && gpa > 2)
                {

                    textBox10.Text = "AVAILABLE FOR UPCOMING EXAMS";


                }
                else
                    textBox10.Text = "NOT AVAILABLE FOR UPCOMING EXAMS";


            }
            else if (semester == "THIRD")
            {
                if (fee == (60000 * 3) && present > 75 && gpa > 2)
                {
                    textBox10.Text = "AVAILABLE FOR UPCOMING EXAMS";


                }
                else
                    textBox10.Text = "NOT AVAILABLE FOR UPCOMING EXAMS";


            }
            else if (semester == "FOURTH")
            {
                if (fee == (60000 * 4) && present > 75 && gpa > 2)
                {
                    textBox10.Text = "AVAILABLE FOR UPCOMING EXAMS";


                }
                else
                    textBox10.Text = "NOT AVAILABLE FOR UPCOMING EXAMS";


            }
            else if (semester == "FIFTH")
            {
                if (fee == (60000 * 5) && present > 75 && gpa > 2)
                {
                    textBox10.Text = "AVAILABLE FOR UPCOMING EXAMS";


                }
                else
                    textBox10.Text = "NOT AVAILABLE FOR UPCOMING EXAMS";


            }
            else if (semester == "SIXTH")
            {
                if (fee == (60000 * 6) && present > 75 && gpa > 2)
                {

                    textBox10.Text = "AVAILABLE FOR UPCOMING EXAMS";

                }
                else
                    textBox10.Text = "NOT AVAILABLE FOR UPCOMING EXAMS";


            }
            else if (semester == "SEVENTH")
            {
                if (fee == (60000 * 7) && present > 75 && gpa > 2)
                {

                    textBox10.Text = "AVAILABLE FOR UPCOMING EXAMS";

                }
                else
                    textBox10.Text = "NOT AVAILABLE FOR UPCOMING EXAMS";


            }
            else if (semester == "EIGHTH")
            {
                if (fee == (60000 * 8) && present > 75 && gpa > 2)
                {

                    textBox10.Text = "AVAILABLE FOR UPCOMING EXAMS";

                }
                else
                    textBox10.Text = "NOT AVAILABLE FOR UPCOMING EXAMS";



            }
            string selectCommand3 = "select * from ISSUED where ROLL='" + textBox7.Text + "'     ";
            OleDbDataAdapter adapter3 = new OleDbDataAdapter(selectCommand3, Program.con);
            OleDbCommandBuilder cmd4 = new OleDbCommandBuilder(adapter3);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            dataGridView2.DataSource = table3;
            string selectCommand4 = "select * from RETURNED where ROLL='" + textBox7.Text + "'     ";
            OleDbDataAdapter adapter4 = new OleDbDataAdapter(selectCommand4, Program.con);
            OleDbCommandBuilder cmd5 = new OleDbCommandBuilder(adapter4);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            dataGridView3.DataSource = table4;


        }
    }
}
