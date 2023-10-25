using Assignment.CommandLineUI;
using Server.CommandLineUI.Commands;
using Server.CommandLineUI.Menu;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CommandLineUI
{
    public class CommandLineUserInterface
    {
        public CommandLineUserInterface()
        {

        }

        public void Start()
        {
            CommandFactory factory = new CommandFactory();
            try
            {
                factory
                    .CreateCommand(RequestUseCase.INITIALISE_DATABASE)
                    .Execute();

                MenuFactory.INSTANCE.Create().Print("");
                int choice = GetUserChoice();

                while (choice != RequestUseCase.EXIT)
                {
                    factory
                        .CreateCommand(choice)
                        .Execute();

                    MenuFactory.INSTANCE.Create().Print("");
                    choice = GetUserChoice();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message);
            }
        }

        private static int GetUserChoice()
        {
            int option = ConsoleReader.ReadInteger("\nOption");
            while (option < 1 || option > 10)
            {
                Console.WriteLine("\nChoice not recognised, Please enter again");
                option = ConsoleReader.ReadInteger("\nOption");
            }
            return option;
        }
    }


}

