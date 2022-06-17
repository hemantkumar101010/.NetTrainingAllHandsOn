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
            //Insert data in book table
        CALL_AGAIN:
            Console.WriteLine(InsertBook());
            Console.Write("Press 1 to insert another record or 2 to exit: ");
            int check = Convert.ToInt32(Console.ReadLine());
            if (check == 1)
                goto CALL_AGAIN;
            else
            { }

            //update book table
            Program.UpdateBook();

            //delete in book table
            Program.DeleteBook(4);

            //show all records inside book table
            DataTable dt = Program.SelectBook();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }

            //select book by bookID
            DataTable dt1 = Program.SelectBookByBookId(1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    Console.Write(dt1.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }

        }
        public static string sqlConnectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=LibraryDb;Integrated Security=True";
       
        //insert data into book table
        public static string InsertBook()
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
        


        //HandsOn : 14-06-2022

        //select all records in book table
        public static DataTable SelectBook()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
            SqlCommand cmd = new SqlCommand("select* from Book", sqlConnection);
            sqlConnection.Open();//connection state
            SqlDataReader sqlDataReader = cmd.ExecuteReader();//execute select statement

            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);

            sqlConnection.Close();
            return dataTable;
        }

        //select book by bookid
        public static DataTable SelectBookByBookId(int bookId)
        {

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            string db = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("select * from Book where BookId=" + bookId, sqlConnection);
            sqlConnection.Open();//connection state is open

            SqlDataReader dataReader = cmd.ExecuteReader();//execute select statment

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            //DataTable, DataSet
            sqlConnection.Close(); //connection state is close
            return dataTable;
        }

        //delete a perticular row by bookid
        public static string DeleteBook(int bookId)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlCommand cmd = new SqlCommand("delete from book where bookid=" + bookId, sqlConnection);
            sqlConnection.Open();//connection state is open
            int result = cmd.ExecuteNonQuery();//execute my sql commands and return no of rows affected
            sqlConnection.Close(); //connection state is close
            if (result == 0)
                return "Not Deleted";
            return "Deleted";
        }


        //update a perticular row by bookId
        public static string UpdateBook()
        {
            Console.Write("Enter book Id to update: ");
            int bookId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter book name  to update: ");
            string bookName = Console.ReadLine();


            Console.Write("Enter author first name  to update: ");
            string fName = (Console.ReadLine());

            Console.Write("Enter author last name  to update: ");
            string lName = Console.ReadLine();

            Console.Write("Enter book Price to update: ");
            int price = Convert.ToInt32(Console.ReadLine());


            //update book data into sqlserver
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlCommand cmd = new SqlCommand("update Book set BookName='" + bookName + "' , AuthorFName='" + fName + "' , AuthorLName='" + lName + "', BookPrice="+ price+" where BookId=" + bookId + "", sqlConnection);
            sqlConnection.Open();//connection state is open
            int result = cmd.ExecuteNonQuery();//execute my sql commands 1
            sqlConnection.Close(); //connection state is close
            if (result == 0)
                return "Not Updated";
            return "Updated";
        }
    }
}

