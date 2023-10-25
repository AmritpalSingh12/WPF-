using Assignment.UI_commands;
using CommandLineUI.CommandLineUI;
using CommandLineUI.CommandLineUI.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    public class NullCommand : Command
    {
        public NullCommand()
        {

        }

        public void Execute()
        {
            ConsoleWriter.WriteStrings(
               new List<string>()
                   {"Menu choice not recognised"});
        }
    }
}
