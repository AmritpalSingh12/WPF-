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
    class TakeQuantityFromItemCommand : Command

    {
        public TakeQuantityFromItemCommand()
        {

        }

        public void Execute()
        {
            RemoveQuantityController controller = 
                new RemoveQuantityController(
                    ConsoleReader.ReadString("\nEmployee Name"),
                ConsoleReader.ReadInteger("Item ID"),
                ConsoleReader.ReadInteger("How many items would you like to remove?"),
                new MessagePresenter()
                );
            CommandLineViewData data =
               (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);



        }

    }
}
