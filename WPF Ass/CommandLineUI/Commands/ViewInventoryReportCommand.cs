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
using UseCases.UseCases;

namespace Assignment.CommandLineUI.Commands
{
    public class ViewInventoryReportCommand :Command
    {
        public ViewInventoryReportCommand()
        {

        }
        public void Execute()
        {
            ViewInventoryController controller =
                new ViewInventoryController(
                        new MessagePresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }







    }
}

