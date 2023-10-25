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
