using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpKeywordsHandOn
{
    internal class TupleHandsOn
    {
        public void ShowData()
        {
            //defining a tuple 
            (int id, string fName, string lName, int age, string city) employeeTuple = (100, "Hemant", "Tiwari", 24, "Srinagar");

            Console.WriteLine("Accessing a tuple type");
            Console.WriteLine($"Id Of Emp: {employeeTuple.id}, fName: {employeeTuple.fName}, lName: {employeeTuple.lName}, age: {employeeTuple.age}, city {employeeTuple.city}");
            Console.WriteLine();
            // You cannot define methods in a tuple type, but you can use the methods provided by .NET

            Console.WriteLine("Accessing .net methods with a tuple");
            Console.WriteLine(employeeTuple.ToString());
            Console.WriteLine();

            //defining tuple with arbitrary(Not predefined) elements
            var customerOrderTuple = (1, "Iphone", "03 / 06 / 2022", 10, "Srinagar");
            Console.WriteLine("Accessing arbitrary elements tuple");
            Console.WriteLine($"ProductName: {customerOrderTuple.Item2}, OrderDate: {customerOrderTuple.Item3}");
            Console.WriteLine();

        }
        //Use cases of tuples
        //tuples as a method return type
       public (int min, int max) FindMinMax(int[] input)
        {
            if (input is null || input.Length == 0)
            {
                throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
            }

            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var i in input)//0, 2, 34, 21, -4, -7, 456
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            var resultTuple = (min, max);
            //grouping min and max in a tuple
            Console.WriteLine("using tuple as a method return type");
            return resultTuple;
        }

        //Tuple assignment and deconstruction
        public void Assign2Tuples()
        {

            //Tuple assignment
            (int, double) tuple1 = (17, 3.14);
            (double First, double Second) tuple2 = (0.0, 1.0);
            tuple2 = tuple1;
            Console.WriteLine("Assignining tuple1 into tuple2");
            Console.WriteLine($"{nameof(tuple2)}: {tuple2.First} and {tuple2.Second}");
            Console.WriteLine();

            (double A, double B) tuple3 = (2.0, 3.0);
            tuple3 = tuple2;
            Console.WriteLine("Assignining tuple2 into tuple3");
            Console.WriteLine($"{nameof(tuple3)}: {tuple3.A} and {tuple3.B}");
            Console.WriteLine();

            //Tuple destruction         
            var tuple = ("post office", 3.6);

            //assignment operator = to deconstruct a tuple instance in separate variables. 
            (string destination, double distance) = tuple;
            Console.WriteLine("deconstruct a tuple instance in separate variables.");
            Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
            Console.WriteLine();

        }
        //Tuple equality
        //operators compare members of the left-hand operand with the corresponding members of the right-hand operand
        public void TupleEquality()
        {
            (int a, byte b) left = (5, 10);
            (long a, int b) right = (5, 10);
            Console.WriteLine(left == right);  // output: True
            Console.WriteLine(left != right);  // output: False

            var t1 = (A: 5, B: 10);
            var t2 = (B: 5, A: 10);
            Console.WriteLine(t1 == t2);  // output: True
            Console.WriteLine(t1 != t2);  // output: False
        }

        //Tuples as out parameters
        public void TupleAsOutPara()
        {
            var limitsLookup = new Dictionary<int, (int Min, int Max)>()
            {
                [2] = (4, 10),
                [4] = (10, 20),
                [6] = (0, 23)
            };

            if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits))
            {
                Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
            }
            // Output:
            // Found limits: min is 10, max is 20
        }

    }
}
