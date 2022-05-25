using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCountingSystem
{
    internal class Program
    {
       static  ArrayList al = new ArrayList();
       
        static void Main(string[] args)
        {
            //reading string from the local file
            FileStream fileStream = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\Collections\CharacterCountingSystem\string.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.Close();
            fileStream.Close();

            // Read entire text file content in one string  
            string myString = File.ReadAllText(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\Collections\CharacterCountingSystem\string.txt");
            myString.ToLower();

            //creating obj of charsCounting
            CharsCounting charsCounting = new CharsCounting();
            
            //assigning char-frequency pairs in Dictionary collection
            Dictionary<char, int> result= charsCounting.CountFrequencyOfEachString(myString);

            //printing all char-frequency pairs
            foreach (char c in result.Keys)
            {
                Console.WriteLine(c+": " + result[c]);
            }
        }
    }
}
//Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.