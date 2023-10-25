using Assignment.DTOs;
using Assignment.Library;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCases
{
    public class ViewFinancialReport : AbstractUseCase
    {
        public ViewFinancialReport(IDataGatewayFacade gatewayFacade) : base(gatewayFacade)
        {

        }

        public override DTO Execute()
        {
            double total = 0;

            Console.WriteLine("\nFinancial Report:");

            foreach (TransactionLogEntry entry in gatewayFacade.GetTransactionLog())
            {
                if (entry.TypeOfTransaction.Equals("Item Added")
                    || entry.TypeOfTransaction.Equals("Quantity Added"))
                {
                    double cost = entry.ItemPrice * entry.Quantity;
                    Console.WriteLine("{0}: Total price of item: {1:C}", entry.ItemName, cost);
                    total += cost;
                }
            }

            return new MassageDTO(String.Format("{0}: {1:C}", "Total price of all items", total));
        }

        public List<TransactionLogEntry> ViewFinancilGrid()

        {
            double total = 0;
            List<TransactionLogEntry> logs = new List<TransactionLogEntry>();

           // Console.WriteLine("\nFinancial Report:");

            foreach (TransactionLogEntry entry in gatewayFacade.GetTransactionLog())
            {
                if (entry.TypeOfTransaction.Equals("Item Added")
                    || entry.TypeOfTransaction.Equals("Quantity Added"))
                {
                    double cost = entry.ItemPrice * entry.Quantity;
                    //  Console.WriteLine("{0}: Total price of item: {1:C}", entry.ItemName, cost);
                    logs.Add(entry);
                      total += cost;
                }
            }

            return logs;
        }

        public override Dictionary<int, ItemDTO> ExecuteGrid()
        {
            throw new NotImplementedException();
        }
    }



        
        
            
    

    }

