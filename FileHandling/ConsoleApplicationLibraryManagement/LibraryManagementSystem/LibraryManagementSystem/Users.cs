using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public  class Users :Librarian
    {
        public string userName, bookName;
        public int userId;
        string returnDate;
        public void BorrowBook()
        {
            Console.WriteLine("Enter Your name");
            userName = Console.ReadLine();

            Console.WriteLine("Enter Your user Id");
            userId = Convert.ToInt32(Console.ReadLine());
           

            Console.WriteLine("Enter the book name you want to borrow.");
            bookName = Console.ReadLine();

            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);

            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] lineArr = line.Split(',');
                if (Convert.ToInt32(lineArr[3]) == 0) 
                {
                    Console.WriteLine($"Sorry currently {bookName} book is not available in the library, try later!!");
                    return;
                }
                    
            }
            streamReaderObj.Close();
            fileStreamObj.Close();

            StoreBorrowerDetails(userId, userName, bookName);
            Console.WriteLine($"UserId: {userId} UserName: {userName} Thanks for borrowing {bookName} book!");
            Console.WriteLine("You have to pay 15 rs per day of a book!");

        }

        //overloading 
        public virtual void BorrowBook(int userId)
        {
            Console.WriteLine("Enter Your name");
            userName = Console.ReadLine();

            //Console.WriteLine("Enter Your user Id");
            //userId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the book name you want to borrow.");
            bookName = Console.ReadLine();

            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);

            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] lineArr = line.Split(',');
                if (Convert.ToInt32(lineArr[3]) == 0)
                {
                    Console.WriteLine($"Sorry currently {bookName} book is not available in the library, try later!!");
                    return;
                }

            }
            streamReaderObj.Close();
            fileStreamObj.Close();

            StoreBorrowerDetails(userId, userName, bookName);
            Console.WriteLine($"UserId: {userId} UserName: {userName} Thanks for borrowing {bookName} book!");
            Console.WriteLine("You have to pay 15 rs per day of a book!");

        }

        public void ReturnBook(string bookName,string userName,int userId )
        {
            UpdateBooksDetailFile(bookName);        
            returnDate = DateTime.Today.GetDateTimeFormats().First();
            StoreInventoryDetails(returnDate,bookName);
            UpdateBorrowerDetails(bookName,userId);
            Console.WriteLine("Your Book returned succesfully");
        }

        //overridinng base class method
        public new void UpdateBooksDetailFile(string bookName)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);

            FileStream fileStreamWObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\NewBookDetails1.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamWObj);
            //1,Java,James,5
            //2,ReactJS,Mike,3

            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] bookDataArr = line.Split(',');
                if (line.Contains(bookName))
                {
                    for (int i = 0; i < bookDataArr.Length; i++)
                    {
                        if (i == 3)
                            streamWriterObj.WriteLine(Convert.ToInt32((bookDataArr[3])) + 1);
                        else
                            streamWriterObj.Write(bookDataArr[i] + ",");

                    }
                }
                else
                {
                    for (int i = 0; i < bookDataArr.Length; i++)
                    {
                        if (i == 3)
                        {
                            streamWriterObj.WriteLine(bookDataArr[i]);
                        }
                        else
                            streamWriterObj.Write(bookDataArr[i] + ",");
                    }
                }
                //streamWriterObj.Write("\n");
            }
            streamWriterObj.Close();
            streamReaderObj.Close();
            fileStreamWObj.Close();
            fileStreamObj.Close();


            File.Delete(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt");
            File.Move(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\NewBookDetails1.txt", @"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt");

        }
        public void StoreInventoryDetails(string returnDate,string bookName)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\borrowerDetails.txt", FileMode.Open, FileAccess.Read);
            FileStream fileStreamWObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\inventoryDetails.txt", FileMode.Append, FileAccess.Write);

            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamWObj);

            DateTime dt1 = Convert.ToDateTime(returnDate);
            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] borrowerArr = line.Split(',');
                DateTime dt2 = Convert.ToDateTime(borrowerArr[3]);

                //1,Kriti,Java,10-06-2022
                if (borrowerArr[2] == bookName)
                {
                    var t = dt1 - dt2;
                    int rentPeriod = t.Days;

                    streamWriterObj.Write(borrowerArr[1] + ",");//userName
                    streamWriterObj.Write(borrowerArr[2] + ",");
                    streamWriterObj.Write(borrowerArr[3] + ",");//issued date
                    streamWriterObj.Write(DateTime.Now.ToShortDateString()+",");//return date
                    streamWriterObj.WriteLine(rentPeriod * 15);//total payment
                    //Console.WriteLine(borrowerArr[1] + "\t" + borrowerArr[0] + "\t" + rentPeriod * 15);
                }
            }
            streamWriterObj.Close();
            streamReaderObj.Close();
            fileStreamObj.Close();
        }
        public void ShowInventoryDetails()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\inventoryDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            Console.WriteLine("UserName\tBookName\tissuedDate\tReturnDate\tBill");
            
            while (streamReaderObj.Peek() > 0)
            {
               string line = streamReaderObj.ReadLine();
                string[] dataArr = line.Split(',');
                for (int i = 0; i < dataArr.Length; i++)
                {
                    Console.Write(dataArr[i]+"\t");
                    if (i == 1||i==0)
                    {
                        Console.Write("\t");  
                    }
                }
                Console.WriteLine();
            }

            streamReaderObj.Close();
            fileStreamObj.Close();

        }
    }

    public class Subusers : Users
    {
        //overriding
        public new void BorrowBook(int userId)
        {
            Console.WriteLine("Enter Your name");
            userName = Console.ReadLine();

            //Console.WriteLine("Enter Your user Id");
            //userId = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Enter the book name you want to borrow.");
            bookName = Console.ReadLine();

            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);

            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] lineArr = line.Split(',');
                if (Convert.ToInt32(lineArr[3]) == 0&& lineArr[1]==bookName)
                {
                    Console.WriteLine($"Sorry currently {bookName} book is not available in the library, try later!!");
                    return;
                }

            }
            streamReaderObj.Close();
            fileStreamObj.Close();

            StoreBorrowerDetails(userId, userName, bookName);
            Console.WriteLine($"UserId: {userId} UserName: {userName} Thanks for borrowing {bookName} book!");
            Console.WriteLine("You have to pay 15 rs per day of a book!");

        }
    }
}
