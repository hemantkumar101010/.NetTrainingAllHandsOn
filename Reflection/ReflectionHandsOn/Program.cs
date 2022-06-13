using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Employee);


            var members = type.GetMembers();
            Console.WriteLine($"Following {members.Count()} members are available for Eyployee type : ");
            foreach (var member in members)
            {
                Console.WriteLine($"{member} ");
            }
            Console.WriteLine();

           
            var properties = type.GetProperties();
            Console.WriteLine($"{properties.Count()} properties are in Eyployee type : ");
            foreach (var property in properties)
            {
               Console.WriteLine(property);   
            }


            Console.WriteLine();
            var methods = type.GetMethods();
            Console.WriteLine($"Following {methods.Count()} methods are available for employee type object ");
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name+" ");
            }
            
   

        }
    }
}
