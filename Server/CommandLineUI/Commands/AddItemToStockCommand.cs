using Assignment.CommandLineUI.Presenter;
using Server.DTOs;
using Server.Entities;

using Server.UseCases;
using Server.CommandLineUI;
using Server.CommandLineUI.Commands;
using Server.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Server.CommandLineUI.Presenter;

namespace Server.CommandLineUI.Commands
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
