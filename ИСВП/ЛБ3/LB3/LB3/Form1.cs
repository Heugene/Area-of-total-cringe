using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            radioButton1.Checked = true;
            checkBox1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result;
            if (Int32.TryParse(textBox1.Text, out result))
            {
                listBox1.Items.Add(result);
            }
            else
            {
                MessageBox.Show("Некорректный ввод", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (MessageBox.Show("Удалить элемент?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("Не выбран элемент для удаления", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Расчитать выражение?","Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
                return;
            double a, b, c = 0;
            a = Convert.ToDouble(numericUpDown1.Value);
            b = Convert.ToDouble(listBox1.Text);

            if (radioButton1.Checked)
            { c = a + b; }
            else if (radioButton2.Checked)
            { c = a - b; }
            else if (radioButton3.Checked)
            { c = a * b; }
            else if (radioButton4.Checked)
            { c = a / b; }

            if (checkBox1.Checked)
            { MessageBox.Show(Convert.ToString(c)); }
            if (checkBox2.Checked)
            {
                Form2 form2 = new Form2();
                form2.label1.Text = "Ответ: " + Convert.ToString(c);
                form2.Show();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.ReadOnly = !checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox4.Checked;
        }


    }
}
