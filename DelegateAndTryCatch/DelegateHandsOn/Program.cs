using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            List<Employee> emp = new List<Employee>
           {
                 new Employee{ Id = 101, Name = "Ravi", Salary = 20000, Experiance = 3 },
                 new Employee{ Id = 102, Name = "John", Salary = 30000, Experiance = 5 },
                 new Employee{ Id = 103, Name = "Mary", Salary = 50000, Experiance = 8 },
                 new Employee{ Id = 104, Name = "Mike", Salary = 40000, Experiance = 2 },
           };
     
            //1: Delegate object
            Employee.isPromote isPromoted = new Employee.isPromote(Employee.promote);//passing method reference of promote method

            isPromoted += new Employee.isPromote(Employee.promoteBySal);//passing method reference of promoteBySal method

           // Employee.PromoteEmp(emp, isPromoted);






            //2 : creating myDelegate class object
            SampleDelegate sampleDelegate = new SampleDelegate();
            // Creates one delegate for each method. For the instance method, an
            // instance (mySC) must be supplied. For the static method, use the
            // class name.
            SampleDelegate.myMethodDelegate myD1 = new SampleDelegate.myMethodDelegate(SampleDelegate.mySignMethod);
            SampleDelegate.myMethodDelegate myD2 = new SampleDelegate.myMethodDelegate(sampleDelegate.myStringMethod);

            // Invokes the delegates.
            //Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 5, myD1(5), myD2(5));
            //Console.WriteLine("{0} is {1}; use the sign \"{2}\".", -3, myD1(-3), myD2(-3));
            //Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 0, myD1(0), myD2(0));


            //3: Build-in delegate func.
            PrebuildDelegateFunc.Add = PrebuildDelegateFunc.SumOfWeight;
            PrebuildDelegateFunc.AtheletePerformance("Hemant", PrebuildDelegateFunc.Add);
 

        }
    }
}
