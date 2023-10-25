using Server.CommandLineUI.Presenter;
using Server.DTOs;
using Server.Entities;
using Server.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Presenter
{
    class TransactionLog : AbstractPresenter
    {

        public override ViewData ViewData
        {
            get
            {
                List<TransactionLogEntry> transactionlogentries = ((TransactionLogEntryList)DataToPresent).List;
                List<string> lines = new List<string>();
                lines.Add("\nTransaction Log:");
                lines.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    "Date",
                    "Type",
                    "ID",
                    "Name",
                    "Quantity",
                    "Employee",
                    "Price"));
                transactionlogentries.ForEach(entry => lines.Add(DisplayTransactionLog(entry)));

                return new CommandLineViewData(lines);
            }
        }


                private string DisplayTransactionLog(TransactionLogEntry entry)
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

            }
        }

    

