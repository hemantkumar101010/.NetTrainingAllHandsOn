using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1. creating an Array holding value 0 to 9

            int[] basicArr1 = new int[10];
            //Assigning values from 0-9
            for (int i = 0; i < basicArr1.Length; i++)
            {
                basicArr1[i] = i;
            }
            //printting basicArr
            Console.WriteLine("Values inside basicArr are.");
            for (int i = 0; i < basicArr1.Length; i++)
            {
                Console.Write(basicArr1[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();



            //2.creating a nameArr

            string[] nameArr = { "Tim", "Martin", "Nikki", "Sara" };
            Console.WriteLine("Values of nameArr are:");
            for (int i = 0; i < nameArr.Length; i++)
            {
                Console.Write(nameArr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();



            //3. Creating a bool arr containing alternative true false

            String[] trueFalseArr = new String[10];
            for (int i = 0; i < trueFalseArr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    trueFalseArr[i] = "True";
                }
                else
                {
                    trueFalseArr[i] = "False";
                }
            }
            Console.WriteLine("Value inside trueFalseArr.");

            for (int i = 0; i < trueFalseArr.Length; i++)
            {
                Console.Write(trueFalseArr[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();



            //4: Creating a list of different Icecream flavors

            List<string> list = new List<string>();

            Console.WriteLine("Enter no of items you want to store");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter the flavor name.");
                list.Add(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("Size of the flavor list are:" + list.Count);


            //Removing item at index 2(3rd item in the list)
            list.RemoveAt(2);

            Console.WriteLine("List of Flavors are:");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Size of the flavor list after removing a item is:" + list.Count);

        }
    }
}
