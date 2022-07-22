using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Text = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Text = textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Text = textBox3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Text = textBox4.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Text = "Totally useless app";
        }


    }
}
