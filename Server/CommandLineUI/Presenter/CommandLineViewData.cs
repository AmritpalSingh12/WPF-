using Server.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.CommandLineUI.Presenter
{
    internal class CommandLineViewData : ViewData
    {
        public List<string> ViewData { get; }

        public CommandLineViewData(List<string> viewData)
        {
            ViewData = viewData;
        }

    }
}
