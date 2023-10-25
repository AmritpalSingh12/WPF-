using Server.DTOs;
using Server.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.CommandLineUI.Presenter
{
    class MessagePresenter : AbstractPresenter
    {
        public override ViewData ViewData
        {
            get
            {
                List<string> lines = new List<string>(1);
                lines.Add("\n" + ((MassageDTO)DataToPresent).Message);
                return new CommandLineViewData(lines);
            }
        }
    }
}
