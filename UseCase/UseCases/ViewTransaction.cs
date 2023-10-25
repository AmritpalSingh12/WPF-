using Assignment.DTOs;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.UseCases
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

              


                
            }
            return logs;
        }

        public override Dictionary<int, ItemDTO> ExecuteGrid()
        {
            throw new NotImplementedException();
        }
    }
}
