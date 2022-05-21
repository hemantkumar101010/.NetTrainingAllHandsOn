using System;
namespace OverridingImplimentation{
   
    class Employee{
         public virtual void CalculateSalary(int workingDays){
           int salary = workingDays*500;
           Console.WriteLine("Salary of full time employees are : " + salary);
         }
         public virtual void numberOfDays(){
             Console.WriteLine("Employees can have only 2 leaves in a month");
         }
    }

}