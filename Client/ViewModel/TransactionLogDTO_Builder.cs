using System;
using System.Collections.Generic;
using System.Text;

namespace Client.DTOs
{
    public class TransactionLogDTO_Builder
    {
        public string TypeOfTransaction;
        public int ItemID;
        public string ItemName;
        public double ItemPrice;
        public int Quantity;
        public string EmployeeName;
        public DateTime DateAdded;


        public TransactionLogEntryDTO Build()
        {
            return new TransactionLogEntryDTO(TypeOfTransaction, ItemID, ItemName, ItemPrice, Quantity, EmployeeName, DateAdded);
        }

        public TransactionLogDTO_Builder WithItemId(int ItemID)
        {
            this.ItemID = ItemID;
            return this;

        }

        public TransactionLogDTO_Builder WithTypeOfTransaction(string TypeOfTransaction)
        {
            this.TypeOfTransaction = TypeOfTransaction;
            return this;
        }
        public TransactionLogDTO_Builder WithItemName(string ItemName)
        {
            this.ItemName = ItemName;
            return this;
        }
        public TransactionLogDTO_Builder WithItemPrice(double ItemPrice)
        {
            this.ItemPrice = ItemPrice;
            return this;
        }
        public TransactionLogDTO_Builder WithQuantity(int Quantity)
        {
            this.Quantity = Quantity;
            return this;
        }
        public TransactionLogDTO_Builder WithEmployeeName(string EmployeeName)
        {
            this.EmployeeName = EmployeeName;
            return this;
        }
        public TransactionLogDTO_Builder WithDateAdded(DateTime DateAdded)
        {
            this.DateAdded = DateAdded;
            return this;
        }


    }
}
