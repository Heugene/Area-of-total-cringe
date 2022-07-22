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
    public partial class Form5 : Form
    {
        private string user_mode;
        public string User_Mode
        {
            get
            { return this.user_mode; }
            set
            { this.user_mode = value; }
        }

        DataSet subjects_ds;
        OleDbDataAdapter subjects_da;
        OleDbConnection Session_Connect;
        OleDbCommandBuilder subjects_comm_builder;

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // добавить
        {
            Form6 form6 = new Form6();
            form6.Subjects_DS = this.subjects_ds;
            form6.Subjects_DA = this.subjects_da;
            form6.DT_View = this.dataGridView1;
            form6.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) // удалить
        {
            if (MessageBox.Show(Owner, "Удалить выбранные записи?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int temp;
                for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                {
                    temp = dataGridView1.SelectedRows[i].Index;
                    dataGridView1.Rows.RemoveAt(temp);
                    subjects_ds.Tables[0].Rows[temp].Delete();
                    subjects_da.Update(subjects_ds.Tables[0]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // назад
        {
            Hide();
            Application.OpenForms[1].Show();
            Dispose();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            button3.Enabled = true; //назад
            switch (User_Mode)
            {
                case "TEST_MODE":
                    {
                        label1.Text = "Тестовый режим";
                        button1.Enabled = true; //добавить
                        button2.Enabled = true; //удалить
                    }
                    break;
                case "BASIC_MODE":
                    {
                        label1.Text = "Базовый режим";
                        button1.Enabled = false; //добавить
                        button2.Enabled = false; //удалить
                    }
                    break;
                case "ADMIN_MODE":
                    {
                        label1.Text = "Режим администратора";
                        button1.Enabled = true; //добавить
                        button2.Enabled = true; //удалить
                    }
                    break;
            }

            this.Session_Connect = new OleDbConnection();
            Session_Connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"F:\Учебные документы Жени\Базы данных\Сессия.accdb";
            this.subjects_ds = new DataSet();
            this.subjects_da = new OleDbDataAdapter("SELECT * FROM Дисциплины", Session_Connect);
            this.subjects_comm_builder = new OleDbCommandBuilder(subjects_da);
            subjects_da.InsertCommand = subjects_comm_builder.GetInsertCommand();
            subjects_da.DeleteCommand = subjects_comm_builder.GetDeleteCommand();
            subjects_da.UpdateCommand = subjects_comm_builder.GetUpdateCommand();
            subjects_da.Fill(subjects_ds, "Дисциплины");

            dataGridView1.TopLeftHeaderCell.Value = "№SUB";
            for (int i = 0; i < subjects_ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(subjects_ds.Tables[0].Rows[i].ItemArray[0], subjects_ds.Tables[0].Rows[i].ItemArray[1], subjects_ds.Tables[0].Rows[i].ItemArray[2]);
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
