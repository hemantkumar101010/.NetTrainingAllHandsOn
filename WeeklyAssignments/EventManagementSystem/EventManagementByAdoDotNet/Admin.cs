using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementByAdoDotNet
{
    internal class Admin
    {
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=EventManagementDb;Integrated Security=True";

         public void Adminportal()
        {
           
            Console.WriteLine("---------------WELCOME TO ADMIN MUDULE---------------");
            Console.WriteLine("Admin is allowed to Manage All Events.");
            Adminportal:
            Console.WriteLine();
            Console.WriteLine("Enter 1 to add new food item and decoration type for events");
            Console.WriteLine("Enter 2 to create a new type Event");

            Console.WriteLine("Enter 3 to see all Booking records.");
            Console.WriteLine("Enter 4 to logout.");

            Admin admin = new Admin();
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
                admin.InsertFoodItems();
                admin.InsertDecoration();
                goto Adminportal;
            }
            else if (i == 2)
            {
                admin.InsertEventTable();
                Console.WriteLine("Event created!");
                goto Adminportal;
            }
            else if (i == 3)
            {
                admin.DisplayAllBookings();
               
            }
            else if (i == 4)
            {
                return;
            }
        }

         public void InsertDecoration()
        {

            Console.Write("Enter Decotation Type(Normal/Gold/Premium): ");
            string name = (Console.ReadLine());

            Console.Write("Enter Decoration Cost: ");
            int cost =Convert.ToInt32(Console.ReadLine());

            //insert into db
            #region connected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("insert into Decoration values('" + name + "'," + cost + ")", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            
            #endregion
        }

         public void InsertFoodItems()
        {

            Console.Write("Enter Food Item name ");
            string name = (Console.ReadLine());

            Console.Write("Enter Food item types Cost: ");
            int cost = Convert.ToInt32(Console.ReadLine());

            //insert into db
            #region connected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("insert into FoodItems values('" + name + "'," + cost + ")", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            #endregion
        }

        public string InsertEventTable()
        {
            Console.Write("Enter Event name: ");
            string name = (Console.ReadLine());

            Console.Write("Enter Event Venue: ");
            string venue = (Console.ReadLine());

            //Console.Write("Enter DecorationId: ");
            //int decorationId = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Enter FoodItemId: ");
            //int foodItemId = Convert.ToInt32(Console.ReadLine());
            //insert into db
            #region connected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("insert into EventTable values('" + name + "','" + venue + "')", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "Inserted";
            #endregion
        }

        public void DisplayAllBookings()
        {
            Admin obj = new Admin();
            DataTable dt = obj.ShowAllBookings();
            Console.WriteLine("CId\tCName\tCAddrs  Mobile\tEventName\tFoodIds\tDId\tTPerson\tEventCost");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public DataTable ShowAllBookings()
        {
            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlDataAdapter sda = new SqlDataAdapter("select* from CustomerTable ", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
            #endregion
        }


    }
}