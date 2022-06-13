using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedBankingSystem
{
    internal class SavingAccount : Account
    {

        //declaring a static field account type bcz it's remain constant to all Saving acount type objects
         string accType = "Saving Account";


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
            Console.WriteLine("Min allowed balance for saving account is : " + 2000);
        }
        public override void TotalAllowedTransections()
        {
            Console.WriteLine("Number of transection is limited in saving account type");
        }

        //overiding interestRate function
        public override void InterestRate()
        {
            Console.WriteLine("Interest rate for saving account type is 4% ");
        }


    }
}
