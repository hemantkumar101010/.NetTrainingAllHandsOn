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

        //HandsOn : 14-06-2022

        //select all records in Employee table
        public DataTable SelectEmployee()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("select* from Employee", sqlConnection);
            sqlConnection.Open();//connection state
            SqlDataReader sqlDataReader = cmd.ExecuteReader();//execute select statement

            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);

            sqlConnection.Close();
            return dataTable;
        }

        //select Employee by EmployeeID
        public DataTable SelectEmployeeByEmployeeId(int employeeId)
        {

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            string db = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("select * from Employee where EmpId=" + employeeId, sqlConnection);
            sqlConnection.Open();//connection state is open

            SqlDataReader dataReader = cmd.ExecuteReader();//execute select statment

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            //DataTable, DataSet
            sqlConnection.Close(); //connection state is close
            return dataTable;
        }

        //delete a perticular row by Customerid
        public string DeleteInEmployee(int EmployeeId)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlCommand cmd = new SqlCommand("delete from Employee where EmpId=" + EmployeeId, sqlConnection);
            sqlConnection.Open();//connection state is open
            int result = cmd.ExecuteNonQuery();//execute my sql commands and return no of rows affected
            sqlConnection.Close(); //connection state is close
            if (result == 0)
                return "Not Deleted";
            return "Deleted";
        }


        //update a perticular row by EmployeeId
        public string UpdateEmployee()
        {
            Console.Write("Enter employee Id to update: ");
            int EmployeeId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter employee name  to update: ");
            string EmployeeName = Console.ReadLine();


            Console.Write("Enter post name  to update: ");
            string postName = (Console.ReadLine());

            Console.Write("Enter age to update: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter emp. custid to update: ");
            string empcusId = (Console.ReadLine());


            //update book data into sqlserver
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlCommand cmd = new SqlCommand("update Employee set EmpName='" + EmployeeName + "' , EmpPostName='" + postName + "' , EmpAge=" + age + ", EmpCustomerId='" + empcusId + "' where EmpId=" + EmployeeId + "", sqlConnection);
            sqlConnection.Open();//connection state is open
            int result = cmd.ExecuteNonQuery();//execute my sql commands 1
            sqlConnection.Close(); //connection state is close
            if (result == 0)
                return "Not Updated";
            return "Updated";
        }
    }
}
