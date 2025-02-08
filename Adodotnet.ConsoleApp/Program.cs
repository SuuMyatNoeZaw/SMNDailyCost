using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adodotnet.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ADODotNet ado = new ADODotNet();
            //ado.Read();
            //ado.Create();
            //ado.Update();
            //ado.Delete(2);
            Dapper dapper = new Dapper();
            // dapper.Read();
            //dapper.GetByID(3);
            dapper.Create("Beans", 30, 1000, 1000);
        }
    }
}
