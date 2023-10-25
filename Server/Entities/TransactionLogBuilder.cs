using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Entities
{
    public class TransactionLogBuilder
    {
        public string TypeOfTransaction;
        public int ItemID;
        public string ItemName;
        public double ItemPrice;
        public int Quantity;
        public string EmployeeName;
        public DateTime DateAdded;

        public TransactionLogBuilder()

        {
            this.TypeOfTransaction = null;
            this.ItemID = 0;
            this.ItemName = null;
            this.ItemPrice = 0;
            this.Quantity = 0;
            this.EmployeeName = null;
            
        }     
        
        public TransactionLogEntry Build()
        {
            return new TransactionLogEntry(TypeOfTransaction,ItemID,ItemName,ItemPrice,Quantity,EmployeeName,DateAdded);
        }

        public TransactionLogBuilder WithItemId(int ItemID)
        {
            this.ItemID = ItemID;
            return this;
            
        }

        public TransactionLogBuilder WithTypeOfTransaction(string TypeOfTransaction)
        {
            this.TypeOfTransaction = TypeOfTransaction;
            return this;
        }
        public TransactionLogBuilder WithItemName(string ItemName)
        {
            this.ItemName = ItemName;
            return this;
        }
        public TransactionLogBuilder WithItemPrice(double ItemPrice)
        {
            this.ItemPrice = ItemPrice;
            return this;
        }
        public TransactionLogBuilder WithQuantity(int Quantity)
        {
            this.Quantity = Quantity;
            return this;
        }
        public TransactionLogBuilder WithEmployeeName(string EmployeeName)
        {
            this.EmployeeName = EmployeeName;
            return this;
        }
        public TransactionLogBuilder WithDateAdded(DateTime DateAdded)
        {
            this.DateAdded = DateAdded;
            return this;
        }


    }
}
