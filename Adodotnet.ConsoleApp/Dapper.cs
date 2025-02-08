using Adodotnet.ConsoleApp.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adodotnet.ConsoleApp
{
    public class Dapper
    {
         string connectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS; Initial Catalog=F9DB; Trusted_Connection=True;";
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = $@"SELECT [CostID]
                                 ,[Date]
                                 ,[Thing]
                                 ,[Number]
                                  ,[Price]
                                  ,[Total]
                                  ,[DeleteFlag]
                                FROM [dbo].[Tbl_DailyCost]";

                List<DailyCostModel> list=db.Query<DailyCostModel>(query).ToList();
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Date);
                    Console.WriteLine(item.Thing);
                    Console.WriteLine(item.Number);
                    Console.WriteLine(item.Price);
                    Console.WriteLine(item.Total);
                    Console.WriteLine(item.DeleteFlag);
                   
                }
            }
           
        }

        public void GetByID(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = $@"SELECT [CostID]
                                 ,[Date]
                                 ,[Thing]
                                 ,[Number]
                                  ,[Price]
                                  ,[Total]
                                  ,[DeleteFlag]
                                FROM [dbo].[Tbl_DailyCost] where CostID=@Id";

                var result = db.Query<DailyCostModel>(query,new DailyCostModel
                {
                    Id = id
                }).FirstOrDefault();

                if(result is null)
                {
                    Console.WriteLine("No Data Found.");
                    return;
                   
                }

                
                    Console.WriteLine(result.Id);
                    Console.WriteLine(result.Date);
                    Console.WriteLine(result.Thing);
                    Console.WriteLine(result.Number);
                    Console.WriteLine(result.Price);
                    Console.WriteLine(result.Total);
                    Console.WriteLine(result.DeleteFlag);
                

                
            }
        }  
        public void Create(string thing,int num,int price,int total)
        {
            using (IDbConnection db=new SqlConnection(connectionString))
            {
                Console.WriteLine("Enter date...");
                DateTime dt=DateTime.Parse(Console.ReadLine());
                string query = $@"INSERT INTO [dbo].[Tbl_DailyCost]
           ([Date]
           ,[Thing]
           ,[Number]
           ,[Price]
           ,[Total]
           ,[DeleteFlag])
     VALUES
           (
            @Date,
            @Thing,
            @Number,
            @Price,
            @Total,
            0
            )";

                int result = db.Execute(query, new DailyCostModel
                {
                    Date= dt,
                    Thing=thing,
                    Number=num,
                    Price=price,
                    Total=total,
                });

                Console.WriteLine(result==1?" 1 row effected.":"Your task is failed.");





            }
        }
    }
}
