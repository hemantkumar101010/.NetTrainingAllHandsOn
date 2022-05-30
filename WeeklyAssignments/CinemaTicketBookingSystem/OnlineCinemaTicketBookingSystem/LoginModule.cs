using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinemaTicketBookingSystem
{
    public class LoginModule
    {
        public void RegisterOrLogin()
        {
            Console.WriteLine("---------------WELCOME TO ONLINE CINEMA TICKET BOOKING SYSTEM---------------");
            Console.WriteLine("Please log in into any of the following account:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer");
            Console.WriteLine("");

            int choice = Convert.ToInt32(Console.ReadLine());
            LoginModule loginModule = new LoginModule();    
            CustomerModule customerModule = new CustomerModule();
            AdminModule adminModule = new AdminModule();    

            switch (choice)
            {
              
                case 1:
                    Console.WriteLine("---------------WELCOME TO ADMIN PORTAL---------------");
                    Console.WriteLine("");
                    Console.WriteLine("Please chooes one of the following action:");
                    Console.WriteLine("a. Update the movie portal");
                    Console.WriteLine("b. Booking Report");

                    char choice1 = Convert.ToChar(Console.ReadLine());
                    switch (choice1)
                    {
                        case 'a':
                            Console.WriteLine("");
                            adminModule.AddAvailableMovie();
                            Console.WriteLine();
                            break; 
                        case 'b':
                            adminModule.BookingReports();
                            break;
                        
                    }

                    break;
                case 2:
                TOP1:

                    Console.WriteLine("\t---------------WELCOME TO CUSTOMER PORTAL---------------\t");
                    Console.WriteLine("");
                    Console.WriteLine("Please chooes one of the following action:");
                    Console.WriteLine("a. Search a movie");
                    Console.WriteLine("b. Book a movie");
                    Console.WriteLine("c. Cancle ticket");
                    Console.WriteLine("d. Check your Booking status");
                    char choice2 = Convert.ToChar(Console.ReadLine());
                    switch (choice2)
                    {
                        case 'a':
                            customerModule.SearchMovie();
                            break;
                        case 'b':
                            customerModule.BookAMovie();
                            break;
                        case 'c':
                            customerModule.CancleYourTicket();
                            break;
                        case 'd':
                            Console.WriteLine("Enter your booking id");
                            int bookingId =Convert.ToInt32( Console.ReadLine());
                            customerModule.BookingStatus(bookingId);
                            break;
                      
                    }
                    goto TOP1;
            }
        }       
    }
}
