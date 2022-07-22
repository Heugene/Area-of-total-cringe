using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace StudentsViewProgram
{
    public partial class Form2 : Form
    {
        public DataGridView DTView;
        public DataSet dsStud;
        public OleDbDataAdapter adStud;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int N = DTView.Rows.Count;
            DTView.Rows.Add(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), textBox3.Text, dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            DTView.Rows[N].HeaderCell.Value = (N + 1).ToString();
            dsStud.Tables[0].Rows.Add(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), textBox3.Text, dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            adStud.Update(dsStud.Tables[0]);
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 5; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            comboBox1.SelectedItem = comboBox1.Items[0];
        }
    }
}
