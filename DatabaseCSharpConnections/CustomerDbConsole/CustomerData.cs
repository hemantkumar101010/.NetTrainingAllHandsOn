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
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("insert into Customer values('"+name+"','"+email+"',"+mobile+",'"+address+"')",sqlConnection); 
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "Inserted";
        }
        public string UpdateCustomer()
        {
            return "";
        }
        public string DeleteCustomer()
        {
            return "";
        }
        public string SelectCustomer()
        {
            return "";
        }
        public string SelectCustomerById()
        {
            return "";
        }
    }
}
