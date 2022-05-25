using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationHandsOn
{
    internal class Deserialize
    {
        public void Deserialization()
        {
            String myString = "";

            // open file to read data
            FileStream fileStream = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\SerializationDeserializatin/MyDataInBinaryFormat.txt", FileMode.Open);

            // BinaryFormatter object will perform the Deserialization
            BinaryFormatter bf = new BinaryFormatter();

            // Deserialize() method Deserializes the data to the file
            myString = (string) bf.Deserialize(fileStream);
            fileStream.Close();

            Console.WriteLine("Your deserialize data is:");
            Console.WriteLine(myString);          
        }
    }
}
