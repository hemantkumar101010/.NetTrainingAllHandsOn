using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducsNSalesRecordSystem
{
    internal class Program
    {
        string connectionStr = @"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Initial Catalog=ProductsNSalesDb;Integrated Security=True";
        static void Main(string[] args)
        {
          Program program = new Program();
            Main:
            Console.WriteLine("Enter 1 to add product records");
            Console.WriteLine("Enter 2 to buy a product");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
                Console.WriteLine(program.InsertInProductDetails());
                goto Main;
            }
            else
            {
                program.buyAProduct();
                goto Main;
            }     

        }

        public string InsertInProductDetails()
        {
            Console.WriteLine("Enter product name.");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter product price.");
            int productPrice = Convert.ToInt32(Console.ReadLine());

            //interacting with database
            #region connected-approach
            SqlConnection sqlConnection = new SqlConnection(connectionStr);//stablishing the connection with db
            string queryString = "INSERT INTO ProductDetails VALUES('" + productName + "',"+productPrice+")";
           
            SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
            sqlConnection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (i > 0)
                return "Inserted";
            else
                return "Not Inserted";
            #endregion
        }

        public void ShowProducts()
        {
            #region Disconnected-approach
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string queryStr = "SELECT* FROM ProductDetails";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(queryStr, sqlConnection);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            Console.WriteLine();
            Console.WriteLine("PId PName\tPCost");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if(j==0)
                        Console.Write($"{dt.Rows[i][j]}  ");
                    else
                    Console.Write($"{dt.Rows[i][j]}\t");
                }
                Console.WriteLine();
            }
            #endregion
        }
        public void buyAProduct()
        {
            Program program = new Program();    
            program.ShowProducts();

            Console.WriteLine("Enter any product id to buy that id product");
            int productId = Convert.ToInt32(Console.ReadLine());
            

            Console.WriteLine("Enter total quantity.");
            int totalQuantity = Convert.ToInt32(Console.ReadLine());

            #region connected-mode
            //SqlConnection sqlConnection = new SqlConnection(connectionStr);//connection stablishmentg
            //SqlCommand cmd = new SqlCommand("SELECT* FROM ProductDetails WHERE ProductName='" + productName + "'", sqlConnection);
            //sqlConnection.Open();//connection state
            //SqlDataReader sqlDataReader = cmd.ExecuteReader();//execute select statement

            //DataTable dt = new DataTable();
            //dt.Load(sqlDataReader);
            //sqlConnection.Close();
            #endregion

            #region Disconnected-approach
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string queryStr = "SELECT * FROM ProductDetails WHERE ProductId='" + productId + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(queryStr, sqlConnection);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            #endregion
            
            string dateTime = Convert.ToString(DateTime.Today);

            program.InsertInSalesDetails(productId, totalQuantity, totalQuantity*Convert.ToInt32(dt.Rows[0][2]), dateTime);
            Console.WriteLine($"Thanks for purchasing {totalQuantity} {dt.Rows[0][1]} products from us.");
            Console.WriteLine($"Your total amout is {totalQuantity * Convert.ToInt32(dt.Rows[0][2])}");
        }

        public void InsertInSalesDetails(int productId,int totalQuantity,int totalCost,string dateTime)
        {
            #region Disconnected-approach
            SqlConnection sqlConnection1 = new SqlConnection(connectionStr);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("INSERT INTO SalesDetail VALUES(" + productId + ", " + totalQuantity + ", " + totalCost + ", '" + dateTime + "') ", sqlConnection1);
            DataTable dt1 = new DataTable();
            sqlDataAdapter1.Fill(dt1);

            #endregion
        }
    }
}
