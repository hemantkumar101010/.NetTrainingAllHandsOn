using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LibraryProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CALL_AGAIN:
            Console.WriteLine(InsertCustomer());
            Console.Write("Press 1 to insert another record or 2 to exit: ");
            int check = Convert.ToInt32(Console.ReadLine());
            if (check == 1)
                goto CALL_AGAIN;
            else
               { }

        }
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=LibraryDb;Integrated Security=True";
        static string InsertCustomer()
        {
            Console.Write("Enter book name: ");
            string bookName = (Console.ReadLine());

            Console.Write("Enter author first name: ");
            string authorFName = (Console.ReadLine());

            Console.Write("Enter author last name: ");
            string authorLName = (Console.ReadLine());

            Console.Write("Enter book price: ");
            int price = Convert.ToInt32((Console.ReadLine()));

            //insert into db
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("insert into Book values('"+ bookName + "','"+ authorFName + "','"+ authorLName + "',"+ price + ")",sqlConnection); 
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "Book Data Inserted!!";
        }

            
         
    }
}

