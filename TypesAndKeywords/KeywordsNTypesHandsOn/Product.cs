using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsNTypesHandsOn
{
        public class Product
        {
            public Product(string name, int newID)
            {
                ItemName = name;
                ItemID = newID;
            }

            public string ItemName { get; set; }
            public int ItemID { get; set; }

        public static void ChangeByReference(ref Product itemRef)
        {
            // Change the address that is stored in the itemRef parameter.
            itemRef = new Product("Stapler", 99999);

            // You can change the value of one of the properties of
            // itemRef. The change happens to item in Main as well.
            itemRef.ItemID = 123456;
        }
    }
}
