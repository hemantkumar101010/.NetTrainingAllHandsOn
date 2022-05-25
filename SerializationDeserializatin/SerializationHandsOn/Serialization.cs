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
            String myString = "Hello my name is Hemant Tiwari! j j;a vs;fklaj iajf;asdfa sjfwoeiru2389tq57289uveltasvfserdkj3un58934upetrevnstgj983u54nwihtneuisdutgj4ontwu3486593jw6geuintrsh;ktuu3wgn95ung3wrtsldsgjesrtw bejt ertj eioter egAnd i am from Srinagar Uttarakhand india";

            // Create file to save the data.
            FileStream fileStream = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\SerializationDeserializatin/MyDataInBinaryFormat.txt", FileMode.Create);

            // BinaryFormatter object will perform the serialization
            BinaryFormatter bf = new BinaryFormatter();

            // Serialize() method serializes the data to the file
            bf.Serialize(fileStream, myString);

            fileStream.Close();
        } 
    }
}
//network understand xml or jason data