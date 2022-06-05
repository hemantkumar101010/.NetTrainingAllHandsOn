using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
    public class MethodParameterHandsOn
    {
        //params parameter keyword HandsOn1
        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
        //params parameter keyword HandsOn2
        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        
        //in parameter key..
        public static void InArgExample(in int number)
        {
            // cann't assign to in in number bcz its readonly 
            //number = 19;
        }

        //ref...
        public static void Method(ref int refArgument)
        {
            refArgument = refArgument + 44;
        }

        //out...
        public static void OutArgExample(out int number)
        {
            number = 45;
        }

    }
}
