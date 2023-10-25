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
    public class ViewPersonalUsageReportCommand_cs : Command
    {

        public ViewPersonalUsageReportCommand_cs()
        {

        }

        public void Execute()
        {
            PersonalController controller =
                new PersonalController(
                    ConsoleReader.ReadString("Employee name"),
                    new MessagePresenter());

            CommandLineViewData data =
                   (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
        


}
}
