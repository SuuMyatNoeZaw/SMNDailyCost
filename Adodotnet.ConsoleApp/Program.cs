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
            ado.Create();
        }
    }
}
