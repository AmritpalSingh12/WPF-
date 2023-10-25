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

