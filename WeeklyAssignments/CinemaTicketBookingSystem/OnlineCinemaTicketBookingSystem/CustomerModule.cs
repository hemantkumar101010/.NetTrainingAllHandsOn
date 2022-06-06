using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinemaTicketBookingSystem
{
    public class CustomerModule
    {
        public void SearchMovie()
        {
            Console.WriteLine("Enter movie name");
            string movieName = Console.ReadLine();

            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\availableMovieDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamreaderObj = new StreamReader(fileStreamObj);
            Console.WriteLine("Following movies are available in different-different cities");
            Console.WriteLine("");
            while (streamreaderObj.Peek() > 0)
            {
                   string line = streamreaderObj.ReadLine();
                   string[] lineArr = line.Split(',');

                if (lineArr[1].Contains(movieName))
                {
                    foreach (string s in lineArr)
                    {
                        Console.Write(s+"\t");
                    }
                    Console.WriteLine();
                }
            }

        }

        public void SearchMovie(string movieName, string cityName)
        {

            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\availableMovieDetails.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamreaderObj = new StreamReader(fileStreamObj);
            Console.WriteLine("");

            while (streamreaderObj.Peek() > 0)
            {
                string line = streamreaderObj.ReadLine();
                string[] lineArr = line.Split(',');

                if (line.StartsWith(cityName) && lineArr[1].Contains(movieName))
                {
                    Console.WriteLine(movieName + " is currently available in "+cityName);
                    return;
                }
                
            }

        }
        public void BookAMovie()
        {
            Console.WriteLine("Enter Movie Name");
            String movieName = Console.ReadLine();

            Console.WriteLine("Enter City Name");
            String CityName = Console.ReadLine(); 
            
            SearchMovie(movieName, CityName);

            FileStream fileStream = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\bookingRecords.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
  
            Random r = new Random();
            int lastBookingId;
            lastBookingId= r.Next(0, 1000);
            string status = "Active";
            string bookingDateTime = Convert.ToString(DateTime.Now);

            streamWriter.Write(lastBookingId + ",");
            streamWriter.Write(movieName + ",");
            streamWriter.Write(CityName + ",");
            streamWriter.Write(bookingDateTime+",");
            streamWriter.WriteLine(status);
            streamWriter.Close();
            fileStream.Close();         

            Console.WriteLine("Thanks your ticket booked successfull Your Orderid is "+lastBookingId);

        }

        public void CancleYourTicket()
        {
            Console.WriteLine("Enter your Booking ID");
            int bookingId = Convert.ToInt32(Console.ReadLine());


            FileStream fileStream = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\bookingRecords.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamreader = new StreamReader(fileStream);

            FileStream fileStream1 = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\bookingRecords1.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream1);

            string status = "Incative";

            while (streamreader.Peek() > 0)
            {
                string line = streamreader.ReadLine();
                string[] arr = line.Split(',');
                
                if (line.StartsWith(Convert.ToString(bookingId)))
                {
                   for (int i = 0; i < arr.Length; i++)
                    {
                        if (i == 4) 
                        {
                            streamWriter.WriteLine(status);
                            Console.WriteLine("Your ticket calcelled succesfully for Booking id " + bookingId);
                            break;
                        }                            
                        streamWriter.Write(arr[i]+",");                                    
                    }
         
                }
                if (!line.StartsWith(Convert.ToString(bookingId)))
                {
                   for (int i = 0; i < arr.Length; i++)
                    {
                        if(i== 4)
                        {
                            streamWriter.WriteLine(arr[4]);
                            break;
                        }
                        streamWriter.Write(arr[i]+",");
                    }
                }

            }
            streamreader.Close();
            streamWriter.Close();
            fileStream1.Close();    
            fileStream.Close();

            File.Delete(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\bookingRecords.txt");
            File.Move(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\bookingRecords1.txt", @"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\bookingRecords.txt");

        }

        public void BookingStatus(int bookingId)
        {
            FileStream fileStream = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\bookingRecords.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamreader = new StreamReader(fileStream);
           
            while (streamreader.Peek() > 0)
            {
                string line = streamreader.ReadLine();
                string[] arr = line.Split(',');
                if (line.StartsWith(Convert.ToString(bookingId)))
                {
                    Console.WriteLine("Your booking status is : ");
                    Console.WriteLine();
                    Console.WriteLine("bId\tMovieName\tCityName\tTimeOfBooking\tStatus");
                       foreach (string item in arr)
                    {
                        Console.Write(item + "\t  ");
                    }
                       Console.WriteLine();
                       Console.WriteLine();

                }
            }

        }

    }
}
