using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ass.Entities
{
    public class TransactionLogEntry
    {
        public string TypeOfTransaction { get; }
        public int ItemID { get; }
        public string ItemName { get; }
        public double ItemPrice { get; }
        public int Quantity { get; }
        public string EmployeeName { get; }
        public DateTime DateAdded { get; }

        public TransactionLogEntry(string type, int itemID, string itemName, double itemPrice, int quantity, string employeeName, DateTime dateAdded)
        {
            TypeOfTransaction = type;
            ItemID = itemID;
            ItemName = itemName;
            ItemPrice = itemPrice;
            Quantity = quantity;
            EmployeeName = employeeName;
            DateAdded = dateAdded;
        }
    }
}

