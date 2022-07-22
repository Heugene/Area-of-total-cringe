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
using System.IO;

namespace RS_DB_Editor
{
    public partial class Main : Form
    {
        //виправив момент із жорсткою прив'язкою
        static string path = @".\RS_DB.accdb";
        static OleDbConnection RS_DB_Connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);


        DataSet WORKERS_DS = new DataSet();
        DataSet POSTS_DS = new DataSet();
        DataSet TIMETABLE_DS = new DataSet();
        DataSet AUTHORS_DS = new DataSet();
        DataSet GENRES_DS = new DataSet();
        DataSet RECORDS_DS = new DataSet();

        DataSet PERSONNEL_DEPARTMENT_DS = new DataSet();
        DataSet MUSIC_ARCHIVE_DS = new DataSet();
        DataSet BROADCAST_GRID_DS = new DataSet();

        OleDbDataAdapter WORKERS_DA = new OleDbDataAdapter("SELECT * FROM Workers", RS_DB_Connection);
        OleDbDataAdapter POSTS_DA = new OleDbDataAdapter("SELECT * FROM Posts", RS_DB_Connection);
        OleDbDataAdapter TIMETABLE_DA = new OleDbDataAdapter("SELECT * FROM Timetable", RS_DB_Connection);
        OleDbDataAdapter AUTHORS_DA = new OleDbDataAdapter("SELECT * FROM Authors", RS_DB_Connection);
        OleDbDataAdapter GENRES_DA = new OleDbDataAdapter("SELECT * FROM Genres", RS_DB_Connection);
        OleDbDataAdapter RECORDS_DA = new OleDbDataAdapter("SELECT * FROM Records", RS_DB_Connection);

        OleDbDataAdapter PERSONNEL_DEPARTMENT_DA = new OleDbDataAdapter("SELECT Workers.worker_id, Workers.fio, Workers.age, Workers.gender, Workers.address, Workers.phone_number, Workers.passport_details, Posts.post_name FROM Workers INNER JOIN Posts ON Workers.post_id = Posts.post_id", RS_DB_Connection);
        OleDbDataAdapter MUSIC_ARCHIVE_DA = new OleDbDataAdapter("SELECT Records.record_id, Records.record_name, Authors.author_name, Records.album, Records.prod_year, Genres.genre_name, Records.record_date, Records.length, Records.rating FROM Genres INNER JOIN (Authors INNER JOIN Records ON Authors.author_id = Records.author_id) ON Genres.genre_id = Records.genre_id", RS_DB_Connection);
        OleDbDataAdapter BROADCAST_GRID_DA = new OleDbDataAdapter("SELECT Timetable.working_date, Workers.fio, Timetable.time1, Records.record_name AS record1, Timetable.time2, Records_1.record_name AS record2, Timetable.time3, Records_2.record_name AS record3 FROM Records AS Records_2 INNER JOIN (Records AS Records_1 INNER JOIN (Records INNER JOIN (Workers INNER JOIN Timetable ON Workers.worker_id = Timetable.worker_id) ON Records.record_id = Timetable.record1_id) ON Records_1.record_id = Timetable.record2_id) ON Records_2.record_id = Timetable.record3_id", RS_DB_Connection);

        OleDbCommandBuilder WORKERS_CB = new OleDbCommandBuilder();
        OleDbCommandBuilder POSTS_CB = new OleDbCommandBuilder();
        OleDbCommandBuilder TIMETABLE_CB = new OleDbCommandBuilder();
        OleDbCommandBuilder AUTHORS_CB = new OleDbCommandBuilder();
        OleDbCommandBuilder GENRES_CB = new OleDbCommandBuilder();
        OleDbCommandBuilder RECORDS_CB = new OleDbCommandBuilder();

        OleDbCommandBuilder PERSONNEL_DEPARTMENT_CB = new OleDbCommandBuilder();
        OleDbCommandBuilder MUSIC_ARCHIVE_CB = new OleDbCommandBuilder();
        OleDbCommandBuilder BROADCAST_GRID_CB = new OleDbCommandBuilder();

        public Main()
        {
            InitializeComponent();
        }

        // Reset method for application
        public static void Reset(DataGridView DataGridView, Label Table_Name_Label, GroupBox WORKERS_GroupBox, GroupBox POSTS_GroupBox, GroupBox TIMETABLE_GroupBox, GroupBox AUTHORS_GroupBox, GroupBox GENRES_GroupBox, GroupBox RECORDS_GroupBox, GroupBox FILTERS_GroupBox, Button Add_Button, Button Delete_Button, Button Save_Button, RadioButton F0_RB, RadioButton F1_RB, RadioButton F2_RB, ComboBox F1_CB, ComboBox F2_CB)
        {
            DataGridView.Visible = false;
            Table_Name_Label.Visible = false;

            DataGridView.Rows.Clear();
            DataGridView.Columns.Clear();
            DataGridView.Width = 600;

            WORKERS_GroupBox.Visible = false;
            POSTS_GroupBox.Visible = false;
            TIMETABLE_GroupBox.Visible = false;
            AUTHORS_GroupBox.Visible = false;
            GENRES_GroupBox.Visible = false;
            RECORDS_GroupBox.Visible = false;
            FILTERS_GroupBox.Visible = false;
            FILTERS_GroupBox.Width = 460;

            F0_RB.Text = "No filters";
            F1_RB.Text = "f1";
            F2_RB.Text = "f2";
            F1_CB.Items.Clear();
            F2_CB.Items.Clear();
            F1_CB.Visible = false;
            F2_CB.Visible = false;

            Add_Button.Visible = false;
            Delete_Button.Visible = false;
            Save_Button.Visible = false;
        }

        //Fill method for DataGridView (1 DataGridView for any DataSet.Tables[0])
        public static void DataGrid_Fill(DataGridView DT, DataSet DS)
        {
            
            for (int i = 0; i < DS.Tables[0].Columns.Count; i++)
            {
                DT.Columns.Add(DS.Tables[0].Columns[i].Caption, DS.Tables[0].Columns[i].Caption);
            }

            for (int m = 0; m < DS.Tables[0].Rows.Count; m++)
            {
                DT.Rows.Add();
                for (int n = 0; n < DS.Tables[0].Columns.Count; n++)
                {
                    DT.Rows[m].Cells[n].Value = DS.Tables[0].Rows[m].ItemArray[n];
                }
            }
        }

        //DateTime truncate method (01.01.2022 17:00:00 -> 17:00:00)
        public static void DT_Cell_Date_Truncate(DataGridView DT, int id)
        {
            string new_value;
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                new_value = DT.Rows[i].Cells[id].Value.ToString().Remove(0, 10);
                DT.Rows[i].Cells[id].Value = new_value;
            }
        }
        //DateTime truncate method (01.01.2022 17:00:00 -> 01.01.2022)
        public static void DT_Cell_Time_Truncate(DataGridView DT, int id)
        {
            string new_value;
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                new_value = DT.Rows[i].Cells[id].Value.ToString().Remove(10);
                DT.Rows[i].Cells[id].Value = new_value;
            }
        }

        //Fill method for ComboBox (1 ComboBox to display any Column of any DataSet.Tables[0])
        public static void ComboBox_Fill(ComboBox CB, DataSet DS, int id)
        {
            CB.Items.Clear();
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                CB.Items.Add(DS.Tables[0].Rows[i].ItemArray[id]);
            }
        }

        //A quite tricky method to get the id of selected item in Combobox
        public static string Get_id(string input, string id_column, string name_column, string table) 
        {
            RS_DB_Connection.Open();
            OleDbCommand select_id = RS_DB_Connection.CreateCommand();

            // С параметрами не вийшло(
            /*
            select_id.Parameters.Add("@ID_COLUMN", OleDbType.VarChar);
            select_id.Parameters.Add("@TABLE", OleDbType.VarChar);
            select_id.Parameters.Add("@NAME_COLUMN", OleDbType.VarChar);
            select_id.Parameters.Add("@INPUT", OleDbType.VarChar);

            select_id.Parameters["@ID_COLUMN"].Value = id_column;
            select_id.Parameters["@TABLE"].Value = table;
            select_id.Parameters["@NAME_COLUMN"].Value = name_column;
            select_id.Parameters["@INPUT"].Value = input;
            */
            select_id.CommandText = "SELECT " + id_column + " FROM " + table + " WHERE " + name_column + " = '" + input + "';";

            string result = select_id.ExecuteScalar().ToString();
            RS_DB_Connection.Close();
            return result;
        }

        //A method that removes all selected records from DataGridView and current DataSet
        public static void Table_Remove(DataGridView DT, DataSet DS, OleDbDataAdapter DA)
        {
            if (MessageBox.Show("Are you sure you want to remove selected records?", "Confirm this action", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int temp;
                for (int i = DT.SelectedRows.Count - 1; i >= 0; i--)
                {
                    temp = DT.SelectedRows[i].Index;
                    DT.Rows.RemoveAt(temp);
                    DS.Tables[0].Rows[temp].Delete();
                    DA.Update(DS);
                } 
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Width = 910;
            CenterToScreen();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);

            //Checking whether the database file exists
            if (File.Exists(path) == false)
            {
                MessageBox.Show("Database missing at path:" + path + ". Fix that and run the app again");
                Environment.Exit(0);
            }

            WORKERS_CB.DataAdapter = WORKERS_DA;
            WORKERS_DA.InsertCommand = WORKERS_CB.GetInsertCommand();
            WORKERS_DA.DeleteCommand = WORKERS_CB.GetDeleteCommand();
            WORKERS_DA.UpdateCommand = WORKERS_CB.GetUpdateCommand();
            WORKERS_DA.Fill(WORKERS_DS);

            POSTS_CB.DataAdapter = POSTS_DA;
            POSTS_DA.InsertCommand = POSTS_CB.GetInsertCommand();
            POSTS_DA.DeleteCommand = POSTS_CB.GetDeleteCommand();
            POSTS_DA.UpdateCommand = POSTS_CB.GetUpdateCommand();
            POSTS_DA.Fill(POSTS_DS);

            TIMETABLE_CB.DataAdapter = TIMETABLE_DA;
            TIMETABLE_DA.InsertCommand = TIMETABLE_CB.GetInsertCommand();
            TIMETABLE_DA.DeleteCommand = TIMETABLE_CB.GetDeleteCommand();
            TIMETABLE_DA.UpdateCommand = TIMETABLE_CB.GetUpdateCommand();
            TIMETABLE_DA.Fill(TIMETABLE_DS);

            AUTHORS_CB.DataAdapter = AUTHORS_DA;
            AUTHORS_DA.InsertCommand = AUTHORS_CB.GetInsertCommand();
            AUTHORS_DA.DeleteCommand = AUTHORS_CB.GetDeleteCommand();
            AUTHORS_DA.UpdateCommand = AUTHORS_CB.GetUpdateCommand();
            AUTHORS_DA.Fill(AUTHORS_DS);

            GENRES_CB.DataAdapter = GENRES_DA;
            GENRES_DA.InsertCommand = GENRES_CB.GetInsertCommand();
            GENRES_DA.DeleteCommand = GENRES_CB.GetDeleteCommand();
            GENRES_DA.UpdateCommand = GENRES_CB.GetUpdateCommand();
            GENRES_DA.Fill(GENRES_DS);

            RECORDS_CB.DataAdapter = RECORDS_DA;
            RECORDS_DA.InsertCommand = RECORDS_CB.GetInsertCommand();
            RECORDS_DA.DeleteCommand = RECORDS_CB.GetDeleteCommand();
            RECORDS_DA.UpdateCommand = RECORDS_CB.GetUpdateCommand();
            RECORDS_DA.Fill(RECORDS_DS);
            
        }

        private void workersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NO_FILTERS_RB.Checked = true;
            QueriesToolStripMenuItem.Enabled = true;
            //workers table
            WORKERS_DS.Clear();
            DataGridView.Rows.Clear();
            DataGridView.Columns.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            WORKERS_CB.DataAdapter = WORKERS_DA;
            WORKERS_DA.Fill(WORKERS_DS);
            DataGrid_Fill(DataGridView, WORKERS_DS);

            W_gender_CB.Items.Clear();
            W_gender_CB.Items.Add("Male");
            W_gender_CB.Items.Add("Female");
            ComboBox_Fill(W_post_CB, POSTS_DS, 1);

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Workers";
            Table_Name_Label.Visible = true;
            WORKERS_GroupBox.Visible = true;
            Add_Button.Visible = true;
            Delete_Button.Visible = true;
            Save_Button.Visible = true;
        }

        private void postsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NO_FILTERS_RB.Checked = true;
            QueriesToolStripMenuItem.Enabled = true;
            //posts table
            POSTS_DS.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            POSTS_CB.DataAdapter = POSTS_DA;
            POSTS_DA.Fill(POSTS_DS);
            DataGrid_Fill(DataGridView, POSTS_DS);

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Posts";
            Table_Name_Label.Visible = true;
            POSTS_GroupBox.Visible = true;
            Add_Button.Visible = true;
            Delete_Button.Visible = true;
            Save_Button.Visible = true;
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NO_FILTERS_RB.Checked = true;
            QueriesToolStripMenuItem.Enabled = true;
            //timetable table
            TIMETABLE_DS.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            TIMETABLE_CB.DataAdapter = TIMETABLE_DA;
            TIMETABLE_DA.Fill(TIMETABLE_DS);
            DataGrid_Fill(DataGridView, TIMETABLE_DS);

            DT_Cell_Time_Truncate(DataGridView, 0);
            DT_Cell_Date_Truncate(DataGridView, 2);
            DT_Cell_Date_Truncate(DataGridView, 4);
            DT_Cell_Date_Truncate(DataGridView, 6);

            ComboBox_Fill(T_worker_CB, WORKERS_DS, 1);
            ComboBox_Fill(T_record1_CB, RECORDS_DS, 1);
            ComboBox_Fill(T_record2_CB, RECORDS_DS, 1);
            ComboBox_Fill(T_record3_CB, RECORDS_DS, 1);

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Timetable";
            Table_Name_Label.Visible = true;
            TIMETABLE_GroupBox.Visible = true;
            Add_Button.Visible = true;
            Delete_Button.Visible = true;
            Save_Button.Visible = true;
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NO_FILTERS_RB.Checked = true;
            QueriesToolStripMenuItem.Enabled = true;
            //authors table
            AUTHORS_DS.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            AUTHORS_CB.DataAdapter = AUTHORS_DA;
            AUTHORS_DA.Fill(AUTHORS_DS);
            DataGrid_Fill(DataGridView, AUTHORS_DS);

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Authors";
            Table_Name_Label.Visible = true;
            AUTHORS_GroupBox.Visible = true;
            Add_Button.Visible = true;
            Delete_Button.Visible = true;
            Save_Button.Visible = true;
        }

        private void genresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NO_FILTERS_RB.Checked = true;
            QueriesToolStripMenuItem.Enabled = true;
            //genres table
            GENRES_DS.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            GENRES_CB.DataAdapter = GENRES_DA;
            GENRES_DA.Fill(GENRES_DS);
            DataGrid_Fill(DataGridView, GENRES_DS);

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Genres";
            Table_Name_Label.Visible = true;
            GENRES_GroupBox.Visible = true;
            Add_Button.Visible = true;
            Delete_Button.Visible = true;
            Save_Button.Visible = true;
        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NO_FILTERS_RB.Checked = true;
            QueriesToolStripMenuItem.Enabled = true;
            //records table
            RECORDS_DS.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            RECORDS_CB.DataAdapter = RECORDS_DA;
            RECORDS_DA.Fill(RECORDS_DS);
            DataGrid_Fill(DataGridView, RECORDS_DS);

            DT_Cell_Time_Truncate(DataGridView, 6);
            DT_Cell_Date_Truncate(DataGridView, 7);

            ComboBox_Fill(R_genre_CB, GENRES_DS, 1);
            ComboBox_Fill(R_author_CB, AUTHORS_DS, 1);

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Records";
            Table_Name_Label.Visible = true;
            RECORDS_GroupBox.Visible = true;
            Add_Button.Visible = true;
            Delete_Button.Visible = true;
            Save_Button.Visible = true;
        }

        private void personnelDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // query 1
            PERSONNEL_DEPARTMENT_DS.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            PERSONNEL_DEPARTMENT_CB.DataAdapter = PERSONNEL_DEPARTMENT_DA;
            PERSONNEL_DEPARTMENT_DA.Fill(PERSONNEL_DEPARTMENT_DS);
            DataGrid_Fill(DataGridView, PERSONNEL_DEPARTMENT_DS);
            DataGridView.Width = 850;

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Personnel department";
            Table_Name_Label.Visible = true;

            FILTER_1_RB.Text = "Specific post";
            FILTER_2_RB.Visible = false;
            FILTERS_GroupBox.Width = 275;
            FILTERS_GroupBox.Visible = true;
        }

        private void musicArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // query 2
            MUSIC_ARCHIVE_DS.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            MUSIC_ARCHIVE_CB.DataAdapter = MUSIC_ARCHIVE_DA;
            MUSIC_ARCHIVE_DA.Fill(MUSIC_ARCHIVE_DS);
            DataGrid_Fill(DataGridView, MUSIC_ARCHIVE_DS);
            DataGridView.Width = 850;

            DT_Cell_Time_Truncate(DataGridView, 6);
            DT_Cell_Date_Truncate(DataGridView, 7);

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Music archive";
            Table_Name_Label.Visible = true;

            FILTER_1_RB.Text = "Specific author";
            FILTER_2_RB.Text = "Specific genre";
            FILTER_1_RB.Visible = true;
            FILTER_2_RB.Visible = true;
            FILTERS_GroupBox.Visible = true;
        }

        private void broadcastGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //query 3
            BROADCAST_GRID_DS.Clear();
            Reset(DataGridView, Table_Name_Label, WORKERS_GroupBox, POSTS_GroupBox, TIMETABLE_GroupBox, AUTHORS_GroupBox, GENRES_GroupBox, RECORDS_GroupBox, FILTERS_GroupBox, Add_Button, Delete_Button, Save_Button, NO_FILTERS_RB, FILTER_1_RB, FILTER_2_RB, FILTER_1_CB, FILTER_2_CB);
            BROADCAST_GRID_CB.DataAdapter = BROADCAST_GRID_DA;
            BROADCAST_GRID_DA.Fill(BROADCAST_GRID_DS);
            DataGrid_Fill(DataGridView, BROADCAST_GRID_DS);
            DataGridView.Width = 850;

            DT_Cell_Time_Truncate(DataGridView, 0);
            DT_Cell_Date_Truncate(DataGridView, 2);
            DT_Cell_Date_Truncate(DataGridView, 4);
            DT_Cell_Date_Truncate(DataGridView, 6);

            DataGridView.Visible = true;
            Table_Name_Label.Text = "Broadcast grid";
            Table_Name_Label.Visible = true;

            FILTER_1_RB.Text = "Specific date";
            FILTER_2_RB.Text = "Specific worker";
            FILTER_1_RB.Visible = true;
            FILTER_2_RB.Visible = true;
            FILTERS_GroupBox.Visible = true;
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueriesToolStripMenuItem.Enabled = true;
            // about program
            Info info = new Info();
            info.ShowDialog();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            switch (Table_Name_Label.Text)
            {
                case "Workers":
                    {
                        try
                        {
                            WORKERS_DS.Tables[0].Rows.Add(W_id_NUD.Value.ToString(), W_fio_TB.Text, W_age_NUD.Value.ToString(), W_gender_CB.SelectedItem.ToString(), W_address_TB.Text, W_number_TB.Text, W_passport_TB.Text, Get_id(W_post_CB.SelectedItem.ToString(), "post_id", "post_name", "Posts"));
                            DataGridView.Rows.Add(W_id_NUD.Value.ToString(), W_fio_TB.Text, W_age_NUD.Value.ToString(), W_gender_CB.SelectedItem.ToString(), W_address_TB.Text, W_number_TB.Text, W_passport_TB.Text, Get_id(W_post_CB.SelectedItem.ToString(), "post_id", "post_name", "Posts"));
                            WORKERS_DA.Update(WORKERS_DS);
                        }
                        catch
                        {
                            MessageBox.Show("Data input error! Make sure the data is correct and primary key is unique!");
                        }
                    }
                break;

                case "Posts":
                {
                    try
                    {
                        POSTS_DS.Tables[0].Rows.Add(P_id_NUD.Value.ToString(), P_name_TB.Text, P_salary_NUD.Value.ToString(), P_resp_TB.Text, P_req_TB.Text);
                        DataGridView.Rows.Add(P_id_NUD.Value.ToString(), P_name_TB.Text, P_salary_NUD.Value.ToString(), P_resp_TB.Text, P_req_TB.Text);
                        POSTS_DA.Update(POSTS_DS);
                    }
                    catch
                    {
                        MessageBox.Show("Data input error! Make sure the data is correct and primary key is unique!");
                    }
                }
                break;

                case "Timetable":
                {
                    try
                    {
                        TIMETABLE_DS.Tables[0].Rows.Add(T_date_DTP.Value.ToString(), Get_id(T_worker_CB.SelectedItem.ToString(), "worker_id", "fio", "Workers"), T_time1_DTP.Value.ToString(), Get_id(T_record1_CB.SelectedItem.ToString(), "record_id", "record_name", "Records"), T_time2_DTP.Value.ToString(), Get_id(T_record2_CB.SelectedItem.ToString(), "record_id", "record_name", "Records"), T_time3_DTP.Value.ToString(), Get_id(T_record3_CB.SelectedItem.ToString(), "record_id", "record_name", "Records"));
                        DataGridView.Rows.Add(T_date_DTP.Value.ToString(), Get_id(T_worker_CB.SelectedItem.ToString(), "worker_id", "fio", "Workers"), T_time1_DTP.Value.ToString(), Get_id(T_record1_CB.SelectedItem.ToString(), "record_id", "record_name", "Records"), T_time2_DTP.Value.ToString(), Get_id(T_record2_CB.SelectedItem.ToString(), "record_id", "record_name", "Records"), T_time3_DTP.Value.ToString(), Get_id(T_record3_CB.SelectedItem.ToString(), "record_id", "record_name", "Records"));
                        TIMETABLE_DA.Update(TIMETABLE_DS);
                    }
                    catch
                    {
                        MessageBox.Show("Data input error! Make sure the data is correct and primary key is unique!");
                    }
                }
                break;

                case "Authors":
                {
                    try
                    {
                        AUTHORS_DS.Tables[0].Rows.Add(A_id_NUD.Value.ToString(), A_name_TB.Text, A_desc_TB.Text);
                        DataGridView.Rows.Add(A_id_NUD.Value.ToString(), A_name_TB.Text, A_desc_TB.Text);
                        AUTHORS_DA.Update(AUTHORS_DS);
                    }
                    catch
                    {
                        MessageBox.Show("Data input error! Make sure the data is correct and primary key is unique!");
                    }
                }
                break;

                case "Genres":
                {
                    try
                    {
                        GENRES_DS.Tables[0].Rows.Add(G_id_NUD.Value.ToString(), G_name_TB.Text, G_desc_TB.Text);
                        DataGridView.Rows.Add(G_id_NUD.Value.ToString(), G_name_TB.Text, G_desc_TB.Text);
                        GENRES_DA.Update(GENRES_DS);
                    }
                    catch
                    {
                        MessageBox.Show("Data input error! Make sure the data is correct and primary key is unique!");
                    }
                }
                break;

                case "Records":
                {
                    try
                    {
                        string prod_year = R_date_DTP.Value.ToString().Remove(0, 6);
                        prod_year = prod_year.Remove(4);
                        RECORDS_DS.Tables[0].Rows.Add(R_id_NUD.Value.ToString(), R_name_TB.Text, Get_id(R_author_CB.SelectedItem.ToString(), "author_id", "author_name", "Authors"), R_album_TB.Text, prod_year, Get_id(R_genre_CB.SelectedItem.ToString(), "genre_id", "genre_name", "Genres"), R_date_DTP.Value.ToString(), R_length_DTP.Value.ToString(), R_rating_NUD.Value.ToString());
                        DataGridView.Rows.Add(R_id_NUD.Value.ToString(), R_name_TB.Text, Get_id(R_author_CB.SelectedItem.ToString(), "author_id", "author_name", "Authors"), R_album_TB.Text, prod_year, Get_id(R_genre_CB.SelectedItem.ToString(), "genre_id", "genre_name", "Genres"), R_date_DTP.Value.ToString(), R_length_DTP.Value.ToString(), R_rating_NUD.Value.ToString());
                        RECORDS_DA.Update(RECORDS_DS);
                    }
                    catch
                    {
                        MessageBox.Show("Data input error! Make sure the data is correct and primary key is unique!");
                    }
                }
                break;
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            switch (Table_Name_Label.Text)
            {
                case "Workers":
                {
                    Table_Remove(DataGridView, WORKERS_DS, WORKERS_DA);
                }
                break;

                case "Posts":
                {
                    Table_Remove(DataGridView, POSTS_DS, POSTS_DA);
                }
                break;

                case "Timetable":
                {
                    Table_Remove(DataGridView, TIMETABLE_DS, TIMETABLE_DA);
                }
                break;

                case "Authors":
                {
                    Table_Remove(DataGridView, AUTHORS_DS, AUTHORS_DA);
                }
                break;

                case "Genres":
                {
                    Table_Remove(DataGridView, GENRES_DS, GENRES_DA);
                }
                break;

                case "Records":
                {
                    Table_Remove(DataGridView, RECORDS_DS, RECORDS_DA);
                }
                break;
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            WORKERS_DA.Update(WORKERS_DS);
            POSTS_DA.Update(POSTS_DS);
            TIMETABLE_DA.Update(TIMETABLE_DS);
            AUTHORS_DA.Update(AUTHORS_DS);
            GENRES_DA.Update(GENRES_DS);
            RECORDS_DA.Update(RECORDS_DS);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FILTER_1_CB.SelectedIndex < 0)
            {
                return;
            }
            switch (Table_Name_Label.Text)
            {
                case "Personnel department":
                {
                    PERSONNEL_DEPARTMENT_DA.SelectCommand.CommandText = "SELECT Workers.worker_id, Workers.fio, Workers.age, Workers.gender, Workers.address, Workers.phone_number, Workers.passport_details, Posts.post_name FROM Workers INNER JOIN Posts ON Workers.post_id = Posts.post_id WHERE Posts.post_name = '"+FILTER_1_CB.SelectedItem.ToString()+"';";
                    personnelDepartmentToolStripMenuItem_Click(sender, e);
                }
                break;

                case "Music archive":
                {
                    MUSIC_ARCHIVE_DA.SelectCommand.CommandText = "SELECT Records.record_id, Records.record_name, Authors.author_name, Records.album, Records.prod_year, Genres.genre_name, Records.record_date, Records.length, Records.rating FROM Genres INNER JOIN (Authors INNER JOIN Records ON Authors.author_id = Records.author_id) ON Genres.genre_id = Records.genre_id WHERE Authors.author_name = '" + FILTER_1_CB.SelectedItem.ToString() + "';";
                    musicArchiveToolStripMenuItem_Click(sender, e);
                }
                break;

                case "Broadcast grid":
                {
                    // "date" is a converted input of type 01.01.2022 -> #01/01/2022#
                    string date = "#" + FILTER_1_CB.SelectedItem.ToString().Remove(2) + "/" + FILTER_1_CB.SelectedItem.ToString().Remove(0, 3).Remove(2) + "/" + FILTER_1_CB.SelectedItem.ToString().Remove(0, 6).Remove(4) + "#";
                    BROADCAST_GRID_DA.SelectCommand.CommandText = "SELECT Timetable.working_date, Workers.fio, Timetable.time1, Records.record_name AS record1, Timetable.time2, Records_1.record_name AS record2, Timetable.time3, Records_2.record_name AS record3 FROM Records AS Records_2 INNER JOIN (Records AS Records_1 INNER JOIN (Records INNER JOIN (Workers INNER JOIN Timetable ON Workers.worker_id = Timetable.worker_id) ON Records.record_id = Timetable.record1_id) ON Records_1.record_id = Timetable.record2_id) ON Records_2.record_id = Timetable.record3_id WHERE Timetable.working_date = " + date + ";";
                    broadcastGridToolStripMenuItem_Click(sender, e);
                }
                break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FILTER_2_CB.SelectedIndex < 0)
            {
                return;
            }
            switch (Table_Name_Label.Text)
            {
                case "Personnel department":
                    {
                        //nothing
                    }
                    break;

                case "Music archive":
                    {
                        MUSIC_ARCHIVE_DA.SelectCommand.CommandText = "SELECT Records.record_id, Records.record_name, Authors.author_name, Records.album, Records.prod_year, Genres.genre_name, Records.record_date, Records.length, Records.rating FROM Genres INNER JOIN (Authors INNER JOIN Records ON Authors.author_id = Records.author_id) ON Genres.genre_id = Records.genre_id WHERE Genres.genre_name = '" + FILTER_2_CB.SelectedItem.ToString() + "';";
                        musicArchiveToolStripMenuItem_Click(sender, e);
                    }
                    break;

                case "Broadcast grid":
                    {
                        BROADCAST_GRID_DA.SelectCommand.CommandText = "SELECT Timetable.working_date, Workers.fio, Timetable.time1, Records.record_name AS record1, Timetable.time2, Records_1.record_name AS record2, Timetable.time3, Records_2.record_name AS record3 FROM Records AS Records_2 INNER JOIN (Records AS Records_1 INNER JOIN (Records INNER JOIN (Workers INNER JOIN Timetable ON Workers.worker_id = Timetable.worker_id) ON Records.record_id = Timetable.record1_id) ON Records_1.record_id = Timetable.record2_id) ON Records_2.record_id = Timetable.record3_id WHERE Workers.fio = '" + FILTER_2_CB.SelectedItem.ToString() + "';";
                        broadcastGridToolStripMenuItem_Click(sender, e);
                    }
                    break;
            }
        }

        //preventing editing of ComboBoxes in unprotected area of code
        private void FILTER_1_CB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FILTER_2_CB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void NO_FILTERS_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (NO_FILTERS_RB.Checked)
            {
                switch (Table_Name_Label.Text)
                {
                    case "Personnel department":
                    {
                        PERSONNEL_DEPARTMENT_DA.SelectCommand.CommandText = "SELECT Workers.worker_id, Workers.fio, Workers.age, Workers.gender, Workers.address, Workers.phone_number, Workers.passport_details, Posts.post_name FROM Workers INNER JOIN Posts ON Workers.post_id = Posts.post_id";
                        FILTER_1_CB.Visible = false;
                        FILTER_2_CB.Visible = false;
                        personnelDepartmentToolStripMenuItem_Click(sender, e);
                    }
                    break;

                    case "Music archive":
                    {
                        MUSIC_ARCHIVE_DA.SelectCommand.CommandText = "SELECT Records.record_id, Records.record_name, Authors.author_name, Records.album, Records.prod_year, Genres.genre_name, Records.record_date, Records.length, Records.rating FROM Genres INNER JOIN (Authors INNER JOIN Records ON Authors.author_id = Records.author_id) ON Genres.genre_id = Records.genre_id";
                        FILTER_1_CB.Visible = false;
                        FILTER_2_CB.Visible = false;
                        musicArchiveToolStripMenuItem_Click(sender, e);
                    }
                    break;

                    case "Broadcast grid":
                    {
                        BROADCAST_GRID_DA.SelectCommand.CommandText = "SELECT Timetable.working_date, Workers.fio, Timetable.time1, Records.record_name AS record1, Timetable.time2, Records_1.record_name AS record2, Timetable.time3, Records_2.record_name AS record3 FROM Records AS Records_2 INNER JOIN (Records AS Records_1 INNER JOIN (Records INNER JOIN (Workers INNER JOIN Timetable ON Workers.worker_id = Timetable.worker_id) ON Records.record_id = Timetable.record1_id) ON Records_1.record_id = Timetable.record2_id) ON Records_2.record_id = Timetable.record3_id";
                        FILTER_1_CB.Visible = false;
                        FILTER_2_CB.Visible = false;
                        broadcastGridToolStripMenuItem_Click(sender, e);
                    }
                    break;
                }
                QueriesToolStripMenuItem.Enabled = true;
            }
        }

        private void FILTER_1_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (FILTER_1_RB.Checked)
            {
                switch (Table_Name_Label.Text)
                {
                    case "Personnel department":
                        {
                            FILTER_1_CB.Visible = true;
                            FILTER_2_CB.Visible = false;
                            ComboBox_Fill(FILTER_1_CB, POSTS_DS, 1);
                        }
                        break;

                    case "Music archive":
                        {
                            FILTER_1_CB.Visible = true;
                            FILTER_2_CB.Visible = false;
                            ComboBox_Fill(FILTER_1_CB, AUTHORS_DS, 1);
                        }
                        break;

                    case "Broadcast grid":
                        {
                            FILTER_1_CB.Visible = true;
                            FILTER_2_CB.Visible = false;
                            ComboBox_Fill(FILTER_1_CB, TIMETABLE_DS, 0);
                        }
                        break;
                }
                QueriesToolStripMenuItem.Enabled = false;
            }
        }

        private void FILTER_2_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (FILTER_2_RB.Checked)
            {
                switch (Table_Name_Label.Text)
                {
                    case "Personnel department":
                        {
                            // nothing
                        }
                        break;

                    case "Music archive":
                        {
                            FILTER_1_CB.Visible = false;
                            FILTER_2_CB.Visible = true;
                            ComboBox_Fill(FILTER_2_CB, GENRES_DS, 1);
                        }
                        break;

                    case "Broadcast grid":
                        {
                            FILTER_1_CB.Visible = false;
                            FILTER_2_CB.Visible = true;
                            ComboBox_Fill(FILTER_2_CB, WORKERS_DS, 1);
                        }
                        break;
                }
                QueriesToolStripMenuItem.Enabled = false;
            }
        }


    }
}
