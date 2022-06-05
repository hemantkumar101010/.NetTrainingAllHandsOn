using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
    public class StructHandsOn
    {
        //Declaration of a struct
        struct Point
        {
            public int x, y;

            //Struct constructor
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public static void StructDemo()
        {
            //creating a struct variable("a value type")
            Point a = new Point(10, 10);
            //assignment one struct to another 
            //The assignment of a to b creates a copy of the value
            Point b = a;

            a.x = 100;
            //b is unaffected by the assignment to a.x
            System.Console.WriteLine(b.x);

            // Had "Point" instead been declared as a class, the output would be 100 because a and b would reference the same object.
        }

    }
}
