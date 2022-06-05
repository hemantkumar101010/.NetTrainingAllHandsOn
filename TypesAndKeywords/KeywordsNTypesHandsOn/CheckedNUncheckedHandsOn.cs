using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
    public class CheckedNUncheckedHandsOn
    {
        public static void TestMethod()
        {
            //not giving exception
            int val1 = int.MaxValue;
            Console.WriteLine(val1 + 2);

            //using checked gives overflow exep.
            //checked
            //{
            //    int val = int.MaxValue;
            //    Console.WriteLine(val + 2);
            //}
            //uncheked skip exceptions and continue further execution
            unchecked
            {
                int val2 = int.MaxValue;
                Console.WriteLine(val2 + 2);
            }
            Console.WriteLine("Method statements finished");
        }
    }
}
