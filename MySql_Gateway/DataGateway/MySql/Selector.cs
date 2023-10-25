using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public interface ISelector<T>
    {
        public T Select();
    }
}
