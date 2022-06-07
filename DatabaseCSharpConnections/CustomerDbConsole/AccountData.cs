using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//connect sql server
using System.Data;//datatable data set

namespace CustomerDbConsole
{
    public class AccountData
    {
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=BankDb;Integrated Security=True";
        public string InsertAccountData()
        {

            Console.Write("Enter Account type: ");
            string acType = (Console.ReadLine());

            Console.Write("Enter Customer id: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter bank name: ");
            string bankName = (Console.ReadLine());

            Console.Write("Enter Account number: ");
            int acNumber = Convert.ToInt32(Console.ReadLine());

            //insert into db
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("insert into Account values('" + acType + "'," + customerId + ",'" + bankName + "','" +acNumber  + "')", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "Account Data Inserted";
        }
    }
}
