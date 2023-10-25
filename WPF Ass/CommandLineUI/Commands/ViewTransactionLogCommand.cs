using Assignment.CommandLineUI.Presenter;
using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using CommandLineUI.CommandLineUI;
using CommandLineUI.CommandLineUI.Commands;
using Controller.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
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
