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
    class AddQuantityToItem : Command
    {
       
        public AddQuantityToItem()
        {

        }
       
        public void Execute()
        {
            AddQuantityContoller controller = (
                new AddQuantityContoller(
                ConsoleReader.ReadString("\nEmployee Name"),
                ConsoleReader.ReadInteger("Item ID"),
                ConsoleReader.ReadInteger("How many items would you like to add?"),
                ConsoleReader.ReadDouble("Item Price"),
                new MessagePresenter()
                ));

            CommandLineViewData data = (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
        
    }
}
