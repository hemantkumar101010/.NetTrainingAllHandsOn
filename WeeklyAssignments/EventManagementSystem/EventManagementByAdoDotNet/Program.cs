using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementByAdoDotNet
{
    class SignInSignUp
    {
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=EventManagementDb;Integrated Security=True";

        public void AdminSignInSignUp()
        {
            SignInSignUp signInSignUp = new SignInSignUp();
        REGISTER:
            Console.WriteLine("Type 1 to regiseter.");
            Console.WriteLine("Type 2 to login.");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
                Console.WriteLine("Enter your name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter your mailId: ");
                string email = Console.ReadLine();

                Console.WriteLine("Set a password: ");
                string password = Console.ReadLine();

                string status = "NULL";

                //insert into Admin Table

                #region disconnected-mode
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
                SqlDataAdapter sda = new SqlDataAdapter("insert into AdminRegistrationTable values('" + name + "','" + email + "','"+password+"','"+status+"')", sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Console.WriteLine("Registration successful!");
                goto REGISTER;
                #endregion

            }
            else if (i == 2)
            {
                VALIDPW:
                Console.WriteLine("Enter your mailId: ");
                string email = Console.ReadLine();
                //validating mail

                Console.WriteLine("Enter your passwoed: ");
                string password = Console.ReadLine();

                #region disconnected-mode
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
                SqlDataAdapter sda = new SqlDataAdapter("Select* from AdminRegistrationTable where Email='"+email+ "' and Password='" + password + "'", sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                #endregion
                if (dt.Rows.Count==1)
                {

                    Console.WriteLine($"Hey {dt.Rows[0][1]} to operate admin functions 1st check superAdmin make you as a Admin or not");
                    Console.WriteLine("Enter 1 to see to check your status");
                    int check=Convert.ToInt32(Console.ReadLine());
                    if (check == 1)
                    {
                        if (Convert.ToString(dt.Rows[0][4]) != "NULL")
                        {
                            Console.WriteLine("Your status is approved for admin role by super admin.");
                            Console.WriteLine();
                            Admin admin = new Admin();
                            admin.Adminportal();

                        }
                        else
                        {
                            Console.WriteLine("Sorry! Your status is not approved for admin role by super admin.");
                            Console.WriteLine("You cann't use any admin functions");
                            Console.WriteLine();

                        }

                    }    

                }
                else
                {
                    Console.WriteLine($"Invalid email or password. Try again!");
                    goto VALIDPW;
                }

            }
        }
        
        public void CustomerSignInSignUp()
        {
            SignInSignUp signInSignUp = new SignInSignUp();
        REGISTER:
            Console.WriteLine("Type 1 to regiseter.");
            Console.WriteLine("Type 2 to login.");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
                Console.WriteLine("Enter your name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter your Address: ");
                string address = Console.ReadLine();

                Console.WriteLine("Enter your mobile: ");
                int mobile = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter your email: ");
                string email = Console.ReadLine();

                Console.WriteLine("Set a password: ");
                string password = Console.ReadLine();


                //insert into Admin Table

                #region disconnected-mode
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
                SqlDataAdapter sda = new SqlDataAdapter("insert into CustomerRegistrationTable values('" + name + "','" + address + "',"+mobile+",'" + email + "','" + password + "')", sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Console.WriteLine("Registration successful!");
                goto REGISTER;
                #endregion

            }
            else if (i == 2)
            {
            VALIDPW:
                Console.WriteLine("Enter your mailId: ");
                string email = Console.ReadLine();
                //validating mail

                Console.WriteLine("Enter your password: ");
                string password = Console.ReadLine();

                #region disconnected-mode
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
                SqlDataAdapter sda = new SqlDataAdapter("Select* from CustomerRegistrationTable where Email='" + email + "' and Password='" + password + "'", sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                #endregion
                if (dt.Rows.Count == 1)
                {
                    Console.WriteLine($"Hey {dt.Rows[0][1]} Welcome to customer portal.");
                    Console.WriteLine("");
            
                        Customer customer = new Customer();
                        customer.CustomerPortal(Convert.ToInt32(dt.Rows[0][0]));

                }
                else
                {
                    Console.WriteLine($"Invalid email or password. Try again!");
                    goto VALIDPW;
                }

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

           SignInSignUp signInSignUp = new SignInSignUp();
            Main:
            Console.WriteLine("---------------WELCOME TO EVENT MANAGEMENT SYSTEM---------------");
            Console.WriteLine("Please any one of the following portal:");
            Console.WriteLine("1. Super Admin");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Customer");
            Console.WriteLine("");
            int choice;
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
                    SuperAdmin superAdmin = new SuperAdmin();
                    superAdmin.SuperAdminM();
                    goto Main;
               
                case 2:
                    signInSignUp.AdminSignInSignUp();
                    goto Main;
                case 3:
                    signInSignUp.CustomerSignInSignUp();           
                    goto Main;

            }
        }

    }
}
