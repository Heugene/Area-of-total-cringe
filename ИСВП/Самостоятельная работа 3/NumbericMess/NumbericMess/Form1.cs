using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumbericMess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < richTextBox1.Lines.Count()-1; i++)
            {
                sum = sum + Convert.ToDouble(richTextBox1.Lines[i]);
            }

            double RB_val = 0;
            if (radioButton1.Checked)
            {
                RB_val = Convert.ToDouble(radioButton1.Text);
            }
            if (radioButton2.Checked)
            {
                RB_val = Convert.ToDouble(radioButton2.Text);
            }

            double CB_val = 0;
            if (checkBox1.Checked)
            {
                CB_val = Convert.ToDouble(checkBox1.Text);
            }
            sum = sum + Convert.ToDouble(comboBox1.SelectedItem);
            sum = sum + Convert.ToDouble(listBox1.SelectedItem);
            sum = sum + Convert.ToDouble(maskedTextBox1.Text);
            sum = sum + Convert.ToDouble(textBox1.Text);
            sum = sum + Convert.ToDouble(numericUpDown1.Value);
            sum = sum + RB_val + CB_val;
            MessageBox.Show("Сумма = " + sum.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r1 = new Random();

            for (int i = r1.Next(1, 6); i >=0; i--)
            {
                comboBox1.Items.Add(r1.Next(-100, 100));
            }
            comboBox1.SelectedIndex = 0;

            for (int i = r1.Next(1, 8); i >= 0; i--)
            {
                listBox1.Items.Add(r1.Next(-10000, 10000));
            }
            listBox1.SelectedIndex = 0;

            for (int i = r1.Next(1, 7); i >= 0; i--)
            {
                richTextBox1.AppendText(r1.Next(-10000, 10000).ToString() + "\n");
            }

            maskedTextBox1.Text = r1.Next(-283, 2093).ToString();
            textBox1.Text = r1.Next(-123, 238).ToString();

            radioButton1.Text = r1.Next(-1000, 1000).ToString();
            radioButton2.Text = r1.Next(-1000, 1000).ToString();

            checkBox1.Text = r1.Next(-1000, 1000).ToString();
            
        }
    }
}
