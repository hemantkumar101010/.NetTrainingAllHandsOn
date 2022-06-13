using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedBankingSystem
{
    internal abstract class Account : AccoundHolderI
    {
        //declaration of fields
        public string acHolderName, bankName, cityName;
        protected int acNumber;

        //only declaring 3 abstract methods
        public abstract void AcHolderDetails();
        public abstract void MinAllowedBalance();
        public abstract void TotalAllowedTransections();

        //defining one non-abstract method
        public virtual void InterestRate()
        {
            Console.WriteLine("Interest rate is diff. for diff. account types");
        }


        //Implementing AccountHolderI Interface in Account Class
        public void Withdraw()
        {
            Console.WriteLine("withdraw function called");
        }
        public void CheckCurrentBalance()
        {
            Console.WriteLine("Check balance function called");
        }
        public void ResetAtmPin()
        {
            Console.WriteLine("Reset pin function called");
        }
       public void TransferMoney()
        {
            Console.WriteLine("Transfer money function called");
        }

    }
}
