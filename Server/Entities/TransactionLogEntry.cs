using System;

namespace Server.Entities
{
    [Serializable]
    public class TransactionLogEntry : IEntity
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
            ItemPrice = Math.Round(itemPrice, 2);
            Quantity = quantity;
            EmployeeName = employeeName;
            DateAdded = dateAdded;
        }
    }
}
