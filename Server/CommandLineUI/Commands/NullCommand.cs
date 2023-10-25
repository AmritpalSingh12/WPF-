
using Server.CommandLineUI;
using Server.CommandLineUI.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Server.CommandLineUI.Presenter;

namespace Server.CommandLineUI.Commands
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
