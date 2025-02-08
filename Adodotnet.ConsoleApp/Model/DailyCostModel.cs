using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adodotnet.ConsoleApp.Model
{
    public class DailyCostModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Thing { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }  
        public int Total { get; set; }
        public bool DeleteFlag { get; set; }

    }
}
