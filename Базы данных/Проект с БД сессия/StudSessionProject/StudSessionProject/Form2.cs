using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudSessionProject
{
    public partial class Form2 : Form
    {
        private string user_mode;
        private string type_of_content;
        public string User_Mode
        {
            get
            { return this.user_mode; }
            set
            { this.user_mode = value; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Студенты");
            comboBox1.Items.Add("Дисциплины");

            radioButton1.Checked = true;
            comboBox2.Enabled = false;
            this.type_of_content = "Tables";
            comboBox1.SelectedItem = comboBox1.Items[0];

            switch (User_Mode)
            {
                case "TEST_MODE":
                    {
                        label1.Text = "Тестовый режим";
                    }
                    break;
                case "BASIC_MODE":
                    {
                        label1.Text = "Базовый режим";
                    }
                    break;
                case "ADMIN_MODE":
                    {
                        label1.Text = "Режим администратора";
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e) // выходим в самое начало на выбор режимов
        {
            Hide();
            Application.OpenForms[0].Show();
            Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) 
            {
                comboBox2.Enabled = false;
                comboBox1.Enabled = true;
                this.type_of_content = "Tables";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = true;
                this.type_of_content = "Queries";
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e) //выводим контент
        {
            if (this.type_of_content == "Tables")
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            Form3 form3 = new Form3();
                            form3.User_Mode = this.user_mode;
                            form3.ShowDialog();
                        }
                    break;
                    case 1:
                        {
                            Form5 form5 = new Form5();
                            form5.User_Mode = this.user_mode;
                            form5.ShowDialog();
                        }
                    break;
                }
            }
            else if (this.type_of_content == "Queries")
            {

            }
        }
    }
}
