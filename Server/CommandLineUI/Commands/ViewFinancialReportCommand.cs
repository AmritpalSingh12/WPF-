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

namespace Server.CommandLineUI.Commands
{
    internal class ViewFinancialReportCommand : Command
    {
       public ViewFinancialReportCommand()
        {

        }


        public void Execute()
        {
            ViewFinancialReportController controller =
                new ViewFinancialReportController(
                    new MessagePresenter());


            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
     
        
    }
}

