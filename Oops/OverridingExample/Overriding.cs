using System;
namespace OverridingImplimentation{
   
    class Program{
       public static void Main(string[] args)
        {
            PermanentEmployee obj = new PermanentEmployee();
            obj.CalculateSalary(30);
            obj.numberOfDays();

            PartTimeEmployee obj1 = new PartTimeEmployee();
            obj1.CalculateSalary(30);
            obj1.numberOfDays();

            // PermanentEmployee obj3 = new PartTimeEmployee();
            // obj3.CalculateSalary(30);
            // obj3.numberOfDays();

            Employee obj2 = new PartTimeEmployee();
            obj2.CalculateSalary(30);
            obj2.numberOfDays();
        }
    }

}
