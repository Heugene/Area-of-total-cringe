using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int A; //size
            int CellH = 22;
            int CellW = 30;
            int FHCount = 8;
            int FWCount = 11;
            int MaxSize = 20;
            if (int.TryParse(textBox1.Text, out A))
            {
                dataGridView1.Width = 40 + A * CellW;
                dataGridView1.Height = 36 + A * CellH;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                Height = 270;
                Width = 620;
                if (A > MaxSize)
                {
                    A = 0;
                    textBox1.Text = "0";
                    MessageBox.Show("Заданная размерность превышает максимально установленную ("+MaxSize.ToString()+")");
                }
                if (A > FHCount)
                {
                    Height = Height + (A - FHCount) * CellH;
                }

                if (A > FWCount)
                {
                    Width = Width + (A - FWCount) * CellW;
                }
                for (int i = 0; i < A; i++)
                {
                    dataGridView1.Columns.Add(("A" + (i + 1).ToString()), (i + 1).ToString());
                    dataGridView1.Columns[i].Width = CellW;
                }

                for (int j = 0; j < A; j++)
                {
                    dataGridView1.Rows.Add();
                }
            }
            else 
            {
                textBox1.Text = "";
            }
        }
    }
}
