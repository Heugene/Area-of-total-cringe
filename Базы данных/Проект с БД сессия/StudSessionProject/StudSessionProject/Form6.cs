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
    public partial class Form6 : Form
    {
        public DataGridView DT_View;
        public DataSet Subjects_DS;
        public OleDbDataAdapter Subjects_DA;

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //добавить
        {
            int N = DT_View.Rows.Count;
            DT_View.Rows.Add(textBox1.Text, textBox2.Text, numericUpDown1.Value.ToString());
            DT_View.Rows[N].HeaderCell.Value = (N + 1).ToString();
            Subjects_DS.Tables[0].Rows.Add(textBox1.Text, textBox2.Text, numericUpDown1.Value.ToString());
            Subjects_DA.Update(Subjects_DS.Tables[0]);
            Close();
        }

        private void button2_Click(object sender, EventArgs e) //отмена
        {
            Close();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
