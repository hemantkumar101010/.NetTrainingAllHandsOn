using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
                    char choice1 = Convert.ToChar(Console.ReadLine());
                    switch (choice1)
                    {
                        case 'a':
                            librarian.AddBookToTheLibrary();
                            break; 
                        case 'b':
                            librarian.ShowAvailableBooksInLibrary();
                            break;                                                 
                    }                    
                     break;
                case 2:
                    Console.WriteLine("\t\t---------------WELCOME TO USER PORTAL---------------\t\t");
                    Console.WriteLine("");
                    Console.WriteLine("Please chooes one of the following action:");
                    Console.WriteLine("a. Borrow a book from the library.");
                    Console.WriteLine("b. See currently available books");
                    char choice2 = Convert.ToChar(Console.ReadLine());
                    switch (choice2)
                    {
                        case 'a':
                            users.BorrowBook();
                            break;
                        case 'b':
                            librarian.ShowAvailableBooksInLibrary();
                            break;
                    }
                    break;
            }
        }
    }
}
