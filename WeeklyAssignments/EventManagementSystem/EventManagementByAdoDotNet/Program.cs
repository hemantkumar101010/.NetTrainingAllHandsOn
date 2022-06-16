using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementByAdoDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Main:
            Console.WriteLine("---------------WELCOME TO EVENT MANAGEMENT SYSTEM---------------");
            Console.WriteLine("Please signin/signup into any of the following account:");
            Console.WriteLine("1. Super Admin");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Customer");
            Console.WriteLine("");
            int choice;
        ENTERVALID:
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Enter either 1 or 2 only...");
                goto ENTERVALID;

            }

            switch (choice)
            {
                case 1:
                    SuperAdmin superAdmin = new SuperAdmin();
                    superAdmin.IMSuperAdmin();
                  
                        goto Main;
               
                case 2:
                    Admin admin = new Admin();
                    admin.Adminportal();
                    goto Main;
                case 3:
                    Customer customer = new Customer();
                    customer.CustomerPortal();                  
                    goto Main;

            }
        }
    }
}
