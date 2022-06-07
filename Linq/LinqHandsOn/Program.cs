using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //deffered and immidiate query execution method
            //LinqHandsOn.DefferedNImmediateExeMethod();

            //single and singleOrDefaul linq method for fetch data
            //LinqHandsOn.SignleNDefaultSingleMethod();

            //first and firstOrdefault linq mehtod to fech data
            //LinqHandsOn.FirstNFirstDefaultMethod();

            //groupby linq method
            LinqGroupBy.LinqGroupByMethod();
        }

    }
}
