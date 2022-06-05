using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateHandsOn
{
    public class SampleDelegate
    {
        // Declares a delegate for a method that takes in an int and returns a string.
         public delegate string myMethodDelegate(int myInt);

        // Defines some methods to which the delegate can point

            // Defines an instance method.
            public string myStringMethod(int myInt)
            {
                if (myInt > 0)
                    return ("positive");
                if (myInt < 0)
                    return ("negative");
                return ("zero");
            }

            // Defines a static method.
            public static string mySignMethod(int myInt)
            {
                if (myInt > 0)
                    return ("+");
                if (myInt < 0)
                    return ("-");
                return ("");
            }
    }
}
