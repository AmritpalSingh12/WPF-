using Assignment.DTOs;
using Assignment.Library;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Presenter
{
     class ViewPersonalReport : AbstractPresenter
    {
        public override ViewData ViewData
        {
            get
            {
                List<TransactionLogEntry> transactionlogentries = ((TransactionLogEntryList)DataToPresent).List;
                List<string> lines = new List<string>();


                lines.Add(string.Format(
                    "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                    "Date Taken",
                    "ID",
                    "Name",
                    "Quantity Removed"));

                transactionlogentries.ForEach(t => lines.Add(PersonalUsage(t)));

                return new CommandLineViewData(lines);
            }
        }

            private string PersonalUsage(TransactionLogEntry t)
        {
            return String.Format(
                 "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                 t.DateAdded,
                 t.ItemID,
                 t.ItemName,
                 t.Quantity
                 );

                
        }





                
               
                  
    }
}
