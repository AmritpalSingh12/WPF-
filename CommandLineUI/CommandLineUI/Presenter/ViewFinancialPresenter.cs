using Assignment.DTOs;
using Assignment.Library;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Presenter
{
     class ViewFinancialPresenter : AbstractPresenter

    {
       public override ViewData ViewData
        {
            get
            {
                List<TransactionLogEntry> transactionLogEntries = ((TransactionLogEntryList)DataToPresent).List;
                List<string> lines = new List<string>();
                lines.Add("\nFinancial Report:");
                lines.Add(string.Format("{0}: Total price of item: {1:C}", "Item Name", "ItemPrice"));

                    transactionLogEntries.ForEach(t => lines.Add(DisplayFinancialReport(t)));
                return new CommandLineViewData(lines);
            }
        }

            private string DisplayFinancialReport(TransactionLogEntry t)
        {
            return string.Format(
                "{0}: Total price of item: {1:C}",
                
                t.ItemName,
                t.ItemPrice
                );


                
        }




       
            
        }

    }

