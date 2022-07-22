using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace LB1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ourconnect = new OleDbConnection();
            ourconnect.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"D:\Учебные документы Жени\Базы данных\ЛБ1\Сессия.accdb");
            //Provider=Microsoft.ACE.OLEDB.12.0;Data Source="D:\Учебные документы Жени\Базы данных\ЛБ1\Сессия.accdb
            ourconnect.Open();
            OleDbCommand ourcommand = ourconnect.CreateCommand();
            ourcommand.CommandText = "SELECT * FROM Студенты";
            OleDbDataReader ourdatareader = ourcommand.ExecuteReader();

            while (ourdatareader.Read())
            {
                Console.WriteLine("{0, -6} {1, -15} {2, -1} {3, -4}", ourdatareader["ШифрСтудента"], ourdatareader["ФИО"], ourdatareader["Курс"], ourdatareader["Группа"]);
            }

            ourdatareader.Close();
            ourconnect.Close();
            Console.ReadKey();
        }
    }
}
