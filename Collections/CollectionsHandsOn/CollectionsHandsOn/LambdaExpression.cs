using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsHandsOn
{
    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class LambdaExpression
    {
       public void LambdaMethod()
        {
            // Example 1:
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);

            foreach (var num in evenNumbers)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
            Console.WriteLine();

            // Example 2
            List<Dog> dogs = new List<Dog>() 
            {
            new Dog { Name = "Rex", Age = 4 },
            new Dog { Name = "Sean", Age = 0 },
            new Dog { Name = "Stacy", Age = 3 }
            };
            var names = dogs.Select(x => x.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);

            }
            Console.WriteLine();

     
            //Using Lambda Expressions with Anonymous Types
            var newDogsList = dogs.Select(x => new { Age = x.Age, FirstLetter = x.Name[0] });
            foreach (var item in newDogsList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //Sorting using a lambda expression
            var sortedDogs = dogs.OrderByDescending(x => x.Age);
            foreach (var dog in sortedDogs)
            {
                Console.WriteLine(string.Format("Dog {0} is {1} years old.", dog.Name, dog.Age));
            }
        } 
    }
}
