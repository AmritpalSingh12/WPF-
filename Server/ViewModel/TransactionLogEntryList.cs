
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DTOs
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
