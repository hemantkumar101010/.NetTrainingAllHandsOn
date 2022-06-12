using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Librarian
    {
        string bookName, bookWriter;
        int bookId, noOfCopies;
        string issueDate;
        //string returnDate;
        public void AddBookToTheLibrary()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);



            int counter = 1, totalBooks;
            Console.WriteLine("Enter total number Of books you want to store in the library");
            totalBooks = Convert.ToInt32(Console.ReadLine());
            //streamWriterObj.WriteLine("BookId\tBookName\tBookWriter");
           
            while (counter <= totalBooks)
            {

                //Console.WriteLine("Enter Book Id.");
               // bookId = Convert.ToInt32(Console.ReadLine());
                Random random = new Random();
                bookId = random.Next(100,10000);
                streamWriterObj.Write(bookId + ",");

                Console.WriteLine("Enter book name.");
                bookName = Console.ReadLine();
                streamWriterObj.Write(bookName + ",");

                Console.WriteLine("Enter book writer name.");
                bookWriter = Console.ReadLine();
                streamWriterObj.Write(bookWriter+",");

                Console.WriteLine($"Enter available copies of {bookName}.");
                noOfCopies = Convert.ToInt32(Console.ReadLine());
                streamWriterObj.WriteLine(noOfCopies);
                counter++;
            }
            streamWriterObj.Close();
            fileStreamObj.Close();
            Console.WriteLine("File write operation completed");

        }


        public void StoreBorrowerDetails(int userID,string borrowerName,string bookName)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\borrowerDetails.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);

                streamWriterObj.Write(userID + ",");

                streamWriterObj.Write(borrowerName + ",");

                streamWriterObj.Write(bookName+",");
                 
                issueDate= DateTime.Now.ToShortDateString();
                streamWriterObj.Write(issueDate+",");

               streamWriterObj.WriteLine("Not-Returned");


                streamWriterObj.Close();
                fileStreamObj.Close();

                Console.WriteLine("File write operation completed");
                //Here time to update the libraryin bookDetails.txt(Remaining books in library after giving to a user)
                UpdateBooksDetailFile(bookName);

        }

        public void UpdateBorrowerDetails(string bookName,int userId)
        {

            FileStream fileStreamObj1 = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\borrowerDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj1);
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\borrowerDetails1.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);


            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] lineArr = line.Split(',');
                if (line.Contains(bookName)&& line.Contains(Convert.ToString(userId)))
                {
                    for (int i = 0; i < lineArr.Length; i++)
                    {
                        if (i == 4)
                            streamWriterObj.WriteLine("Returned");
                        else
                          streamWriterObj.Write(lineArr[i]+",");
                    }
                    
                }
                else
                {
                    for (int i = 0; i < lineArr.Length; i++)
                    {
                        if (i == 4)
                            streamWriterObj.WriteLine(lineArr[i]);
                        else
                            streamWriterObj.Write(lineArr[i]+",");
                    }
                }
            }

            streamReaderObj.Close();
            streamWriterObj.Close();
            fileStreamObj.Close();
            fileStreamObj1.Close();

            File.Delete(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\borrowerDetails.txt");
            File.Move(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\borrowerDetails1.txt", @"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\borrowerDetails.txt");

        }

        public void ShowBorrowerDetails()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\borrowerDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            Console.WriteLine("UserId\tUserName\tBookName\tIssueDate\tStatus");
            while (streamReaderObj.Peek() > 0)
            {//C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem
                string line = streamReaderObj.ReadLine();
                string[] DataArr = line.Split(',');

                for (int i = 0; i < DataArr.Length; i++)
                {
                    Console.Write(DataArr[i] + "\t");
                    if (i == 1||i==2||i==4)
                    {
                        Console.Write("\t");
                    }
                }
                Console.WriteLine("");
            }
            streamReaderObj.Close();
            fileStreamObj.Close();

        }

        public void UpdateBooksDetailFile(string bookName)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);

            FileStream fileStreamWObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\NewBookDetails.txt", FileMode.Append, FileAccess.Write);
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
                            streamWriterObj.WriteLine(Convert.ToInt32((bookDataArr[3])) - 1);
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
            fileStreamObj.Close();
            streamReaderObj.Close();
            fileStreamWObj.Close();

            File.Delete(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt");
            File.Move(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\NewBookDetails.txt", @"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt");

        }

       public void ShowAvailableBooksInLibrary()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\FileHandling\ConsoleApplicationLibraryManagement\LibraryManagementSystem\bookDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            Console.WriteLine("BookId\tBookName\tBookAuthor\tNoOfCopies");
            while (streamReaderObj.Peek() > 0)
            {//1,Java,James,5
               // 2,ReactJS,Mike,3

                string line = streamReaderObj.ReadLine();
                string[] bookDataArr = line.Split(',');
                
                for(int i = 0; i < bookDataArr.Length; i++)
                {
                    Console.Write(bookDataArr[i] + "\t");
                    if (i == 1||i==2)
                    {
                        Console.Write("\t");
                    }
                }
                Console.WriteLine("");
            }
            streamReaderObj.Close();
            fileStreamObj.Close();
        }
    }
}
