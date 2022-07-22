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

namespace StudSessionProject
{
    public partial class Form4 : Form
    {
        public DataGridView DT_View;
        public DataSet Students_DS;
        public OleDbDataAdapter Students_DA;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //добавляем
        {
            int N = DT_View.Rows.Count;
            DT_View.Rows.Add(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), textBox3.Text, dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            DT_View.Rows[N].HeaderCell.Value = (N + 1).ToString();
            Students_DS.Tables[0].Rows.Add(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), textBox3.Text, dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            Students_DA.Update(Students_DS.Tables[0]);
            Close();

        }

        private void button2_Click(object sender, EventArgs e) // отмена
        {
            Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 5; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

    }
}
