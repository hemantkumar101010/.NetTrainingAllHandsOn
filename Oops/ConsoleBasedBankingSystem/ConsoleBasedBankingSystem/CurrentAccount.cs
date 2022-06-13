using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedBankingSystem
{
    internal class CurrentAccount : Account
    {
        //declaring a static field account type bcz it's remain constant to all current acount type objects
         string accType = "Current Account";

        //Providing implimentation for account class abstract methods
          public override void AcHolderDetails()
        {
            Console.WriteLine("Enter account holder name");
            acHolderName = Console.ReadLine();

            Console.WriteLine("Enter bank name");
            bankName = Console.ReadLine();

            Console.WriteLine("Enter city name");
            cityName = Console.ReadLine();

            Console.WriteLine("Enter ac. number");
            acNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Account Holder Name: " + acHolderName);
            Console.WriteLine("Bank name: " + bankName);
            Console.WriteLine("City Name: " + cityName);
            Console.WriteLine("Account Number " + acNumber);
            Console.WriteLine("Account Type: " + accType);
        }
        public override void MinAllowedBalance()
        {
            Console.WriteLine("Min. allowed balance for current account : " + 0);
        }
        public override void TotalAllowedTransections()
        {
            Console.WriteLine("Number of transection is unlimited in current account type");
        }

        //overriding interestRate function 
        public override void InterestRate()
        {
            Console.WriteLine("Interest rate for current account type is 0% ");
        }
    }
}
