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
            
             XmlFormatSerialization xmlFormatSerialization = new XmlFormatSerialization();
             //xmlFormatSerialization.SerializeInXmlFormat();
             //xmlFormatSerialization.DeSerializeFromXmlFormatToListEBill();

             JsonFormatSerialization jsonFormatSerialization = new JsonFormatSerialization();
            //jsonFormatSerialization.SerializeInJsonFromat();
            //jsonFormatSerialization.DeSerializeFromJsonFromatToListEBill();

            Serialization serialization = new Serialization();
            //serialization.Serialize();

            Deserialize deserialize = new Deserialize();
            deserialize.Deserialization();
        }
    }
}
