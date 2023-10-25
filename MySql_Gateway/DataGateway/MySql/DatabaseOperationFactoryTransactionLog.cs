using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class DatabaseOperationFactoryTransactionLog
    {

        public const int SELECT_ALL =1; 

        public DatabaseInserter<TransactionLogEntry> CreateInserter()
        {
            return new InsertTransactionlog();
        }

        public ISelector<List<TransactionLogEntry>> CreateSelector(int typeOfSelection)
        {
            if (typeOfSelection == SELECT_ALL)
            {
                return new GetTransactionLog();
            }
            return new NullSelector<List<TransactionLogEntry>>();
        }
    }
}
