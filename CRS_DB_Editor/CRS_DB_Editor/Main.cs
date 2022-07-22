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

namespace CSS_DB_Editor
{
    public partial class Main : Form
    {
        DataSet CSS_DB;
        Button[] Buttons;
        string Current_Table;

        public Main()
        {
            InitializeComponent();
        }

        public static void Reset(Label Table_Name_LBL, GroupBox[] Adding_GBs, DataGridView DGV)
        {
            Table_Name_LBL.Visible = false;
            DGV.Rows.Clear();
            DGV.Columns.Clear();

            foreach (GroupBox element in Adding_GBs)
            {
                element.Visible = false;
                element.Left = 660;
                //element.Top = 95;
            }
        }

        public static void DataGrid_Fill(DataGridView DGV, DataTable DT)
        {
            DGV.Visible = true;
            DGV.Columns.Clear();
            DGV.Rows.Clear();
            for (int i = 0; i < DT.Columns.Count; i++)
            {
                DGV.Columns.Add(DT.Columns[i].Caption, DT.Columns[i].Caption);
            }

            for (int m = 0; m < DT.Rows.Count; m++)
            {
                DGV.Rows.Add();
                for (int n = 0; n < DT.Columns.Count; n++)
                {
                    DGV.Rows[m].Cells[n].Value = DT.Rows[m].ItemArray[n];
                }
            }
        }

        public static void DGV_Remove_Records(DataGridView DGV, DataTable DT)
        {
            if (MessageBox.Show("Ви дійсно бажаєте видалити виділені записи?", "Підтвердіть дію", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (DGV.SelectedRows.Count > 0)
                {
                    int temp;
                    for (int i = DGV.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        temp = DGV.SelectedRows[i].Index;
                        DGV.Rows.RemoveAt(temp);
                        CSS_DB_Editor.CSS_DB.Delete_Record(ref DT, temp);
                    }
                }
            }
        }

        public static void Buttons_Hide(Button[] Buttons)
        {
            foreach (Button element in Buttons)
            {
                element.Hide();
            }
        }

        public static void Buttons_Show(Button[] Buttons)
        {
            foreach (Button element in Buttons)
            {
                element.Show();
            }
        }

        public static void ComboBox_Fill(ComboBox CB, DataTable DT, int id)
        {
            CB.Items.Clear();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                CB.Items.Add(DT.Rows[i].ItemArray[id]);
            }
        }

        public static void DGV_Add_Records(DataGridView DGV, DataTable DT, string[] values)
        {
            DGV.Rows.Add(values);
            CSS_DB_Editor.CSS_DB.Add_Record(ref DT, values);
            DGV.Rows.Clear();
            DataGrid_Fill(DGV, DT);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Width = 930;
            Height = 600;

            CenterToScreen();

            this.Buttons = new Button[] { ADD_Button, DELETE_Button, SAVE_Button };
            Buttons_Hide(Buttons);

            DataGridView.Visible = false;
            Reset(Table_Name_LBL, new GroupBox[] {Drivers_GB, Mechanics_GB, Models_GB, Cars_GB, ServiceStations_GB, Orders_GB, Q_GB}, DataGridView);

            try
            {
                if (CSS_DB_Editor.CSS_DB.Connection_Test())
                {
                    MessageBox.Show("Connection succeed");
                }
            }
            catch
            {
                MessageBox.Show("Connection failed");
                Environment.Exit(0);
            }

            CSS_DB = new DataSet();

            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table("Drivers", CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table("Mechanics", CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table("Models", CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table("Cars", CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table("Service_Stations", CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table("Orders", CSS_DB_Editor.CSS_DB.Get_Connection()));

            CSS_DB.Tables[0].TableName = "Drivers";
            CSS_DB.Tables[1].TableName = "Mechanics";
            CSS_DB.Tables[2].TableName = "Models";
            CSS_DB.Tables[3].TableName = "Cars";
            CSS_DB.Tables[4].TableName = "Service_Stations";
            CSS_DB.Tables[5].TableName = "Orders";
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SAVE_Button_Click(sender, e);
        }

        private void власникиАвтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Current_Table = "Drivers";
            CSS_DB.Tables.Remove(Current_Table);
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table(Current_Table, CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables[CSS_DB.Tables.Count - 1].TableName = Current_Table;

            Table_Name_LBL.Text = "Власники авто";
            Buttons_Show(Buttons);

            Reset(Table_Name_LBL, new GroupBox[] { Drivers_GB, Mechanics_GB, Models_GB, Cars_GB, ServiceStations_GB, Orders_GB, Q_GB }, DataGridView);
            DataGrid_Fill(DataGridView, CSS_DB.Tables[Current_Table]);
            Table_Name_LBL.Visible = true;
            Drivers_GB.Show();
        }

        private void механікиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Current_Table = "Mechanics";
            CSS_DB.Tables.Remove(Current_Table);
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table(Current_Table, CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables[CSS_DB.Tables.Count - 1].TableName = Current_Table;

            Table_Name_LBL.Text = "Механіки";
            Buttons_Show(Buttons);

            Reset(Table_Name_LBL, new GroupBox[] { Drivers_GB, Mechanics_GB, Models_GB, Cars_GB, ServiceStations_GB, Orders_GB, Q_GB }, DataGridView);
            ComboBox_Fill(ME_serviceStation_CB, CSS_DB.Tables["Service_Stations"], 1);
            DataGrid_Fill(DataGridView, CSS_DB.Tables[Current_Table]);
            Table_Name_LBL.Visible = true;
            Mechanics_GB.Show();
        }

        private void моделіАвтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Current_Table = "Models";
            CSS_DB.Tables.Remove(Current_Table);
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table(Current_Table, CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables[CSS_DB.Tables.Count - 1].TableName = Current_Table;

            Table_Name_LBL.Text = "Моделі авто";
            Buttons_Show(Buttons);

            Reset(Table_Name_LBL, new GroupBox[] { Drivers_GB, Mechanics_GB, Models_GB, Cars_GB, ServiceStations_GB, Orders_GB, Q_GB }, DataGridView);
            DataGrid_Fill(DataGridView, CSS_DB.Tables[Current_Table]);
            Table_Name_LBL.Visible = true;
            Models_GB.Show();
        }

        private void автоУВласностіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Current_Table = "Cars";
            CSS_DB.Tables.Remove(Current_Table);
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table(Current_Table, CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables[CSS_DB.Tables.Count - 1].TableName = Current_Table;

            Table_Name_LBL.Text = "Авто у власності";
            Buttons_Show(Buttons);

            ComboBox_Fill(CA_driver_CB, CSS_DB.Tables["Drivers"], 1);
            ComboBox_Fill(CA_model_CB, CSS_DB.Tables["Models"], 1);

            Reset(Table_Name_LBL, new GroupBox[] { Drivers_GB, Mechanics_GB, Models_GB, Cars_GB, ServiceStations_GB, Orders_GB, Q_GB }, DataGridView);
            DataGrid_Fill(DataGridView, CSS_DB.Tables[Current_Table]);
            Table_Name_LBL.Visible = true;
            Cars_GB.Show();
        }

        private void сервісніЦентриToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Current_Table = "Service_Stations";
            CSS_DB.Tables.Remove(Current_Table);
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table(Current_Table, CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables[CSS_DB.Tables.Count - 1].TableName = Current_Table;

            Table_Name_LBL.Text = "Сервісні центри";
            Buttons_Show(Buttons);

            Reset(Table_Name_LBL, new GroupBox[] { Drivers_GB, Mechanics_GB, Models_GB, Cars_GB, ServiceStations_GB, Orders_GB, Q_GB }, DataGridView);
            DataGrid_Fill(DataGridView, CSS_DB.Tables[Current_Table]);
            Table_Name_LBL.Visible = true;
            ServiceStations_GB.Show();
        }

        private void нарядиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Current_Table = "Orders";
            CSS_DB.Tables.Remove(Current_Table);
            CSS_DB.Tables.Add(CSS_DB_Editor.CSS_DB.Get_Table(Current_Table, CSS_DB_Editor.CSS_DB.Get_Connection()));
            CSS_DB.Tables[CSS_DB.Tables.Count - 1].TableName = Current_Table;

            Table_Name_LBL.Text = "Наряди";
            Buttons_Show(Buttons);

            Reset(Table_Name_LBL, new GroupBox[] { Drivers_GB, Mechanics_GB, Models_GB, Cars_GB, ServiceStations_GB, Orders_GB, Q_GB }, DataGridView);
            DataGrid_Fill(DataGridView, CSS_DB.Tables[Current_Table]);
            ComboBox_Fill(OR_car_CB, CSS_DB.Tables["Cars"], 0);
            ComboBox_Fill(OR_mechanic_CB, CSS_DB.Tables["Mechanics"], 1);
            Table_Name_LBL.Visible = true;
            Orders_GB.Show();
        }

        private void запит1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buttons_Hide(Buttons);
            Table_Name_LBL.Hide();
            Q_GB.Show();
            Input_Panel.Show();
            DataGridView.Hide();
            Current_Table = "Q1";
            Q_LBL.Text = "Введіть рік";
            Q_input_TB.Text = "";
            Q_TB.Text = "Вивести ПІБ механіка, який найчастіше працює з авто до певного року випуску";
        }

        private void запит2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buttons_Hide(Buttons);
            Table_Name_LBL.Hide();
            Q_GB.Show();
            Input_Panel.Show();
            DataGridView.Hide();
            Q_LBL.Text = "Введіть марку";
            Q_input_TB.Text = "";
            Current_Table = "Q2";
            Q_TB.Text = "Вивести випадки, коли ремонт авто певної марки запізнювався відносно запланованої дати";
        }

        private void запит3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buttons_Hide(Buttons);
            Table_Name_LBL.Hide();
            Q_GB.Show();
            Input_Panel.Hide();
            Current_Table = "Q3";
            Q_TB.Text = "Визначити власників авто, яких обслуговує завжди один механік. Вивести ПІБ механіка і його постійного клієнта";
            DataSet Q3 = new DataSet(Current_Table);
            SqlDataAdapter DA = new SqlDataAdapter(
                "SELECT DISTINCT Mechanics.mechanic_name, Drivers.driver_name "
                + "FROM Orders "
                + "INNER JOIN Mechanics ON Orders.mechanic_id = Mechanics.mechanic_id "
                + "INNER JOIN Cars ON Orders.car_id = Cars.car_id "
                + "INNER JOIN Drivers ON Cars.license_id = Drivers.license_id "
                + "WHERE Drivers.driver_name IN "
                + "( "
                + "SELECT Drivers.driver_name "
                + "FROM Orders "
                + "INNER JOIN Mechanics ON Orders.mechanic_id = Mechanics.mechanic_id "
                + "INNER JOIN Cars ON Orders.car_id = Cars.car_id "
                + "INNER JOIN Drivers ON Cars.license_id = Drivers.license_id "
                + "GROUP BY Drivers.driver_name "
                + "HAVING COUNT(DISTINCT Mechanics.mechanic_name) = 1 "
                + ")",
                CSS_DB_Editor.CSS_DB.Get_Connection());
            DA.Fill(Q3);
            DataGrid_Fill(DataGridView, Q3.Tables[0]);
        }

        private void запит4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buttons_Hide(Buttons);
            Table_Name_LBL.Hide();
            Q_GB.Show();
            Input_Panel.Hide();
            Current_Table = "Q4";
            Q_TB.Text = "Для кожної категорії робіт визначити, механіки якого розряду частіше призначаються на цю категорію";
            DataSet Q4 = new DataSet(Current_Table);
            SqlDataAdapter DA = new SqlDataAdapter(
                "WITH cte AS "
               + "( "
               //+ "SELECT TOP(1) WITH TIES Orders.order_category AS category, Mechanics.mechanic_rank AS rank, COUNT(Mechanics.mechanic_rank)  AS R_C "
               + "SELECT Orders.order_category AS category, Mechanics.mechanic_rank AS rank, COUNT(Mechanics.mechanic_rank)  AS R_C, ROW_NUMBER() OVER(PARTITION BY Orders.order_category ORDER BY Mechanics.mechanic_rank DESC) AS row_number "
               + "FROM Orders INNER JOIN Mechanics ON Orders.mechanic_id = Mechanics.mechanic_id "
               + "GROUP BY Mechanics.mechanic_rank, Orders.order_category "
               //+ "ORDER BY 3 DESC "
               + ") "
               + "SELECT cte.category, cte.rank "
               + "FROM cte "
               + "WHERE cte.row_number = 1",
                CSS_DB_Editor.CSS_DB.Get_Connection());
            DA.Fill(Q4);
            DataGrid_Fill(DataGridView, Q4.Tables[0]);
        }

        private void прододатокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void DELETE_Button_Click(object sender, EventArgs e)
        {
            DGV_Remove_Records(DataGridView, CSS_DB.Tables[Current_Table]);
        }

        private void SAVE_Button_Click(object sender, EventArgs e)
        {
            CSS_DB_Editor.CSS_DB.Save_All(CSS_DB);
        }

        private void ADD_Button_Click(object sender, EventArgs e)
        {
            switch (Current_Table)
            {
                case "Drivers":
                    {
                        try
                        {
                            DGV_Add_Records(DataGridView, CSS_DB.Tables["Drivers"], new string[] { DR_license_TB.Text, DR_name_TB.Text, DR_address_TB.Text, DR_phone_TB.Text });
                        }
                        catch
                        {
                            MessageBox.Show("Помилка вхідних даних! Переконайтеся у правильності введених даних і спробуйте ще раз.");
                        }
                    }
                    break;

                case "Mechanics":
                    {
                        try
                        {
                            DGV_Add_Records(DataGridView, CSS_DB.Tables["Mechanics"], new string[] { "1", ME_name_TB.Text, ME_address_TB.Text, ME_phone_TB.Text, ME_rank_NUD.Value.ToString(), CSS_DB_Editor.CSS_DB.Get_id(CSS_DB_Editor.CSS_DB.Get_Connection(), "Service_Stations", "service_station_id", "service_station_name", ME_serviceStation_CB.SelectedItem.ToString()) });
                        }
                        catch
                        {
                            MessageBox.Show("Помилка вхідних даних! Переконайтеся у правильності введених даних і спробуйте ще раз.");
                            MessageBox.Show(CSS_DB_Editor.CSS_DB.Get_id(CSS_DB_Editor.CSS_DB.Get_Connection(), "Service_Stations", "service_station_id", "service_station_name", ME_serviceStation_CB.Text));
                        }
                    }
                    break;

                case "Models":
                    {
                        try
                        {
                            DGV_Add_Records(DataGridView, CSS_DB.Tables["Models"], new string[] { "1", MO_name_TB.Text, MO_brand_TB.Text, MO_power_NUD.Value.ToString(), MO_prodYear_NUD.Value.ToString()});
                        }
                        catch
                        {
                            MessageBox.Show("Помилка вхідних даних! Переконайтеся у правильності введених даних і спробуйте ще раз.");
                        }
                    }
                    break;

                case "Cars":
                    {
                        try
                        {
                            DGV_Add_Records(DataGridView, CSS_DB.Tables["Cars"], new string[] { CA_plateID_TB.Text, CSS_DB_Editor.CSS_DB.Get_id(CSS_DB_Editor.CSS_DB.Get_Connection(), "Drivers", "license_id", "driver_name", CA_driver_CB.SelectedItem.ToString()), CSS_DB_Editor.CSS_DB.Get_id(CSS_DB_Editor.CSS_DB.Get_Connection(), "Models", "model_id", "model_name", CA_model_CB.SelectedItem.ToString()), CA_color_TB.Text });
                        }
                        catch
                        {
                            MessageBox.Show("Помилка вхідних даних! Переконайтеся у правильності введених даних і спробуйте ще раз.");
                        }
                    }
                    break;

                case "Service_Stations":
                    {
                        try
                        {
                            DGV_Add_Records(DataGridView, CSS_DB.Tables["Service_Stations"], new string[] {"1", SS_name_TB.Text, SS_address_TB.Text, SS_phone_TB.Text });
                        }
                        catch
                        {
                            MessageBox.Show("Помилка вхідних даних! Переконайтеся у правильності введених даних і спробуйте ще раз.");
                        }
                    }
                    break;

                case "Orders":
                    {
                        try
                        {
                            DGV_Add_Records(DataGridView, CSS_DB.Tables["Orders"], new string[] { "1", OR_car_CB.SelectedItem.ToString(), CSS_DB_Editor.CSS_DB.Get_id(CSS_DB_Editor.CSS_DB.Get_Connection(), "Mechanics", "mechanic_id", "mechanic_name", OR_mechanic_CB.SelectedItem.ToString()), OR_category_TB.Text, OR_cost_NUD.Value.ToString(), OR_sDate_DTP.Value.ToString(), OR_pDate_DTP.Value.ToString(), OR_fDate_DTP.Value.ToString() });
                        }
                        catch
                        {
                            MessageBox.Show("Помилка вхідних даних! Переконайтеся у правильності введених даних і спробуйте ще раз.");
                        }
                    }
                    break;
            }
        }

        private void Q_Button_Click(object sender, EventArgs e)
        {
            switch (Current_Table)
            {
                case "Q1":
                    {
                        int year;

                        try
                        {
                            year = Convert.ToInt32(Q_input_TB.Text);
                            DataSet Q1 = new DataSet(Current_Table);
                            SqlDataAdapter DA = new SqlDataAdapter(
                                "WITH cte AS "
                               + "( "
                               + "SELECT TOP(1) WITH TIES Mechanics.mechanic_name AS mech_name, COUNT(Orders.car_id) AS car_count "
                               + "FROM Cars "
                               + "INNER JOIN Orders ON Cars.car_id = Orders.car_id "
                               + "INNER JOIN Models ON Cars.model_id = Models.model_id "
                               + "INNER JOIN Mechanics ON Orders.mechanic_id = Mechanics.mechanic_id "
                               + String.Format("WHERE Models.model_prod_year <= {0} ", year)
                               + "GROUP BY Mechanics.mechanic_name "
                               + "ORDER BY 2 DESC "
                               + ") "
                               + "SELECT cte.mech_name "
                               + "FROM cte",
                                CSS_DB_Editor.CSS_DB.Get_Connection());
                            DA.Fill(Q1);
                            DataGrid_Fill(DataGridView, Q1.Tables[0]);
                        }
                        catch
                        {
                            MessageBox.Show("Помилка вхідних даних! Переконайтеся у правильності введених даних і спробуйте ще раз.");
                        }
                    }
                    break;
                case "Q2":
                    {
                        string brand;
                        try
                        {
                            brand = Q_input_TB.Text;
                            DataSet Q2 = new DataSet(Current_Table);
                            SqlDataAdapter DA = new SqlDataAdapter(
                                "SELECT Orders.order_id, Cars.car_id, Models.model_name, Models.model_brand, Mechanics.mechanic_name, Orders.order_category, Orders.order_cost, Orders.start_date, Orders.planned_date, Orders.end_date "
                                + "FROM Cars "
                                + "INNER JOIN Orders ON Cars.car_id = Orders.car_id "
                                + "INNER JOIN Models ON Cars.model_id = Models.model_id "
                                + "INNER JOIN Mechanics ON Orders.mechanic_id = Mechanics.mechanic_id "
                                + String.Format("WHERE (Orders.end_date NOT BETWEEN Orders.start_date AND Orders.planned_date) AND (Models.model_brand = '{0}')", brand),
                                //+ String.Format("WHERE (Orders.end_date NOT BETWEEN Orders.start_date AND Orders.planned_date)", model),
                                CSS_DB_Editor.CSS_DB.Get_Connection());
                            DA.Fill(Q2);
                            DataGrid_Fill(DataGridView, Q2.Tables[0]);
                        }
                        catch
                        {
                            MessageBox.Show("Помилка вхідних даних! Переконайтеся у правильності введених даних і спробуйте ще раз.");
                        }
                    }
                    break;
            }
        }



    }
}

