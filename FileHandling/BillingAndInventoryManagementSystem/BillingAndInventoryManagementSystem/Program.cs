using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingAndInventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserModule userModuleObj = new UserModule();
            userModuleObj.WriteFile();
            Console.WriteLine();

            CategoryModule categoryModuleObj = new CategoryModule();
            categoryModuleObj.WriteFile();
            Console.WriteLine();

            ProductModule productModuleObj = new ProductModule();
            productModuleObj.WriteFile();
            Console.WriteLine();

            PurchaseAndSalesMoudule purchaseAndSalesMouduleObj = new PurchaseAndSalesMoudule();
            purchaseAndSalesMouduleObj.WriteFile();
        }
    }
}
