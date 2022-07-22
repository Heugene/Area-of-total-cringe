using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
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
            progressBar1.Value = 24;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Text = textBox2.Text;
            progressBar1.Value = 49;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Text = textBox3.Text;
            progressBar1.Value = 74;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Text = textBox4.Text;
            progressBar1.Value = 99;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Text = "Ого, вот это да";
            BackColor = Color.Red;
            progressBar1.Value = 100;
            pictureBox1.Visible = true;
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            checkBox1.Visible = true;
            pictureBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Рискни";
            textBox2.Text = "Ну давай";
            textBox3.Text = "Продемонстрируй";
            textBox4.Text = "Свои навыки";
            progressBar1.Value = 0;
            pictureBox1.Visible = false;
            checkBox1.Visible = false;
            checkBox1.Text = "Ставя тут галочку, вы соглашаетесь с тем, что вы гей";
            pictureBox2.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Text = "Я ГЕЙ";
            timer1.Enabled = true;
            timer2.Enabled = true;
            BackColor = Color.Cyan;
            progressBar1.Visible = true;
            pictureBox2.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            Environment.Exit(0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random R1 = new Random();
            progressBar1.Value = R1.Next(1,100);
        }
    }
}
