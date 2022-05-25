using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationHandsOn
{
    internal class Serialization
    {
        public void Serialize()
        {
            String myString = "Hello my name is Hemant Tiwari! And i am from Srinagar Uttarakhand india ";

            // Create file to save the data.
            FileStream fileStream = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\SerializationDeserializatin/myDatafile.txt", FileMode.Create);

            // BinaryFormatter object will perform the serialization
            BinaryFormatter bf = new BinaryFormatter();

            // Serialize() method serializes the data to the file
            bf.Serialize(fileStream, myString);

            fileStream.Close();
        } 
    }
}
