using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBillProject;
using TestClassLibrary;

namespace DllClassLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
             EBill eBill = new EBill();
            //eBill.WriteCustomerDetailsFile();
            Customers customers = new Customers();
            //Console.WriteLine("Customer detail of  a perticular customer Id");
            //customers.ShowCustomersDetails(1);
            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine("Bill Report Of a perticular Customers.");
            //customers.ShowEBill(4);
            //Console.WriteLine();
            //Console.WriteLine();

            Console.WriteLine("Bill Report Of All Customers.");
            customers.ShowEbBillReport();


            Class1 c = new Class1();
            c.TestOutside();
            

        } 
    }  
}
