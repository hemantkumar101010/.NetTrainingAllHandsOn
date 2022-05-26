using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBillProject;

namespace DllClassLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EBill eBill = new EBill();
           // eBill.WriteCustomerDetailsFile();
            Customers customers = new Customers();
            customers.ShowCustomersDetails(1);
            Console.WriteLine();
            Console.WriteLine();

            customers.ShowEBill(4);
            Console.WriteLine();
            Console.WriteLine();

            customers.ShowEbBillReport();
            
        }
    }  
}
