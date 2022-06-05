using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateHandsOn
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; } 
        public int Experiance { get; set; }

       
        public static bool promote(Employee emp)
        {
            if (emp.Experiance >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool promoteBySal(Employee emp)
        {
            if (emp.Salary >= 30000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public delegate bool isPromote(Employee emp);
        public static void PromoteEmp(List<Employee> EmployeeList, isPromote IsEligible)
        {
            foreach (Employee emp in EmployeeList)
            {
                if (IsEligible(emp))//logic condition  
                {
                    Console.WriteLine(emp.Name + " Promoted");
                }
            }
        }

    }
}
