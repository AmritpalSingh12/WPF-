using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public interface ISelector<T>
    {
        public T Select();
    }
}
