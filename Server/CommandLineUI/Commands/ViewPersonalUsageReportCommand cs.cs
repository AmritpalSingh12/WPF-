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
