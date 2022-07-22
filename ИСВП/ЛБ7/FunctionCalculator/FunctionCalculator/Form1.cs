using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FunctionCalculator
{
    public partial class Form1 : Form
    {
        double a, b, h;
        public Form1()
        {
            InitializeComponent();
        }

        public double Task_Function(double x)
        {
            double y;
            try
            {
                y = 1 / (x + 7) + Math.Log((1 - Math.Abs(x)), Math.E);
            }
            catch
            {
                y = -1000000;
            }
                return y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.a = Convert.ToDouble(numericUpDown1.Value);
            this.b = Convert.ToDouble(numericUpDown2.Value);
            this.h = Convert.ToDouble(numericUpDown3.Value);

            if (b < a)
            {
                MessageBox.Show("Значение конца диапазона не может быть меньше значения его начала!","Ошибка ввода данных!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Focus();
                return;
            }

            if (h <= 0)
            {
                MessageBox.Show("Шаг не может быть равным или меньшим 0", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown3.Focus();
                return;
            }

            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Очистить поле результата?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    textBox1.Clear();
                }
            }
            textBox1.AppendText("Табулирование функции" + Environment.NewLine);
            textBox1.AppendText("=====================" + Environment.NewLine);
            textBox1.AppendText("    X     |     Y    " + Environment.NewLine);
            textBox1.AppendText("=====================" + Environment.NewLine);

            double i = a;

            while (i <= b)
            {
                //textBox1.AppendText(String.Format(" {0,4:f1} | {1,6:f3} ", i, Math.Sin(4*i)) + Environment.NewLine);


                if (Task_Function(i) != -1000000)
                {
                    textBox1.AppendText(String.Format(" {0,4:f1} | {1,6:f3} ", i, Task_Function(i)) + Environment.NewLine);
                }
                else
                {
                    textBox1.AppendText(String.Format(" {0,4:f1} | {1,6} ", i, "---") + Environment.NewLine);
                }
                i+=h;
            }
            textBox1.AppendText("=====================" + Environment.NewLine);
            textBox1.Modified = true;

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Lines.Length >= 17)
            {
                textBox1.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                textBox1.ScrollBars = ScrollBars.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовые файлы|*.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.OverwritePrompt = false;

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (File.Exists(saveFileDialog1.FileName))
            {
                if (MessageBox.Show("Дописать данные в файл?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.AppendAllLines(saveFileDialog1.FileName, textBox1.Lines);
                }
                else
                {
                    File.WriteAllLines(saveFileDialog1.FileName, textBox1.Lines);
                }
            }
            else 
            {
                File.WriteAllLines(saveFileDialog1.FileName, textBox1.Lines);
            }

            textBox1.Modified = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Файлы HTML|*.html";
            saveFileDialog1.DefaultExt = "html";
            saveFileDialog1.OverwritePrompt = true;

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            StreamWriter html_wr = new StreamWriter(saveFileDialog1.FileName, false);
            html_wr.WriteLine("<head>");
            html_wr.WriteLine("<title>Табулирование функции</title>");
            html_wr.WriteLine("<meta charset=utf-8>");
            html_wr.WriteLine("</head>");
            html_wr.WriteLine("<h2 align=center>Табулирование функции</h2>");
            html_wr.WriteLine("<table border=1 width=30% align=center>");
            html_wr.WriteLine("<th width=50%>X</td>");
            html_wr.WriteLine("<th>Y<th>");

            while(a <= b)
            {
                html_wr.WriteLine("<tr>");
                html_wr.WriteLine("<td align=center>" + Math.Round(a, 1).ToString() + "</td>");
                //html_wr.WriteLine("<td align=center>" + Math.Round(Math.Sin(4*a), 3).ToString() + "</td>");

                if (Task_Function(a) != -1000000)
                {
                    html_wr.WriteLine("<td align=center>" + Math.Round(Task_Function(a), 3).ToString() + "</td>");
                }
                else
                {
                    html_wr.WriteLine("<td align=center>" + "---" + "</td>");
                }
                html_wr.WriteLine("</tr>");
                a = a + h;
            }

            html_wr.WriteLine("</table>");
            html_wr.WriteLine("</body>");

            html_wr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистить поле результата?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBox1.Clear();
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                numericUpDown1.Focus();
                textBox1.Modified = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Данные не сохранены. Сохранить?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button2_Click(sender, e);
            }
        }
    }
}
