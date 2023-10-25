using Assignment.CommandLineUI.Presenter;
using Server.Entities;
using Server.CommandLineUI.Presenter;
using Server.UseCases;
using Server.CommandLineUI;
using Server.CommandLineUI.Commands;
using Server.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.CommandLineUI.Commands
{
    public class ViewTransactionLogCommand :Command

    {
        public ViewTransactionLogCommand()
        {
        }

        public void Execute()
        {
            ViewTransactionController controller =
                new ViewTransactionController(
                        new TransactionLog());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
