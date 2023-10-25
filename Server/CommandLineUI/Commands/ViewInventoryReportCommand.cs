using Assignment.CommandLineUI.Presenter;
using Server.DTOs;
using Server.Entities;
using Server.CommandLineUI.Presenter;
using Server.UseCases;
using Server.CommandLineUI;
using Server.CommandLineUI.Commands;
using Server.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.UseCases;

namespace Server.CommandLineUI.Commands
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

