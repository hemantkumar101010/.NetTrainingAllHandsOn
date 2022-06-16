using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementByAdoDotNet
{
    /*
     The process of application start with Creating Admin and this right is with SuperAdmin he can create an Admin. 
    After creating Admin, the admin has right to Add Various Types of thing such as Venue for Marriage, Equipment required for Marriage, 
    Food Items for Marriage, Lightings, and Flowers with Cost.

After adding this Type will be visible to Customer while they are booking event after booking event this application is sent to admin for
    Approval in approval admin can Approve or reject the application on the base of condition after that status is available to Customer.
Meanwhile, admin can see entire application submitted by Customer and Total Cost. For the customer, 
    they can see status after submitting Application and can print the receipt and see what they have subscribed.

     */
    public class SuperAdmin
    {
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=EventManagementDb;Integrated Security=True";
        public void IMSuperAdmin()
        {
            Console.WriteLine("---------------WELCOME TO SUPER ADMIN MUDULE---------------");
            Console.WriteLine("Super admin is allowed to create a ADMIN only.");
            Add:
            Console.WriteLine();
            Console.WriteLine("Enter 1 to create a ADMIN.");
            Console.WriteLine("Enter 2 to logout.");
            int i=Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
               SuperAdmin superAdmin = new SuperAdmin();
               superAdmin.CreateAdmin();
               goto Add;
            }
            else if (i == 2)
            {
                return;
            } 
        }

        public string CreateAdmin()
        {
            Console.Write("Enter Admin name: ");
            string adminName = (Console.ReadLine());

            Console.Write("Enter Admin Role(SuperAdmin/Admin): ");
            string adminRole = Console.ReadLine();


            //insert into Admin Table

            #region disconnected-mode
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlDataAdapter sda = new SqlDataAdapter("insert into AdminTable values('" + adminName + "','" + adminRole + "')", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return "Admin Created";
            #endregion
        }
    }
}
