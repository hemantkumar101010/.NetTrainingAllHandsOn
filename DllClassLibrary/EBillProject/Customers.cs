using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBillProject
{
    public class EBill
    {
        private int CustomerId { get; set; }
        private string CustomerName { get; set; }
        private int NoOfUnits { get; set; }
        public static int UnitPerCost { get; set; } = 7;
        private int Total { get; set; }

        public void WriteCustomerDetailsFile()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\DllClassLibrary\EBillProject/CustomersInfo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);

            //List<EBill> list = new List<EBill>();

            Console.WriteLine("Enter no. of EBill objects you want to store.");
            int totalCustomers = Convert.ToInt32(Console.ReadLine());

            //initializing EBill details from inputs
            for (int i = 0; i < totalCustomers; i++)
            {
                EBill ebillObj = new EBill();

                Console.WriteLine("Enter Customer Id");
                CustomerId = Convert.ToInt32(Console.ReadLine());
                streamWriterObj.Write(CustomerId + ",");

                Console.WriteLine("Enter Customer name");
                CustomerName = (Console.ReadLine());
                streamWriterObj.Write(CustomerName + ",");

                Console.WriteLine("Enter No of units");
                NoOfUnits = Convert.ToInt32(Console.ReadLine());
                streamWriterObj.Write(NoOfUnits + ",");

                Total = 7 * NoOfUnits;
                streamWriterObj.WriteLine(Total);

                //list.Add(ebillObj);
            }
            streamWriterObj.Close();
            fileStreamObj.Close();
            Console.WriteLine("File write operation completed");

            Console.WriteLine();

        }
    }
    public class Customers
    {
               
        public void ShowCustomersDetails(int inputCustomerId)
        {
            FileStream fileStreams = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\DllClassLibrary\EBillProject/CustomersInfo.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreams);

            Console.WriteLine("CustomerId\tName\t\tNoOFUnits\tTotalBill");
            /* 1,Hemant,123,861*/
            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                if (line.StartsWith(Convert.ToString(inputCustomerId)))
                {
                    string[] customersArr = line.Split(',');
                    for (int i = 0; i < customersArr.Length; i++)
                    {
                        Console.Write(customersArr[i]+"\t\t");
                    }
                    Console.WriteLine();    
                }
            }

        }

        public void ShowEBill(int inputCustomerID)
        {
            FileStream fileStreams = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\DllClassLibrary\EBillProject/CustomersInfo.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreams);

            Console.WriteLine("Total Bill of customer id "+ inputCustomerID);
            /* 1,Hemant,123,861*/
            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                if (line.StartsWith(Convert.ToString(inputCustomerID)))
                {
                    string[] customersArr = line.Split(',');
                   
                        Console.Write(customersArr[3] );
                    
                }
                  
            }
        }

        public void ShowEbBillReport()
        {
            FileStream fileStreams = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\DllClassLibrary\EBillProject/CustomersInfo.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreams);

            Console.WriteLine("customerID\tTotalBill");
         
            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
    
                string[] customersArr = line.Split(',');

                Console.WriteLine(customersArr[0] + "\t\t" + customersArr[3]);     

            }
        }

    }
}
