using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.visi
{
    public interface Visitor
    {
        void VisitItem(VisitableItem item);
    }
}
