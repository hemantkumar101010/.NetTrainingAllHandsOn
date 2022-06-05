using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
    public class ConstNReadonlyHandsOn
    {
        // Constant fields
        public const int myvar = 10;
        public const string str = "Constant filed";

        // readonly variables
        public readonly int myvar1;
        public readonly int myvar2;

      
        // Values of the readonly
        // variables are assigned
        // Using constructor
        public ConstNReadonlyHandsOn(int b, int c)
        {

             myvar1 = b;
             myvar2 = c;
            Console.WriteLine("Display value of myvar1 {0}, " + "and myvar2 {1}", myvar1, myvar2);
            // Display the value of Constant fields
            Console.WriteLine("The value of myvar: {0}", myvar);
            Console.WriteLine("The value of str: {0}", str);
        }
    }
}
