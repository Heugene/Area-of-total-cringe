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
    public partial class Form3 : Form
    {
        private string user_mode;
        public string User_Mode
        {
            get
            { return this.user_mode; }
            set
            { this.user_mode = value; }
        }

        DataSet students_ds;
        OleDbDataAdapter students_da;
        OleDbConnection Session_Connect;
        OleDbCommandBuilder students_comm_builder;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
            this.students_ds = new DataSet();
            this.students_da = new OleDbDataAdapter("SELECT * FROM Студенты", Session_Connect);
            this.students_comm_builder = new OleDbCommandBuilder(students_da);
            students_da.InsertCommand = students_comm_builder.GetInsertCommand();
            students_da.DeleteCommand = students_comm_builder.GetDeleteCommand();
            students_da.UpdateCommand = students_comm_builder.GetUpdateCommand();
            students_da.Fill(students_ds, "Students");

            /*
            dataGridView1.DataSource = students_ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Шифр студента";
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Курс";
            dataGridView1.Columns[3].HeaderText = "Группа";
            dataGridView1.Columns[4].HeaderText = "Дата рождения";
            */

            
            dataGridView1.TopLeftHeaderCell.Value = "№ST";
            for (int i = 0; i < students_ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(students_ds.Tables[0].Rows[i].ItemArray[0], students_ds.Tables[0].Rows[i].ItemArray[1], students_ds.Tables[0].Rows[i].ItemArray[2], students_ds.Tables[0].Rows[i].ItemArray[3], students_ds.Tables[0].Rows[i].ItemArray[4].ToString().Remove(10));
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            

        }

        private void button1_Click(object sender, EventArgs e) //добавить запись
        {
            Form4 form4 = new Form4();
            form4.DT_View = this.dataGridView1;
            form4.Students_DS = this.students_ds;
            form4.Students_DA = this.students_da;
            form4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) // назад на форму 2
        {
            Hide();
            Application.OpenForms[1].Show();
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e) //удалить запись
        {
                if (MessageBox.Show(Owner, "Удалить выбранные записи?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int temp;
                    for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0 ; i--)
                    {
                        temp = dataGridView1.SelectedRows[i].Index;
                        dataGridView1.Rows.RemoveAt(temp);
                        students_ds.Tables[0].Rows[temp].Delete();
                        students_da.Update(students_ds.Tables[0]);
                    }
                }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
