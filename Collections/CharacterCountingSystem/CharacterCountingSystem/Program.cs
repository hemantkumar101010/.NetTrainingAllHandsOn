using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCountingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharsCounting charsCounting = new CharsCounting();

            Console.WriteLine("Enter a string.");
            string myString = Console.ReadLine(); 
            
            Dictionary<char, int> result= charsCounting.CountFrequencyOfEachString(myString.ToLower());

           foreach(char c in result.Keys)
            {
                Console.WriteLine(c+": " + result[c]);
            }

        }
    }
}
//Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.