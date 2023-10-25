using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public  class TransactionLogEntryDTO : DTO
    {
        public string TypeOfTransaction { get; }
        public int ItemID { get; }
        public string ItemName { get; }
        public double ItemPrice { get; }
        public int Quantity { get; }
        public string EmployeeName { get; }
        public DateTime DateAdded { get; }

        public TransactionLogEntryDTO(string type, int itemID, string itemName, double itemPrice, int quantity, string employeeName, DateTime dateAdded)
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
