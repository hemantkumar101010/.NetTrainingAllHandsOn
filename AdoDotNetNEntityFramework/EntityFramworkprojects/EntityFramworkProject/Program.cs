using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkProject
{

    //database first approach
    internal class Program
    {
        static void Main(string[] args)
        {
            //object of db entity
            BankDbEntities bankDbEntities = new BankDbEntities();

            //accessing the accounts property in db
            var accountData = bankDbEntities.Accounts.ToList();
            //insert into account
            Account account1 = new Account();
            //account1.AcType = "Saving";
            //account1.CustomerId = 203;
            //account1.BankName = "HDFC";
            //account1.AcNumber = 111122;

            //bankDbEntities.Accounts.Add(account1);
            //bankDbEntities.SaveChanges();


            //select from account table
            Console.WriteLine("Account-Table:");
            foreach (var account in accountData)
            {
                Console.WriteLine($"{account.AcId}\t{account.AcType}\t{account.CustomerId}\t{account.BankName}\t{account.AcNumber}");
            }
            Console.WriteLine();


            //insert into customer
             var customerData = bankDbEntities.Customers.ToList();
            //Customer customer = new Customer();
            //customer.CustName = "Deepak";
            //customer.Email = "deep@1243";
            //customer.Mobile = 231323;
            //customer.CustAddress = "Delhi";

            //bankDbEntities.Customers.Add(customer);//insert into custoemr table value()
            //bankDbEntities.SaveChanges(); //execute and save data in db

            //select customer talbe
            Console.WriteLine("Customer-Table:");
            foreach (var customer in customerData)
            {
                Console.WriteLine($"{customer.CustId}\t{customer.CustName}\t{customer.Email}\t{customer.Mobile}\t{customer.CustAddress}");
            }

        }
    }
}
