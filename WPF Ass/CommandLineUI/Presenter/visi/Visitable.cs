using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.visi
{
    public interface Visitable
    {
        void AcceptVisitFrom(Visitor v);
    }
}

