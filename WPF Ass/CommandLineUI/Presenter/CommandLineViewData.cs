using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Presenter
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
