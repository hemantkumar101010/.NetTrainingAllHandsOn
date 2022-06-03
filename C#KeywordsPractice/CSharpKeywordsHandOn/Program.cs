using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpKeywordsHandOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TupleHandsOn tupleHandsOn = new TupleHandsOn();
            tupleHandsOn.ShowData();
            Console.WriteLine();

            //arrys of nums
            int[] numbers = { 0, 2, 34, 21, -4, -7, 456 };
            //defining a ne tuple for getting value from calling function
            (int minValInNumbers, int maxValInNumbers) outputTuple;

            outputTuple =  tupleHandsOn.FindMinMax(numbers);
            Console.WriteLine($"Min Int value: {outputTuple.minValInNumbers} Max Int value: {outputTuple.maxValInNumbers}");
            Console.WriteLine();

            //assigning 2 tuples and destructing tuples into vars.
            tupleHandsOn.Assign2Tuples();
            Console.WriteLine();

            tupleHandsOn.TupleAsOutPara();

        }
    }
}
