using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TOP0:

            Console.WriteLine("---------------WELCOME TO LIBRARY MANAGEMENT SYSTEM---------------");
            Console.WriteLine("Please log in into any of the following account:");
            Console.WriteLine("1. Librarian");
            Console.WriteLine("2. Users");
            Console.WriteLine("");

            int choice = Convert.ToInt32(Console.ReadLine());
            Librarian librarian = new Librarian();
            Users users = new Users();

            switch (choice)
            {
                case  1:
                    Console.WriteLine("---------------WELCOME TO LIBRARIAN PORTAL---------------");
                    Console.WriteLine("");
                    Console.WriteLine("Please chooes one of the following action:");
                    Console.WriteLine("a. Add a book in the library.");
                    Console.WriteLine("b. Show the current available books in the library.");
                    Console.WriteLine("c. Show current inventory details.");
                    Console.WriteLine("d. Show all borrowers details");
                    char choice1 = Convert.ToChar(Console.ReadLine());
                    switch (choice1)
                    {
                        case 'a':
                            Console.WriteLine("");
                            librarian.AddBookToTheLibrary();
                            Console.WriteLine();
                            goto TOP0;
                           // break;
                        
                        case 'b':
                            Console.WriteLine("");
                            librarian.ShowAvailableBooksInLibrary();

                            goto TOP0;
                        case 'c':
                            Console.WriteLine("");
                            users.ShowInventoryDetails();

                            goto TOP0;
                        case 'd':
                            Console.WriteLine("");
                            librarian.ShowBorrowerDetails();
                            goto TOP0;


                    }               
                    
                     break;
                case 2:
                    TOP1:

                    Console.WriteLine("\t---------------WELCOME TO USER PORTAL---------------\t");
                    Console.WriteLine("");
                    Console.WriteLine("Please chooes one of the following action:");
                    Console.WriteLine("a. Borrow a book from the library.");
                    Console.WriteLine("b. See currently available books");
                    char choice2 = Convert.ToChar(Console.ReadLine());
                    switch (choice2)
                    {
                        case 'a':
                            Console.WriteLine("");
                            users.BorrowBook();

                            goto TOP1;
                        case 'b':
                            librarian.ShowAvailableBooksInLibrary();
                            goto TOP1;
                    }
                    break;
            }
        }
    }
}
