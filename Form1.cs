using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Data.OleDb;
// label5     timer counting show label

namespace universitymanagementsystem
{
    public partial class Form1 : Form
    {
       
        
        int i = 0;
        int k = 1;
        int s = 0;
        int j;
        /*int i2 = 0;
        int k2 = 1;
        int s2 = 0;
        int j2;
        int h = 0;*/
      
        public Form1()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            i = i + 15000;
           // i = i * k;
            int j = i / 1000;
           // k++;
            if (textBox1.Text == "ned.csit" && textBox2.Text == "ned7538")
            {

                new Form2().Show();
                this.Hide();
                MessageBox.Show("YOU ARE LOGGED IN");
            }

            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
                MessageBox.Show("INCORRECT CREDENTIALS");
                MessageBox.Show("CLICK OK AND WAIT FOR " + j + " SECONDS");
                textBox1.Hide();
                textBox2.Hide();
                button1.Hide();
                button2.Hide();
                button4.Hide();
                button3.Hide();

                var seconds = i;
                timer1.Start();


            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Thread.Sleep(1000);

            label5.Text = (s + 1).ToString();
            s++;
            if ((s - 1) == i / 1000)
            {
                timer1.Stop();
                s = 0;
                label5.Text = " ";
                textBox1.Show();
                textBox2.Show();
                button1.Show();
                button2.Show();
                button4.Show();
                button3.Show();
            }
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                button3.Show();
                button5.Hide();
                textBox2.UseSystemPasswordChar = false;
            }
            
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == false)
            {
                button5.Show();
                button3.Hide();
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                    
            OleDbCommand cmd = Program.con.CreateCommand();
            


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from registration where UNIVERSITY_EM='" + textBox1.Text + "'and PW='" + textBox2.Text + "'        ";
            OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
           

            int count = 0;
            while (reader.Read())
            {
             

                count++;
            }
            if (count>0)
            {

                Program.email = textBox1.Text;
                Program.pass = textBox2.Text;

                Form13 F = new Form13();
                F.Show();
                this.Hide();
                
                
                
            }
           
            else
            {

                i = i + 15000;
                //i = i * k;
                int j = i / 1000;
                //k++;
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
                MessageBox.Show("INCORRECT CREDENTIALS");
                MessageBox.Show("CLICK OK AND WAIT FOR " + j + " SECONDS");
                textBox1.Hide();
                textBox2.Hide();
                button1.Hide();
                button2.Hide();
                button4.Hide();
                button3.Hide();

                
                timer1.Start();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

