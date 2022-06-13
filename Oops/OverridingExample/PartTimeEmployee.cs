using System;
namespace OverridingImplimentation{
   
    class PartTimeEmployee:Employee{
         public override void CalculateSalary(int workingDays){
           int salary = workingDays*300;
           Console.WriteLine("Salary of part time employees are : " + salary);
         }
         public override void numberOfDays(){
             Console.WriteLine("Employees can have only 1 leaves in a month");
         }
    }

}