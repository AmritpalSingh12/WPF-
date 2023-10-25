using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class NullUpdater<T> : IUpdater<T>
    {
        public int Update(T itemToUpdate)
        {
            throw new Exception("Update operation not supported");
        }
    }
}
