using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public interface IInserter<T>
    {
        public int Insert(T itemToInsert);
    }
}
