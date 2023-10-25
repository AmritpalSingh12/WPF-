using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public interface IUpdater<T>
    {
        public int Update(T itemToUpdate);
    }
}
