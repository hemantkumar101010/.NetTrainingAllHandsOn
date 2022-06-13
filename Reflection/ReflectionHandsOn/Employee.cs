using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionHandsOn
{
    public class Employee
    {
        int id { get; set; }    
        public string empName { get; set; }   
        string empAddress { get; set; }
        public string empDomain { get; set; } = "IT";

        public void GetEmpDetails()
        {
            Console.WriteLine("GetEmpDetail function called");

        }
        public void isPromoted()
        {
            Console.WriteLine("isPromoted func. called");
        }
    }
}
