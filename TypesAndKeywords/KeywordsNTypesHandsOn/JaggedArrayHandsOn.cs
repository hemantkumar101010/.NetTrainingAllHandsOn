using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
    public class JaggedArrayHandsOn
    {
        public static void ShowDataOfJaggedArr()
        {
            //Declaring and initializing jagged array
            // initializing the array upon declaration
            int[][] jaggedArray =
            {
                new int[] { 3, 5, 7, },//index 0 
                new int[] { 1, 0, 2, 4, 6 },//index 1
                new int[] { 1, 6 },//index 2
                new int[] { 1, 0, 2, 4, 6, 45, 67, 78 }//index 3
            };

            //accessing jagged arr
            foreach (var jagged in jaggedArray)
            {
                foreach (var item in jagged)
                {
                    Console.Write(item + "  ");
                }
                Console.WriteLine();
            }
        }

    }
}
