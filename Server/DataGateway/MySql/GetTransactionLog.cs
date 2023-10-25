using Server.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public class GetTransactionLog : DatabaseSelector<List<TransactionLogEntry>>
    {

        public GetTransactionLog()
        {
        }

        protected override string GetSQL()
        {
            return "select TypeOfTransaction, ItemID, ItemName, ItemPrice, Quantity, EmployeeName, DateCreated from transactionlogentry";
        }

        protected override List<TransactionLogEntry> DoSelect(MySqlCommand command)
        {
            List<TransactionLogEntry> LogEntry = new List<TransactionLogEntry>();
            
            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    TransactionLogEntry logentry = new TransactionLogEntry(dr.GetString(0), dr.GetInt32(1), dr.GetString(2), dr.GetDouble(3), dr.GetInt32(4), dr.GetString(5), dr.GetDateTime(6));
                    LogEntry.Add(logentry);

                }
                dr.Close();
            }

            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of Transaction Log Entry failed", e);
            }
              return LogEntry;

        }
    }


}
