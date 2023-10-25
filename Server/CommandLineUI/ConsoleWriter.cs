using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CommandLineUI
{
    class ConsoleWriter
    {
        public static void WriteStrings(List<string> lines)
        {
            lines.ForEach(Console.WriteLine);
        }
    }
}
