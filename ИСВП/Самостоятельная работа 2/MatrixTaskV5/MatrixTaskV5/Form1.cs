using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixTaskV5
{
    public partial class Form1 : Form
    {
        int[,] MatrixA = new int[5, 5]; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.TopLeftHeaderCell.Value = "№";
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r1 = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //Забавно в одном и том же цикле заполнять матрицу, из которой тут же переносить элементы в датагрид
                    MatrixA[i, j] = r1.Next(-100, 100);
                    dataGridView1.Rows[i].Cells[j].Value = MatrixA[i, j];
                }
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte N = 0;

            for (int i = 0; i < 5; i++)
            {
                if (MatrixA[i, 4] > 0)
                {
                    N++;
                }
            }
            if (N < 3)
                //выводим все положительные элементы матрицы
            {
                string Output = "";
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (MatrixA[i, j] > 0)
                        {
                            Output = Output + MatrixA[i, j].ToString() + ", ";
                        }
                    }
                }
                Output = Output.Remove(Output.Length-2);
                MessageBox.Show("Положительные элементы матрицы: " + Output);
            }  
            else
                //выводим сумму элементов главной диагонали
            {
                int Sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    Sum = Sum + MatrixA[i, i];
                }
                MessageBox.Show("Сумма элементов главной диагонали: " + Sum.ToString());
            }
        }
    }
}
