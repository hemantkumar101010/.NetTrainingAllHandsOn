using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
    public class NestedClassHandsOn
    {
        // Method of outer class
        public void method1()
        {
            Console.WriteLine("Outer class method");
        }

        // Inner class
        public class InnerClass
        {

            // Method of inner class
            public void method2()
            {
                Console.WriteLine("Inner class Method");
            }
        }
    }
}
