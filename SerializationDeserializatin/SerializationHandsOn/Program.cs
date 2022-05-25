using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {

         Serialization serialization = new Serialization();
         serialization.Serialize();

         Deserialize deserialize = new Deserialize();
         deserialize.Deserialization();


        }
    }
}
