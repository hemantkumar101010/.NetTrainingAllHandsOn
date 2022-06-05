using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
    public class NullableHandsOn
    {
        public static void DataInIntValue()
        {
            //Nullable<int> value = null;
            int ? value = null;
           // value = 1;

            if (value.HasValue)
                Console.WriteLine(value.Value); // or Console.WriteLine(i)
            else
                Console.WriteLine("Null");

        }

    }
}
