using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinemaTicketBookingSystem
{
    public class AdminModule
    {
        public void AddAvailableMovie()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\availableMovieDetails.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);

            int counter = 1, currentAvailableMovies;
            Console.WriteLine("Enter total number Of movie you want to add in the the online portal");
            currentAvailableMovies = Convert.ToInt32(Console.ReadLine());
            //streamWriterObj.WriteLine("BookId\tBookName\tBookWriter");

            while (counter <= currentAvailableMovies)
            {

                Console.WriteLine("Enter City Name");
                string cityName = (Console.ReadLine());
                streamWriterObj.Write(cityName + ",");

                Console.WriteLine("Enter Movie Name");
                string movieName = Console.ReadLine();
                streamWriterObj.Write(movieName + ",");

                Console.WriteLine("Enter morning time slot");
                string movieTiming1 = Console.ReadLine();
                streamWriterObj.Write(movieTiming1 + ",");

                Console.WriteLine("Enter evening time slot");
                string movieTiming2 = Console.ReadLine();
                streamWriterObj.WriteLine(movieTiming2);

                counter++;
            }
            streamWriterObj.Close();
            fileStreamObj.Close();
            Console.WriteLine("File write operation completed");

        }

        public void BookingReports()
        {
            FileStream fileStream = new FileStream(@"C:\Users\iamte\Desktop\.NetTrainingAssignmentRepo\.NetTrainingAllHandsOn\WeeklyAssignments\CinemaTicketBookingSystem\bookingRecords.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamreader = new StreamReader(fileStream);

            Console.WriteLine("BId  MovieName\t\tCityName\tBooking DateTime\tBooking Status");
            while (streamreader.Peek() > 0)
            {
                string line = streamreader.ReadLine();
                string[] arr = line.Split(',');
                foreach (string s in arr)
                {
                    Console.Write(s + "    \t");
                }
                Console.WriteLine();
            }

        }
    }
}
