using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Tupple HandsOn:

            TupleHandsOn tupleHandsOn = new TupleHandsOn();
            tupleHandsOn.ShowData();
            Console.WriteLine();

            //arrys of nums
            int[] numbers = { 0, 2, 34, 21, -4, -7, 456 };
            //defining a ne tuple for getting value from calling function
            (int minValInNumbers, int maxValInNumbers) outputTuple;

            outputTuple = tupleHandsOn.FindMinMax(numbers);
            Console.WriteLine($"Min Int value: {outputTuple.minValInNumbers} Max Int value: {outputTuple.maxValInNumbers}");
            Console.WriteLine();

            //assigning 2 tuples and destructing tuples into vars.
            tupleHandsOn.Assign2Tuples();
            Console.WriteLine();

            tupleHandsOn.TupleAsOutPara();
            */




            //accessing a jagged array 
            //Console.WriteLine("Accessing a jagged array");
            //JaggedArrayHandsOn.ShowDataOfJaggedArr();





           // Console.WriteLine("Assigning one struct var to another ");
            //StructHandsOn.StructDemo();




            //param keywordin Method parameter
            // You can send a comma-separated list of arguments of the
            // specified type.
            //MethodParameterHandsOn.UseParams(1, 2, 3, 4);
            //MethodParameterHandsOn.UseParams2(1, 'a', "test");



            //in keywords in method parameter
            int readonlyArgument = 44;
            // MethodParameterHandsOn.InArgExample(readonlyArgument);
            //Console.WriteLine(readonlyArgument);     // value is still 44



            //ref...
            int number = 1;
            //MethodParameterHandsOn.Method(ref number);
            //Console.WriteLine(number);


            // Declare an instance of Product and display its initial values.
             Product item = new Product("Fasteners", 54321);
             //System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n",item.ItemName, item.ItemID);

            // Pass the product instance to ChangeByReference.
             Product.ChangeByReference(ref item);
            //System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n",item.ItemName, item.ItemID);




            //out...
            //Variables passed as out arguments do not have to be initialized before being passed in a method call
            //The called method is required to assign a value before the method returns.
            int initializeInMethod;
            MethodParameterHandsOn.OutArgExample(out initializeInMethod);
            //Console.WriteLine(initializeInMethod);     // value is now 45






            //nullable
            //NullableHandsOn.DataInIntValue();





            //checked-unchecked
            //CheckedNUncheckedHandsOn.TestMethod();





            //Nested class
            // Create the instance of outer class
            NestedClassHandsOn obj1 = new NestedClassHandsOn();
            //obj1.method1();

            // This statement gives an error because
            // you are not allowed to access inner
            // class methods with outer class objects
            // obj1. method2();

            // Creating an instance of inner class
            NestedClassHandsOn.InnerClass obj2 = new NestedClassHandsOn.InnerClass();

            // Accessing the method of inner class
            //obj2.method2();





            //ConstNReadonly
            ConstNReadonlyHandsOn constNReadonlyHandsOn = new ConstNReadonlyHandsOn(12, 10);


            Console.ReadKey();
        }
    }
}
