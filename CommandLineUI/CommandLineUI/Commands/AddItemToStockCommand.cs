using Assignment.CommandLineUI.Presenter;
using Assignment.DTOs;
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
    public class AddItemToStockCommand : Command
    {

        public AddItemToStockCommand()
        {

        }

        public void Execute()
        {

            AddItemController controller =
                new AddItemController(
                    ConsoleReader.ReadString("\nEmployee Name"),
                    ConsoleReader.ReadInteger("Item ID"),
                    ConsoleReader.ReadString("Item Name"),
                    ConsoleReader.ReadInteger("Item Quantity"),
                    ConsoleReader.ReadDouble("Item Price"),
                    new MessagePresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);

           var ViewInventory = new ViewInventoryReportCommand();
            ViewInventory.Execute();







        }



    }
}
