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

        //HandsOn : 14-06-2022

        //select all records in account table
        public DataTable SelectAccount()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("select* from Account", sqlConnection);
            sqlConnection.Open();//connection state
            SqlDataReader sqlDataReader = cmd.ExecuteReader();//execute select statement

            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);

            sqlConnection.Close();
            return dataTable;
        }

        //select Account by AccountID
        public DataTable SelectAccountByAccountId(int accountId)
        {

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            string db = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("select * from Account where AcId=" + accountId, sqlConnection);
            sqlConnection.Open();//connection state is open

            SqlDataReader dataReader = cmd.ExecuteReader();//execute select statment

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            //DataTable, DataSet
            sqlConnection.Close(); //connection state is close
            return dataTable;
        }

        //delete a perticular row by Accountid
        public string DeleteInAccount(int accountId)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlCommand cmd = new SqlCommand("delete from Account where AcId=" + accountId, sqlConnection);
            sqlConnection.Open();//connection state is open
            int result = cmd.ExecuteNonQuery();//execute my sql commands and return no of rows affected
            sqlConnection.Close(); //connection state is close
            if (result == 0)
                return "Not Deleted";
            return "Deleted";
        }


        //update a perticular row by AccountId
        public string UpdateAccount()
        {
            Console.Write("Enter customer Id to update: ");
            int accountId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter account type  to update: ");
            string accountType = Console.ReadLine();


            Console.Write("Enter customerId  to update: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter bank name to update: ");
            string bankName =  (Console.ReadLine());

            Console.Write("Enter ac number to update: ");
            int acNumber = Convert.ToInt32(Console.ReadLine());


            //update account data into sqlserver
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlCommand cmd = new SqlCommand("update Account set AcType='" + accountType + "' , CustomerId='" + customerId + "' , BankName='" + bankName + "', AcNumber='" + acNumber + "' where AcId=" + accountId + "", sqlConnection);
            sqlConnection.Open();//connection state is open
            int result = cmd.ExecuteNonQuery();//execute my sql commands 1
            sqlConnection.Close(); //connection state is close
            if (result == 0)
                return "Not Updated";
            return "Updated";
        }
    }
}
