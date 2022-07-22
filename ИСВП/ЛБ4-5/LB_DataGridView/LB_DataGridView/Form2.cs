using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB_DataGridView
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            double mark;
            if (double.TryParse(textBox6.Text, out mark))
            {
                if (mark >= 2 && mark <= 5)
                {
                    return;
                }
                else
                {
                    textBox6.Clear();
                }
            }
            else
            {
                textBox6.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int n = (Application.OpenForms[0] as Form1).DT.Rows.Count;
            (Application.OpenForms[0] as Form1).DT.Rows.Add();
            (Application.OpenForms[0] as Form1).DT.Rows[n].HeaderCell.Value = (n + 1).ToString();

            (Application.OpenForms[0] as Form1).DT.Rows[n].Cells[0].Value = textBox1.Text;
            (Application.OpenForms[0] as Form1).DT.Rows[n].Cells[1].Value = textBox2.Text;
            (Application.OpenForms[0] as Form1).DT.Rows[n].Cells[2].Value = textBox3.Text;
            (Application.OpenForms[0] as Form1).DT.Rows[n].Cells[3].Value = textBox4.Text;
            (Application.OpenForms[0] as Form1).DT.Rows[n].Cells[4].Value = textBox5.Text;
            (Application.OpenForms[0] as Form1).DT.Rows[n].Cells[5].Value = textBox6.Text;

            (Application.OpenForms[0] as Form1).DT = (Application.OpenForms[0] as Form1).DT;
            Close();
        }
    }
}
