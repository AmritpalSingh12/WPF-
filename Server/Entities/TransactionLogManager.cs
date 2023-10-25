
using System.Collections.Generic;

namespace Server.Entities
{
    public class TransactionLogManager
    {
        private List<TransactionLogEntry> transactions;

        public TransactionLogManager()
        {
            transactions = new List<TransactionLogEntry>();
        }

        public void AddTransactionLog(TransactionLogEntry entry)
        {
            transactions.Add(entry);
           

        }

        public List<TransactionLogEntry> GetTransactionLog()
        {
            return transactions;
        }
    }
}
