using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.menu
{
    public class Menus : MenuElement
    {
        private List<MenuElement> children;

        public Menus(string text) : base(-1, text)
        {
            children = new List<MenuElement>();
        }

        public void Add(MenuElement menuElement)
        {
            children.Add(menuElement);
        }

        public override void Print(string indent)
        {
            Console.WriteLine("\n{0}{1}", indent, Text);
            Console.WriteLine("{0}{1}", indent, "".PadLeft(Text.Length, '='));

            foreach (MenuElement item in children)
            {
                item.Print(indent + "    ");
            }
        }
    }
}
