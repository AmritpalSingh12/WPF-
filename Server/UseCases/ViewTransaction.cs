using Server.DTOs;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.UseCases
{
    public class ViewTransaction : AbstractUseCase
    {
        public ViewTransaction(IDataGatewayFacade gatewayFacade) : base(gatewayFacade)
        { 
        }

        public override DTO Execute()
        {
            
            return new TransactionLogEntryList(gatewayFacade.GetTransactionLog());
        }

        public List<TransactionLogEntry> ExecuteTransaction()
        {
            List<TransactionLogEntry> logs = new List<TransactionLogEntry>();

            foreach (TransactionLogEntry entry in gatewayFacade.GetTransactionLog())
            {
                
                    logs.Add(entry);
               // Console.WriteLine(entry.ToString());
              string result =DisplayTransactionLog(entry);

                Console.WriteLine(result);
                
            }
            return logs;
        }
public  string DisplayTransactionLog(TransactionLogEntry entry)
        {
            return string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                entry.DateAdded.ToString("dd/MM/yyyy"),
                entry.TypeOfTransaction,
                entry.ItemID,
                entry.ItemName,
                entry.Quantity,
                entry.EmployeeName,
                entry.TypeOfTransaction.Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}", entry.ItemPrice));
        }

        public override Dictionary<int, ItemDTO> ExecuteGrid()
        {
            throw new NotImplementedException();
        }
    }
}
