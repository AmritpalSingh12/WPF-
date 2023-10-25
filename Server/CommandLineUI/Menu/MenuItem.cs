using System;
using System.Collections.Generic;
using System.Text;

namespace Server.menu
{
    internal class MenuItem : MenuElement
    {
        public MenuItem(int id, string text) : base(id, text)
        {

        }

        public override void Print(string indent)
        {
            Console.WriteLine("{0}{1}. {2}", indent, Id, Text);
        }

    }
}
