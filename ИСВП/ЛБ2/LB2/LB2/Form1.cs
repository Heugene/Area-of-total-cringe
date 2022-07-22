using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Owner, "Are you sure you want to clear all input values","Confirm this action", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Owner, "Calclate the function?", "Confirm this action", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            double a, b, c, d, res;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            c = Convert.ToDouble(textBox3.Text);
            d = Convert.ToDouble(textBox4.Text);

            res = (7 + Math.Exp(Math.Sqrt(a) + 1)) / (Math.Sqrt(Math.Pow(Math.Log(Math.Pow(b, 2) - 5), 3) - 4) + Math.Sin(Math.Pow(c, 2))) + Math.Pow(Math.Sin(d), 3 / 4);
            textBox5.Text = Convert.ToString(Math.Round(res, 3));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Owner, "Are you sure you want to close the program", "Confirm this action", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
