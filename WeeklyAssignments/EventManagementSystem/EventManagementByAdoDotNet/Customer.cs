using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementByAdoDotNet
{
    internal class Customer 
    {
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=EventManagementDb;Integrated Security=True";
        public void CustomerPortal(int custId)
        {
            Console.WriteLine("---------------WELCOME TO CUSTOMER MUDULE---------------");
            Console.WriteLine("Customer can book a event accordingly.");
            Console.WriteLine();
            Customer customer = new Customer();
        Customer:
            Console.WriteLine("Enter 0 to see all events management available currently.");
            Console.WriteLine("Enter 1 to to book a event");
            Console.WriteLine("Enter 2 to check your event status if you have already booked");
            Console.WriteLine("Enter 3 to logOut");
            int i =Convert.ToInt32(Console.ReadLine());
            if(i == 0)
            {
              
                customer.DisplayAllEvents();
                Console.WriteLine();
                goto Customer;
            }
            else if (i == 1)
            {
               //Customer customer = new Customer();
               Console.WriteLine(customer.BookEvent(custId));
               Console.WriteLine();
                goto Customer;
            }
            else if(i == 2)
            {
                customer.CheckYourStatus(custId);
                goto Customer;
            }
            else if (i == 3)
            {
                return;
            }
        }
        public DataTable ShowFoodItems()
        {
            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlDataAdapter sda = new SqlDataAdapter("select* from FoodItems ", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
            #endregion
            
        }
        public void DisplayAllEvents()
        {
            DataTable dt = ShowAllEvents();
            Console.WriteLine("EventId EventName\tEventVenue");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j]+"\t");
                }
                Console.WriteLine();
            }
        }
        public DataTable ShowAllEvents()
        {
            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlDataAdapter sda = new SqlDataAdapter("select* from EventTable ", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
            #endregion
        }
        public DataTable ShowDecorationTypes()
        {
            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlDataAdapter sda = new SqlDataAdapter("select* from Decoration ", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
            #endregion

        }
        public string BookEvent(int custId)
        {

            Console.WriteLine("Enter event name:");
            string eventName = Console.ReadLine();

            Console.WriteLine("Enter 1 to see all food items to add in the party.");
            int i1 = Convert.ToInt32(Console.ReadLine());
            if (i1 == 1)
            {
                Console.WriteLine("");
                DataTable dt = ShowFoodItems();
                Console.WriteLine("FoodId\tItemName\tItemCost");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Console.Write(dt.Rows[i][j] + "\t\t");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Enter total number of food items you wants to add for the party event") ;
            int totalItems = Convert.ToInt32(Console.ReadLine());
            string itemsIdStringConcate="";

            for (int i = 0; i < totalItems; i++)
            {
                if(i==0)
                  Console.WriteLine($"Enter {i+1}st food id from the above table.");
                else if(i==1)
                  Console.WriteLine($"Enter {i + 1}ed food id from the above table.");
                else if(i==2)
                    Console.WriteLine($"Enter {i + 1}rd food id from the above table.");
                else
                    Console.WriteLine($"Enter {i + 1}th food id from the above table.");
                itemsIdStringConcate += Console.ReadLine();
                if(i!=totalItems-1)
                  itemsIdStringConcate += ",";
            }//1,2,3,4

            //calulating total expense in food items
            string[] arr = itemsIdStringConcate.Split(',');
            DataTable dtCost = ShowFoodItems();
            int total=0;
            //3,4

            for (int i = 0; i < dtCost.Rows.Count; i++)
            {
               
                    if (itemsIdStringConcate.Contains(Convert.ToString(dtCost.Rows[i][0])))
                    {
                        total += (int)dtCost.Rows[i][2];
                    }
                
            }
            Console.WriteLine("");
            Console.WriteLine("Enter 1 to see all decoration type for the party.");
            i1 = Convert.ToInt32(Console.ReadLine());
            DataTable dt2 = ShowDecorationTypes();
            if (i1 == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("DecorId\tDecorationType\tDecoration Cost");
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        Console.Write(dt2.Rows[i][j] + "\t\t");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Enter DecorId accordingly for your event Decoration.");
            int DecorationId = Convert.ToInt32(Console.ReadLine());
            int decoreCost = 0;

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    if (DecorationId == Convert.ToInt32(dt2.Rows[i][0]))
                    {
                        decoreCost = Convert.ToInt32(dt2.Rows[i][2]);
                    }
                    else
                        break;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Enter total number of person will present the party");
            int totalNoOfPerson = Convert.ToInt32(Console.ReadLine());

            //final event pey ammount
            total = total * totalNoOfPerson + decoreCost;

            //approval status
            string status = "Waiting";
            //insert into Admin Table

            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlDataAdapter sda = new SqlDataAdapter("insert into CustomerTable values("+custId+",'"+eventName+"','"+ itemsIdStringConcate + "',"+DecorationId+","+ totalNoOfPerson + ",'"+status+ "'," + total + ")", sqlConnection);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            return $"Your approximate Pay Amount for the party is: {total }.Till now Wait for approval!";
            #endregion

        }
        public void CheckYourStatus(int custId)
        {
            Admin obj = new Admin();
            DataTable dt = obj.ShowAllBookings();
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(custId== Convert.ToInt32(dt.Rows[i][3]))
                {
                    //int j = dt.Columns.Count - 1;
                    if (Convert.ToString(dt.Rows[i][8]) == "Approved")
                    {
                        Console.WriteLine($"Hey {dt.Rows[i][0]}! your request has been {dt.Rows[i][8]} ");
                        Console.WriteLine($"And your total appoximate Event Payment is {dt.Rows[i][9]} Rupees Only");
                    }
                    else if(Convert.ToString(dt.Rows[i][8]) == "Rejected")
                    {
                        Console.WriteLine($"Hey {dt.Rows[i][0]}! your request has been {dt.Rows[i][8]} due to some condition.");
                    }
                    else
                    {
                        Console.WriteLine($"Hey {dt.Rows[i][0]}! your request for the event is on {dt.Rows[i][8]} List.");
                        Console.WriteLine("Please wait for sometime to get the status from the Event Admin.");

                    }

                    Console.WriteLine();
                }
                        
            }

        }
    }
}
