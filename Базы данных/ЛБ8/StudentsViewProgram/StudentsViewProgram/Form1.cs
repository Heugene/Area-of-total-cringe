using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace StudentsViewProgram
{
    public partial class Form1 : Form
    {
        DataSet ds;
        OleDbDataAdapter daStudent;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection Session_Connect = new OleDbConnection();
            Session_Connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"F:\Учебные документы Жени\Базы данных\Сессия.accdb";
            ds = new DataSet();
            daStudent = new OleDbDataAdapter("SELECT * FROM Студенты", Session_Connect);
            OleDbCommandBuilder StudCommBuilder = new OleDbCommandBuilder(daStudent);
            daStudent.InsertCommand = StudCommBuilder.GetInsertCommand();
            daStudent.Fill(ds, "Student");
            dataGridView1.TopLeftHeaderCell.Value = "№ST";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
            {
                dataGridView1.Rows.Add(ds.Tables[0].Rows[i].ItemArray[0], ds.Tables[0].Rows[i].ItemArray[1], ds.Tables[0].Rows[i].ItemArray[2], ds.Tables[0].Rows[i].ItemArray[3], ds.Tables[0].Rows[i].ItemArray[4].ToString().Remove(10));
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.DTView = this.dataGridView1;
            form2.adStud = this.daStudent;
            form2.dsStud = this.ds;
            form2.Show();
        }
    }
}
