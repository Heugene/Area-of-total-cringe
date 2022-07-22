using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CSS_DB_Editor
{
    class CSS_DB
    {
        public static SqlConnection Get_Connection()
        {
            SqlConnection result = new SqlConnection(ConfigurationManager.ConnectionStrings["CSS_DB"].ConnectionString);
            return result;
        }

        public static void Connection_Open(ref SqlConnection Connection)
        {
            Connection.Open();
        }

        public static void Connection_Close(ref SqlConnection Connection)
        {
            Connection.Close();
        }

        public static bool Connection_Test()
        {
            SqlConnection Connection = Get_Connection();
            Connection.Open();
            bool result;
            if (Connection.State == ConnectionState.Open)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Connection.Close();
            return result;
        }

        public static DataTable Get_Table(string name, SqlConnection Connection)
        {
            DataTable result = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(String.Format("SELECT * FROM {0}", name), Connection);
            Connection_Open(ref Connection);
            DA.Fill(result);
            Connection_Close(ref Connection);
            return result;
        }

        public static void Add_Record(ref DataTable DT, string[] values)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = new SqlCommand(String.Format("SELECT * FROM {0}", DT.TableName), Get_Connection());
            SqlCommandBuilder CB = new SqlCommandBuilder(DA);
            DA.InsertCommand = CB.GetInsertCommand();
            DA.UpdateCommand = CB.GetUpdateCommand();
            DT.Rows.Add(values);
            DA.Update(DT);
        }

        public static void Delete_Record(ref DataTable DT, int Index)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = new SqlCommand(String.Format("SELECT * FROM {0}", DT.TableName), Get_Connection());
            SqlCommandBuilder CB = new SqlCommandBuilder(DA);
            DA.DeleteCommand = CB.GetDeleteCommand();
            DA.UpdateCommand = CB.GetUpdateCommand();
            DT.Rows[Index].Delete();
            DA.Update(DT);
        }

        public static DataTable Get_Query_Table(SqlConnection Connection, string CommandText)
        {
            DataTable result = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(CommandText, Connection);
            Connection_Open(ref Connection);
            DA.Fill(result);
            Connection_Close(ref Connection);
            return result;
        }

        public static string Get_id(SqlConnection Connection, string TableName, string id_Column, string name_Column, string Input)
        {
            Connection_Open(ref Connection);
            SqlCommand select_id = Connection.CreateCommand();
            select_id.CommandText = String.Format("SELECT {0} FROM {1} WHERE {2} = '{3}';", id_Column, TableName, name_Column, Input);
            string result = select_id.ExecuteScalar().ToString();
            Connection_Close(ref Connection);
            return result;
        }

        public static void Save_All(DataSet DS)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            SqlCommandBuilder CB = new SqlCommandBuilder();
            for (int i = 0; i < DS.Tables.Count; i++)
            {
                DA.SelectCommand = new SqlCommand(String.Format("SELECT * FROM {0}",  DS.Tables[i].TableName), Get_Connection());
                CB.DataAdapter = DA;
                DA.UpdateCommand = CB.GetUpdateCommand();
                DA.Update(DS.Tables[i]);
            }
        }
    }
}
