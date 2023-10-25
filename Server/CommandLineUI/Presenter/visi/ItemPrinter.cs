using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.visi
{
    public class ItemPrinter : Visitor
    {
        public List<string> Lines { get; } = new List<string>();

        public void VisitItem(VisitableItem item)
        {
            Lines.Add(String.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                item.ID,
                item.Name,
                item.Quantity));
        }
    }
}
