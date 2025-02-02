using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adodotnet.ConsoleApp
{
    public class ADODotNet
    {
        string connectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS; Initial Catalog=F9DB; Trusted_Connection=True;";
        public void Read() 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT [CostID]
      ,[Date]
      ,[Thing]
      ,[Number]
      ,[Price]
      ,[Total]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_DailyCost]";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["costID"]);
                Console.WriteLine(dr["Date"]);
                Console.WriteLine(dr["About"]);
                Console.WriteLine(dr["Cost"]);
                Console.WriteLine(dr["Total"]);
            }
            Console.ReadLine();
        }

        public void Create()
        {
            Console.WriteLine("Enter Date");
           DateTime date=DateTime.Parse (Console.ReadLine());
            Console.WriteLine("Enter Thing");
            string thing=Console.ReadLine();
            Console.WriteLine("Enter Number");
            int number=Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price");
            int price= Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Total Price");
            int total= Int32.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $@"INSERT INTO[dbo].[Tbl_DailyCost] (
      [Date]
      ,[Thing]
      ,[Number]
      ,[Price]
      ,[Total]
        ,[DeleteFlag])
      
        VALUES (@Date,@Thing,@Number,@Price,@Total,0)";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@Thing", thing);
            cmd.Parameters.AddWithValue("@Number", number);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Total", total);
           int result= cmd.ExecuteNonQuery();

            Console.WriteLine(result==1?"Your Task is succeeded":"Your Task is failed");
            Console.ReadLine();
        }
    }
}
