using System;
using System.Collections.Generic;
using System.Text;
using Assignment.CommandLineUI.Presenter;
using Server.Controller;
using Server.DTOs;
using Server.Entities;

using Server.UseCases;
using Server.CommandLineUI;
using Server.CommandLineUI.Commands;
using Server.CommandLineUI.Presenter;

namespace Server.CommandLineUI.Commands
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



    
    

       

        