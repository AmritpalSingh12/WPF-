using Assignment.Library;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class InsertTransactionlog : DatabaseInserter<TransactionLogEntry>
    {

        protected override string GetSQL()
        {
            return
               "insert into transactionlogentry (TypeOfTransaction, ItemID, ItemName, ItemPrice, Quantity, EmployeeName, DateCreated) values (@typeoftransaction, @itemid, @itemname, @itemprice, @quantity, @employee, @datecreated)";

        }

        protected override int DoInsert(MySqlCommand command, TransactionLogEntry transactionToInsert)
        {
            command.Parameters.AddWithValue("@typeoftransaction", transactionToInsert.TypeOfTransaction);
            command.Parameters.AddWithValue("@itemid", transactionToInsert.ItemID);
            command.Parameters.AddWithValue("@itemname", transactionToInsert.ItemName);
            command.Parameters.AddWithValue("@itemprice", transactionToInsert.ItemPrice);
            command.Parameters.AddWithValue("@quantity", transactionToInsert.Quantity);
            command.Parameters.AddWithValue("@employee", transactionToInsert.EmployeeName);
            command.Parameters.AddWithValue("@datecreated", transactionToInsert.DateAdded);

            int numberOfRowAffected = command.ExecuteNonQuery();

            if (numberOfRowAffected != 1)
            {
                throw new Exception("Error Transaction Log Entry not inserted");
            }
            return numberOfRowAffected;
        }
    }
    }
