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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) // тестовый режим. Будет активно использоваться в процессе разработки. Может давать даже больше возможностей, чем режим администратора.
        {
            Form2 form2 = new Form2();
            form2.User_Mode = "TEST_MODE";
            form2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e) // пользовательский режим без особых привелегий
        {
            Form2 form2 = new Form2();
            form2.User_Mode = "BASIC_MODE";
            form2.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) // режим администратора. может потом добавлю поле ввода пароля, например.
        {
            Form2 form2 = new Form2();
            form2.User_Mode = "ADMIN_MODE";
            form2.Show();
            Hide();
        }
    }
}
