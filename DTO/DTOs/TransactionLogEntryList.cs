using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public class TransactionLogEntryList : DTO
    {
        public List<TransactionLogEntry> List { get; }

        public TransactionLogEntryList(List<TransactionLogEntry> list)
        {
            List = list;
        }
    }
}
