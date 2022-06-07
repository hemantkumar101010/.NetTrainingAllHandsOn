using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//connect sql server
using System.Data;//datatable data set

namespace CustomerDbConsole
{
    public class EmployeeData
    {
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=BankDb;Integrated Security=True";
        public string InsertEmployee()
        {


            Console.Write("Enter employee name: ");
            string name = (Console.ReadLine());

            Console.Write("Enter employee post name: ");
            string empPostName = (Console.ReadLine());

            Console.Write("Enter age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter employee customer id: ");
            int empCustomerId = Convert.ToInt32(Console.ReadLine());

            //insert into db
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("insert into Employee values('" + name + "','" + empPostName + "'," + age + "," + empCustomerId + ")", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "Inserted";
        }
    }
}
