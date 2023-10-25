using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public class NullSelector<T> : ISelector<T>
    {
        public T Select()
        {
            throw new Exception("Selection not supported");
        }
    }
}
