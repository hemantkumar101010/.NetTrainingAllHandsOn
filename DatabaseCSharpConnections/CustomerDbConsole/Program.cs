using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDbConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CustomerData customerData = new CustomerData();

            //Customer data inserted into customer table
            Console.WriteLine("Insert into customer table");
            string result = customerData.InsertCustomer();
            Console.WriteLine(result);
            Console.WriteLine();
            //Console.ReadLine();


            //select query
            Console.WriteLine("select into customer table");
            DataTable dt = customerData.SelectCustomer();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //update
            Console.WriteLine("update into customer table");
            customerData.UpdateCustomer();
            Console.WriteLine();

            //Delete
            Console.WriteLine("delete into customer table");
            customerData.DeleteInCustomer(1);
            Console.WriteLine();

            //select by custId
            Console.WriteLine("select by id into customer table");
            DataTable dt1 = customerData.SelectCustomerByCustomerId(201);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    Console.Write(dt1.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();





            //employee data inserted into employee table
            Console.WriteLine("Insert into employee table");
            EmployeeData employeeData = new EmployeeData();
            string result1 = employeeData.InsertEmployee();
            Console.WriteLine(result1);
            Console.ReadLine();

            //select query
            DataTable dtemp = employeeData.SelectEmployee();
            for (int i = 0; i < dtemp.Rows.Count; i++)
            {
                for (int j = 0; j < dtemp.Columns.Count; j++)
                {
                    Console.Write(dtemp.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }

            //select by id 
            DataTable dtemp1 = employeeData.SelectEmployeeByEmployeeId(2);
            for (int i = 0; i < dtemp1.Rows.Count; i++)
            {
                for (int j = 0; j < dtemp1.Columns.Count; j++)
                {
                    Console.Write(dtemp1.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //update
            employeeData.UpdateEmployee();
            Console.WriteLine();

            //delete
            string res = employeeData.DeleteInEmployee(3);
            Console.WriteLine(res);
            Console.WriteLine();


            
            
            
            //account data inserted into account table
            AccountData accountData = new AccountData();

            Console.WriteLine("Insert into account table");
            string result2 = accountData.InsertAccountData();
            Console.WriteLine(result2);
            Console.WriteLine();

            DataTable dtac = accountData.SelectAccount();
            for (int i = 0; i < dtac.Rows.Count; i++)
            {
                for (int j = 0; j < dtac.Columns.Count; j++)
                {
                    Console.Write(dtac.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //update
            accountData.UpdateAccount();
            Console.WriteLine();

            //delete
            accountData.DeleteInAccount(1015);
            DataTable dtac2 = accountData.SelectAccountByAccountId(1000);
            for (int i = 0; i < dtac2.Rows.Count; i++)
            {
                for (int j = 0; j < dtac2.Columns.Count; j++)
                {
                    Console.Write(dtac2.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
