using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingAndInventoryManagementSystem
{
    internal class ProductModule
    {
        //        3. Product Module - Manages all the Product
        //Read product details(Productid, categorytype, productname, quantity, price) from console and store it in product.txt file
        int productId, quantity; float price;
        string categoryType, productName;
        public void WriteFile()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\source\repos\BillingAndInventoryManagementSystem\productFile.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);

            int counter = 1, totalProductsRecords;
            Console.WriteLine("Enter total number Of Product Module records you want to store");
            totalProductsRecords = Convert.ToInt32(Console.ReadLine());

            streamWriterObj.WriteLine("Productid\tcategorytype\t productname\tPquantity\tprice");

            while (counter <= totalProductsRecords)
            {
                Console.WriteLine("Enter product Id");
                productId = Convert.ToInt32(Console.ReadLine());
                streamWriterObj.Write(productId + "\t\t");

                Console.WriteLine("Enter category type");
                categoryType = Console.ReadLine();
                streamWriterObj.Write(categoryType + "\t\t");

                Console.WriteLine("Enter product name");
                productName = (Console.ReadLine());
                streamWriterObj.Write(productName + "\t\t");

                Console.WriteLine("Enter Quantity");
                quantity = Convert.ToInt32(Console.ReadLine());
                streamWriterObj.Write(quantity + "\t\t");

                Console.WriteLine("Enter price");
                price = Convert.ToInt32(Console.ReadLine());
                streamWriterObj.WriteLine(price);
                counter++;
                Console.WriteLine();

            }
            streamWriterObj.Close();
            fileStreamObj.Close();
            Console.WriteLine("File write operation completed");
        }
    }
}