using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ViewModel
{
    public class TransactionViewModel
    {
        public string TypeOfTransaction { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateAdded { get; set; }


    }
}
