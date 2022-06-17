using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//connect sql server
using System.Data;//datatable data set

namespace CustomerDbConsole
{
    //ado- connected mode(connection open and close say explicitly) and disconnected mode
    public class CustomerData
    {
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=BankDb;Integrated Security=True";
        public string InsertCustomer()
        {
            Console.Write("Enter Customer name: ");
            string name = (Console.ReadLine());

            Console.Write("Enter Customer email: ");
            string email = (Console.ReadLine());

            Console.Write("Enter Customer mobile number: ");
            int mobile = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer address: ");
            string address = (Console.ReadLine());


            //insert into db
            #region connected-mode
            //SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            //SqlCommand cmd = new SqlCommand("insert into Customer values('" + name + "','" + email + "'," + mobile + ",'" + address + "')", sqlConnection);
            //sqlConnection.Open();
            //cmd.ExecuteNonQuery();
            //sqlConnection.Close();
            //return "Inserted";
            #endregion

            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlDataAdapter sda = new SqlDataAdapter("insert into Customer values('" + name + "','" + email + "'," + mobile + ",'" + address + "')", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return "Inserted";
            #endregion
        }
        //HandsOn : 14-06-2022

        //select all records in customer table
        public DataTable SelectCustomer()
        {
            #region connected-mode
            //SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            //SqlCommand cmd = new SqlCommand("select* from Customer", sqlConnection);
            //sqlConnection.Open();//connection state
            //SqlDataReader sqlDataReader = cmd.ExecuteReader();//execute select statement

            //DataTable dataTable = new DataTable();
            //dataTable.Load(sqlDataReader);

            //sqlConnection.Close();
            //return dataTable;
            #endregion

            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlDataAdapter sda = new SqlDataAdapter("select* from Customer", sqlConnection);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            return dataTable;
            #endregion
        }

        //select book by CustomerID
        public DataTable SelectCustomerByCustomerId(int customerId)
        {
            #region connected-mode
            //SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            //string db = sqlConnection.Database;
            //SqlCommand cmd = new SqlCommand("select * from Customer where CustId=" + customerId, sqlConnection);
            //sqlConnection.Open();//connection state is open

            //SqlDataReader dataReader = cmd.ExecuteReader();//execute select statment

            //DataTable dataTable = new DataTable();
            //dataTable.Load(dataReader);
            ////DataTable, DataSet
            //sqlConnection.Close(); //connection state is close
            //return dataTable;
            #endregion

            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            string db = sqlConnection.Database;
            SqlDataAdapter sda = new SqlDataAdapter("select * from Customer where CustId=" + customerId, sqlConnection);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            return dataTable;
            #endregion
        }

        //delete a perticular row by Customerid
        public string DeleteInCustomer(int customerId)
        {
            #region connected-mode
            //SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            //SqlCommand cmd = new SqlCommand("delete from Customer where CustId=" + customerId, sqlConnection);
            //sqlConnection.Open();//connection state is open
            //int result = cmd.ExecuteNonQuery();//execute my sql commands and return no of rows affected
            //sqlConnection.Close(); //connection state is close
            //if (result == 0)
            //    return "Not Deleted";
            //return "Deleted";
            #endregion

            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlDataAdapter sda = new SqlDataAdapter("delete from Customer where CustId=" + customerId, sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return "Deleted";
            #endregion
        }


        //update a perticular row by CustomerId
        public string UpdateCustomer()
        {
            Console.Write("Enter customer Id to update: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter customer name  to update: ");
            string customerName = Console.ReadLine();


            Console.Write("Enter mail  to update: ");
            string email = (Console.ReadLine());

            Console.Write("Enter Mobile number to update: ");
            int mobile = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter address to update: ");
            string address =(Console.ReadLine());


            //update book data into sqlserver
            #region connected-mode
            //SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            //SqlCommand cmd = new SqlCommand("update Customer set CustName='" + customerName + "' , Email='" + email + "' , Mobile=" + mobile + ", CustAddress='" + address + "' where CustId=" + customerId + "", sqlConnection);
            //sqlConnection.Open();//connection state is open
            //int result = cmd.ExecuteNonQuery();//execute my sql commands 1
            //sqlConnection.Close(); //connection state is close
            //if (result == 0)
            //    return "Not Updated";
            //return "Updated";
            #endregion

            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlDataAdapter sda = new SqlDataAdapter("update Customer set CustName='" + customerName + "' , Email='" + email + "' , Mobile=" + mobile + ", CustAddress='" + address + "' where CustId=" + customerId + "", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return "Updated";
            #endregion
        }
    }
}
