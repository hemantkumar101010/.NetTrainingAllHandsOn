using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryManagementSystem
{
    public class SignInSignUp
    {
        int i;
        public void LibrarianSignInUp()
        {
            SignInSignUp signInSignUp = new SignInSignUp();
        REGISTER:
            Console.WriteLine("Type 1 to regiseter.");
            Console.WriteLine("Type 2 to login.");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
                Console.WriteLine("Enter your name: ");
                string librarianName = Console.ReadLine();

                Console.WriteLine("Enter your mailId: ");
                string email = Console.ReadLine();

                if (Program.librarianRegistrationRecords.ContainsKey(email))
                {
                    Console.WriteLine($"{email} is already registered just log in or register with new mail id !");
                    goto REGISTER;
                }
                else
                {
                    Console.WriteLine("Set a password: ");
                    string setPassword = Console.ReadLine();

                    Program.librarianRegistrationRecords.Add(email, (librarianName, setPassword));
                    Console.WriteLine($"{email} registered succesfully");
                    goto REGISTER;

                }
            }
            else if (i == 2)
            {
            VALIDMAIL:
                Console.WriteLine("Enter your mailId: ");
                string email = Console.ReadLine();
                //validating mail
                if (Program.librarianRegistrationRecords.ContainsKey(email))
                {
                VALIDPW:
                    Console.WriteLine("Enter your user ac password:");
                    string pw = Console.ReadLine();

                    //validating pw
                    foreach (var item in Program.librarianRegistrationRecords)
                    {
                        if (item.Key == email)
                        {
                            if (item.Value.setPassword == pw)
                            {
                                Console.WriteLine($"hey {item.Value.librarianName} Welcome to your librarian account !");
                                Console.WriteLine();
                                signInSignUp.LibrarianFeatures();
                            }
                            else
                            {
                                Console.WriteLine($"hey {item.Key} ! Please enter a valid password!");
                                goto VALIDPW;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{item.Key} mail is not found , enter a valid mail");
                            goto VALIDMAIL;
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"{email} is not registered, please register fist into librarian portal!");
                    goto REGISTER;
                }

            }
        }
        public void LibrarianFeatures()
        {
            TOP1:
            Librarian librarian = new Librarian();
            Users users = new Users();
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
                    //Console.WriteLine("Press 2 to go librarian menu");
                    Console.WriteLine("Press 1 to go librarian menu");
                    //Console.WriteLine("Press 0 to go starting menu");
                    int i = Convert.ToInt32(Console.ReadLine());
                    if (i == 1)
                        goto TOP1;

                    else
                    {
                        Console.WriteLine("Enter a valid number.");
                        break;
                    }
                // break;

                case 'b':
                    Console.WriteLine("");
                    librarian.ShowAvailableBooksInLibrary();

                   // Console.WriteLine("Press 2 to go librarian menu");
                    Console.WriteLine("Press 1 to go librarian menu");
                    //Console.WriteLine("Press 0 to go starting menu");
                    int i2 = Convert.ToInt32(Console.ReadLine());
                    if (i2 == 1)
                        goto TOP1;
                    else
                    {
                        Console.WriteLine("Enter a valid number.");
                        break;
                    }
                case 'c':
                    Console.WriteLine("");
                    users.ShowInventoryDetails();

                   // Console.WriteLine("Press 2 to go librarian menu");
                    Console.WriteLine("Press 1 to go librarian menu");
                    //Console.WriteLine("Press 0 to go starting menu");
                    int i3 = Convert.ToInt32(Console.ReadLine());
                    if (i3 == 1)
                        goto TOP1;
                    else
                    {
                        Console.WriteLine("Enter a valid number.");
                        break;
                    }
                case 'd':
                    Console.WriteLine("");
                    librarian.ShowBorrowerDetails();
                    //Console.WriteLine("Press 2 to go librarian menu");
                    Console.WriteLine("Press 1 to go librarian menu");
                    //Console.WriteLine("Press 0 to go starting menu");
                    int i4 = Convert.ToInt32(Console.ReadLine());
                    if (i4 == 1)
                        goto TOP1;
                    else
                    {
                        Console.WriteLine("Enter a valid number.");
                        break;
                    }
            }
        }
        public void UserSignInUp()
        {
            SignInSignUp signInSignUp = new SignInSignUp();
        REGISTER:
            Console.WriteLine("---------------WELCOME TO USERS PORTAL---------------");
            
            Console.WriteLine("Enter 1 to register:");
            Console.WriteLine("Enter 2 to signin:");
            ENTERVALID:
            try
            {
                 i = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine("Enter either 1 or 2 only...");
                goto ENTERVALID;
            }
           
            if ( i == 1)
            {
                //generating userID 
                Random random = new Random();
                int userId = random.Next(1000, 10000);

                //storing data in dictionary
                Console.WriteLine("Enter your name: ");
                string userName = Console.ReadLine();

                Console.WriteLine("Enter your mailId: ");
                string email = Console.ReadLine();

                if (Program.userRegistrationRecords.ContainsKey(email))
                {
                    Console.WriteLine($"{email} is already registered just log in or register with new mail id !");
                    goto REGISTER;
                }
                else
                {
                    Console.WriteLine("Set a password: ");
                    string setPassword = Console.ReadLine();
                    Program.userRegistrationRecords.Add(email, (userId, userName, setPassword));
                    Console.WriteLine($"{email} registered succesfully and {userName} your userID is: {userId}!");
                    goto REGISTER;

                }
            }
            else if (i == 2)
            {
                Console.WriteLine("Enter your mailId: ");
                string email = Console.ReadLine();
                //validating mail
                if (Program.userRegistrationRecords.ContainsKey(email))
                {
                    VALIDPW:
                    Console.WriteLine("Enter your user ac password:");
                    string pw = Console.ReadLine();

                    //validating pw
                    foreach (var item in Program.userRegistrationRecords)
                    {
                       if(item.Key == email)
                        {
                            if (item.Value.setPassword == pw)
                            {
                                Console.WriteLine($"hey {item.Value.userName} userID: {item.Value.userId} Welcome to your user account.");
                                Console.WriteLine();
                                signInSignUp.UserFeatures();
                                goto REGISTER;
                            }
                            else
                            {
                                Console.WriteLine($"hey {email}, Please enter a valid password.");
                                goto VALIDPW;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"{email} is not registered, please register fist into user portal!");
                    goto REGISTER;
                }
            }

        }
        public void UserFeatures()
        {
            TOP1:
            Librarian librarian = new Librarian();
            Users users = new Users();
            Console.WriteLine("");
            Console.WriteLine("Please chooes one of the following action:");
            Console.WriteLine("a. Borrow a book from the library.");
            Console.WriteLine("b. See currently available books");
            Console.WriteLine("c. Return a book");
            Console.WriteLine("d. Logout");
            char choice2 = Convert.ToChar(Console.ReadLine());
            switch (choice2)
            {
                
                case 'a':
                    Subusers subusers = new Subusers();
                    Console.WriteLine("");
                    Console.WriteLine("Choose 1 without entering userID else 2 with userID");
                    int j = Convert.ToInt32(Console.ReadLine());
                    if (j == 1)
                        users.BorrowBook();
                    else if (j == 2)
                    {
                        Console.WriteLine("Enter your userID if you are old borrower!");
                        int userID = Convert.ToInt32(Console.ReadLine());
                        subusers.BorrowBook(userID);
                    }

                    //Console.WriteLine("Press 2 to go librarian menu");
                    Console.WriteLine("Press 1 to go users menu");
                    Console.WriteLine("Press 2 to go logout");
                    //Console.WriteLine("Press 0 to go starting menu");
                    int i = Convert.ToInt32(Console.ReadLine());
                    if (i == 1)
                        goto TOP1;
                    else if(i == 2)
                    {
                        return;

                    }
                    break;
                case 'b':
                    librarian.ShowAvailableBooksInLibrary();
                    //Console.WriteLine("Press 2 to go librarian menu");
                    Console.WriteLine("Press 1 to go users menu");
                    Console.WriteLine("Press 2 to go logout");
                    //Console.WriteLine("Press 0 to go starting menu");
                    int i1 = Convert.ToInt32(Console.ReadLine());
                    if (i1 == 1)
                        goto TOP1;
                    else if (i1 == 2)
                    {
                        return;

                    }
                    break;
                case 'c':

                    Console.WriteLine("Enter book Name");
                    string bookName = (Console.ReadLine());
                    Console.WriteLine("Enter user Name");
                    string userName = (Console.ReadLine());

                    Console.WriteLine("Enter your user id:");
                    int userId= Convert.ToInt32(Console.ReadLine());

                    users.ReturnBook(bookName, userName,userId);

                    //Console.WriteLine("Press 2 to go librarian menu");
                    Console.WriteLine("Press 1 to go users menu");
                    Console.WriteLine("Press 2 to go logout");
                    //Console.WriteLine("Press 0 to go starting menu");
                    int i2 = Convert.ToInt32(Console.ReadLine());
                    if (i2 == 1)
                        goto TOP1;
                    else if (i2 == 2)
                    {
                        return;

                    }
                    break;
                case 'd':
                    {
                        return;
                    }
            }
        }
    }

    internal class Program : SignInSignUp
    {
        public static Dictionary<string, (int userId, string userName, string setPassword)> userRegistrationRecords = new Dictionary<string, (int userId, string userName, string setPassword)>();
        public static Dictionary<string, (string librarianName, string setPassword)> librarianRegistrationRecords = new Dictionary<string, (string librarianName, string setPassword)>();
        static int choice;

        static void Main(string[] args)
        {
            SignInSignUp signInSignUp = new SignInSignUp();

            

            //user registration records
            Program.userRegistrationRecords.Add("heman@5502",(3550, "Hemant","heman"));
            Program.userRegistrationRecords.Add("rahul@123", (1211, "Rahul", "rahul"));

            //librarian registration records
            Program.librarianRegistrationRecords.Add("kriti@123", ("Kriti","kriti"));

            Librarian librarian = new Librarian();
            Users users = new Users();

            Console.WriteLine("---------------WELCOME TO LIBRARY MANAGEMENT SYSTEM---------------");
            Console.WriteLine("Please signin/signup into any of the following account:");
            Console.WriteLine("1. Librarian");
            Console.WriteLine("2. Users");
            Console.WriteLine("");
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
                    signInSignUp.LibrarianSignInUp();
                    break;
                case 2:
                    signInSignUp.UserSignInUp();
                    break;
            }
        }
    }
}