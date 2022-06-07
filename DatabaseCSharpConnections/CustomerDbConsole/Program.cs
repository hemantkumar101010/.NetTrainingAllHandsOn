using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDbConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer data inserted into customer table
            CustomerData customerData = new CustomerData();
            string result = customerData.InsertCustomer();
            Console.WriteLine(result);
            Console.ReadLine();

            //employee data inserted into employee table
            EmployeeData employeeData = new EmployeeData();
            string result1 = employeeData.InsertEmployee();
            Console.WriteLine(result1);
            Console.ReadLine();

            //account data inserted into account table
            AccountData accountData = new AccountData();
            string result2 = accountData.InsertAccountData();
            Console.WriteLine(result2);
            Console.ReadLine();
        }
    }
}
