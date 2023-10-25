using System;
using System.Collections.Generic;
using System.Text;
using Assignment.CommandLineUI.Presenter;
using Assignment.Controller;
using Assignment.DTOs;
using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using CommandLineUI.CommandLineUI;
using CommandLineUI.CommandLineUI.Commands;

namespace Assignment.CommandLineUI.Commands
{

    public class InitialiseDatabaseCommand : Command
    {
        public InitialiseDatabaseCommand()
        {

        }

        public void Execute()
        {
            InitailiseDatabaseController controller =
                new InitailiseDatabaseController(
                    new MessagePresenter());
            CommandLineViewData data =
               (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);


        }
    }
}



    
    

       

        