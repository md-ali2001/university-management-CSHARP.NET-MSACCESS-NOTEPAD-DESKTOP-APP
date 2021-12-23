using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace universitymanagementsystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            new Form8().Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Form12().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new form3().Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            new Form9().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Form6().Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            new Form7().Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            new Form10().Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();

        }
    }
}
